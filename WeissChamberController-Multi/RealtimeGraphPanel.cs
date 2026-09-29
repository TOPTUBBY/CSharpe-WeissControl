using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Form1
{
    /// <summary>
    /// Runtime behavior for the graph controls declared in Form1.Designer.cs.
    /// Keeping control creation out of this class lets the complete workspace be
    /// moved and restyled with the Visual Studio Windows Forms Designer.
    /// </summary>
    internal sealed class RealtimeGraphController : IDisposable
    {
        private const int MaxStoredSamples = 30000;
        private const int MaxRenderedSamples = 4000;
        private static readonly TimeSpan MaximumHistory = TimeSpan.FromDays(1);

        private readonly List<GraphSample> _samples = new List<GraphSample>();
        private readonly Control _workspace;
        private readonly Chart _chart;
        private readonly DataGridView _valueGrid;
        private readonly ComboBox _timeDivCombo;
        private readonly CheckBox _autoFollowCheck;
        private readonly Button _resetButton;
        private readonly Label _probeLabel;
        private readonly Label _samplingLabel;
        private readonly Timer _renderTimer;
        private readonly Dictionary<string, Color> _seriesColors = new Dictionary<string, Color>();

        private bool _chartDirty;
        private bool _updatingGrid;
        private bool _disposed;
        private Point _mouseDownPoint;
        private DateTime? _probeTime;

        internal RealtimeGraphController(
            Control workspace,
            Chart chart,
            DataGridView valueGrid,
            ComboBox timeDivCombo,
            CheckBox autoFollowCheck,
            Button resetButton,
            Label probeLabel,
            Label samplingLabel)
        {
            _workspace = workspace;
            _chart = chart;
            _valueGrid = valueGrid;
            _timeDivCombo = timeDivCombo;
            _autoFollowCheck = autoFollowCheck;
            _resetButton = resetButton;
            _probeLabel = probeLabel;
            _samplingLabel = samplingLabel;

            foreach (Series series in _chart.Series)
                _seriesColors[series.Name] = series.Color;

            foreach (ChartArea area in _chart.ChartAreas)
                ConfigureInteractiveArea(area);

            _chart.MouseDown += Chart_MouseDown;
            _chart.MouseUp += Chart_MouseUp;
            _timeDivCombo.SelectedIndexChanged += TimeDivCombo_SelectedIndexChanged;
            _autoFollowCheck.CheckedChanged += AutoFollowCheck_CheckedChanged;
            _resetButton.Click += ResetButton_Click;
            _valueGrid.CellValueChanged += ValueGrid_CellValueChanged;
            _valueGrid.CurrentCellDirtyStateChanged += ValueGrid_CurrentCellDirtyStateChanged;

            PopulateValueGrid();
            if (_timeDivCombo.SelectedIndex < 0 && _timeDivCombo.Items.Count > 0)
                _timeDivCombo.SelectedIndex = _timeDivCombo.Items.Count - 1;

            _renderTimer = new Timer { Interval = 200 };
            _renderTimer.Tick += RenderTimer_Tick;
            _renderTimer.Start();
        }

        internal void AddSample(DateTime timestamp, double tempSet, double tempActual,
            double humiditySet, double humidityActual, bool isOn)
        {
            GraphSample sample = new GraphSample
            {
                Timestamp = timestamp,
                TempSet = tempSet,
                TempActual = tempActual,
                HumiditySet = humiditySet,
                HumidityActual = humidityActual,
                Status = isOn ? 1.0 : 0.0
            };

            _samples.Add(sample);
            TrimAndCompactHistory(timestamp);

            if (!_probeTime.HasValue)
                UpdateValueGrid(sample, false);

            _chartDirty = true;
        }

        internal void SetSamplingMode(string samplingText, bool autoGetEnabled)
        {
            _samplingLabel.Text = autoGetEnabled
                ? "Source: Auto Get  |  Sampling: " + samplingText
                : "Source: Hold last value  |  Sampling: " + samplingText;
        }

        internal void RefreshNow()
        {
            if (_samples.Count == 0)
                return;

            _chartDirty = false;
            RefreshChart();
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;
            _renderTimer.Stop();
            _renderTimer.Tick -= RenderTimer_Tick;
            _renderTimer.Dispose();
            _chart.MouseDown -= Chart_MouseDown;
            _chart.MouseUp -= Chart_MouseUp;
            _timeDivCombo.SelectedIndexChanged -= TimeDivCombo_SelectedIndexChanged;
            _autoFollowCheck.CheckedChanged -= AutoFollowCheck_CheckedChanged;
            _resetButton.Click -= ResetButton_Click;
            _valueGrid.CellValueChanged -= ValueGrid_CellValueChanged;
            _valueGrid.CurrentCellDirtyStateChanged -= ValueGrid_CurrentCellDirtyStateChanged;
        }

        private static void ConfigureInteractiveArea(ChartArea area)
        {
            area.CursorX.IsUserEnabled = true;
            area.CursorX.IsUserSelectionEnabled = true;
            area.CursorX.SelectionColor = Color.FromArgb(80, 25, 115, 220);
            area.CursorX.LineColor = Color.FromArgb(40, 55, 75);
            area.CursorX.LineDashStyle = ChartDashStyle.Dash;
            area.CursorY.IsUserEnabled = true;
            area.CursorY.IsUserSelectionEnabled = true;
            area.CursorY.SelectionColor = Color.FromArgb(55, 25, 115, 220);
            area.CursorY.LineColor = Color.FromArgb(40, 55, 75);
            area.CursorY.LineDashStyle = ChartDashStyle.Dash;
            area.AxisX.ScaleView.Zoomable = true;
            area.AxisY.ScaleView.Zoomable = true;
        }

        private void PopulateValueGrid()
        {
            _updatingGrid = true;
            try
            {
                _valueGrid.Rows.Clear();
                AddValueRow("Temp Set");
                AddValueRow("Temp Actual");
                AddValueRow("Humi Set");
                AddValueRow("Humi Actual");
                AddValueRow("On/Off Status");
            }
            finally
            {
                _updatingGrid = false;
            }
        }

        private void AddValueRow(string signalName)
        {
            int rowIndex = _valueGrid.Rows.Add(true, signalName, "--", "--");
            DataGridViewRow row = _valueGrid.Rows[rowIndex];
            row.Tag = signalName;
            Color color;
            if (!_seriesColors.TryGetValue(signalName, out color))
                color = Color.Black;
            row.DefaultCellStyle.ForeColor = color;
            row.DefaultCellStyle.SelectionForeColor = color;
            row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 235, 248);
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            if (!_chartDirty || !_workspace.Visible || _disposed)
                return;
            RefreshNow();
        }

        private void RefreshChart()
        {
            GraphSample latest = _samples[_samples.Count - 1];
            TimeSpan visibleSpan = GetVisibleSpan();
            DateTime visibleStart = latest.Timestamp - visibleSpan;
            DateTime visibleEnd = latest.Timestamp;
            int firstIndex = FindFirstIndexAtOrAfter(visibleStart);
            int visibleCount = _samples.Count - firstIndex;
            int step = Math.Max(1, (int)Math.Ceiling(visibleCount / (double)MaxRenderedSamples));

            foreach (Series series in _chart.Series)
                series.Points.Clear();
            for (int i = firstIndex; i < _samples.Count; i += step)
                AppendRenderedPoint(_samples[i], visibleStart, visibleEnd, visibleSpan == MaximumHistory);
            if ((_samples.Count - 1 - firstIndex) % step != 0)
                AppendRenderedPoint(latest, visibleStart, visibleEnd, visibleSpan == MaximumHistory);

            ChartArea valuesArea = _chart.ChartAreas["Values"];
            ChartArea statusArea = _chart.ChartAreas["Status"];
            ConfigureTimeView(valuesArea, visibleStart, visibleEnd, visibleSpan);
            ConfigureTimeView(statusArea, visibleStart, visibleEnd, visibleSpan);
            if (_probeTime.HasValue)
            {
                double probeX = _probeTime.Value.ToOADate();
                valuesArea.CursorX.Position = probeX;
                statusArea.CursorX.Position = probeX;
            }
            _chart.Invalidate();
        }

        private void AppendRenderedPoint(GraphSample sample, DateTime start, DateTime end, bool fadeHistory)
        {
            AddPoint("Temp Set", sample.Timestamp, sample.TempSet, start, end, fadeHistory);
            AddPoint("Temp Actual", sample.Timestamp, sample.TempActual, start, end, fadeHistory);
            AddPoint("Humi Set", sample.Timestamp, sample.HumiditySet, start, end, fadeHistory);
            AddPoint("Humi Actual", sample.Timestamp, sample.HumidityActual, start, end, fadeHistory);
            AddPoint("On/Off Status", sample.Timestamp, sample.Status, start, end, fadeHistory);
        }

        private void AddPoint(string seriesName, DateTime timestamp, double value,
            DateTime start, DateTime end, bool fadeHistory)
        {
            Series series = _chart.Series[seriesName];
            int index = series.Points.AddXY(timestamp.ToOADate(), value);
            series.Points[index].Color = fadeHistory
                ? GetFadedColor(_seriesColors[seriesName], timestamp, start, end)
                : _seriesColors[seriesName];
        }

        private static Color GetFadedColor(Color baseColor, DateTime timestamp, DateTime start, DateTime end)
        {
            double range = Math.Max(1.0, (end - start).TotalMilliseconds);
            double ageRatio = Math.Max(0.0, Math.Min(1.0, (timestamp - start).TotalMilliseconds / range));
            double whiteMix = 0.72 * (1.0 - ageRatio);
            int red = (int)Math.Round(baseColor.R + ((255 - baseColor.R) * whiteMix));
            int green = (int)Math.Round(baseColor.G + ((255 - baseColor.G) * whiteMix));
            int blue = (int)Math.Round(baseColor.B + ((255 - baseColor.B) * whiteMix));
            return Color.FromArgb(red, green, blue);
        }

        private void ConfigureTimeView(ChartArea area, DateTime start, DateTime end, TimeSpan span)
        {
            Axis axis = area.AxisX;
            axis.LabelStyle.Format = span.TotalHours >= 12 ? "dd/MM HH:mm" : "HH:mm:ss";
            axis.IntervalType = span.TotalHours >= 2 ? DateTimeIntervalType.Hours : DateTimeIntervalType.Minutes;
            axis.Interval = span.TotalHours >= 2
                ? Math.Max(1.0, span.TotalHours / 10.0)
                : Math.Max(0.1, span.TotalMinutes / 10.0);
            if (_autoFollowCheck.Checked && !axis.ScaleView.IsZoomed)
            {
                axis.Minimum = start.ToOADate();
                axis.Maximum = Math.Max(start.AddSeconds(1).ToOADate(), end.ToOADate());
            }
        }

        private void UpdateValueGrid(GraphSample sample, bool isProbe)
        {
            if (_valueGrid.Rows.Count < 5)
                return;
            _updatingGrid = true;
            try
            {
                string x = sample.Timestamp.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture);
                SetGridValue(0, x, sample.TempSet.ToString("0.0", CultureInfo.InvariantCulture) + " °C");
                SetGridValue(1, x, sample.TempActual.ToString("0.0", CultureInfo.InvariantCulture) + " °C");
                SetGridValue(2, x, sample.HumiditySet.ToString("0.0", CultureInfo.InvariantCulture) + " %RH");
                SetGridValue(3, x, sample.HumidityActual.ToString("0.0", CultureInfo.InvariantCulture) + " %RH");
                SetGridValue(4, x, sample.Status >= 0.5 ? "ON (1)" : "OFF (0)");
                _probeLabel.Text = isProbe
                    ? "Probe: " + sample.Timestamp.ToString("dd/MM/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) +
                      "\r\nT " + sample.TempActual.ToString("0.0", CultureInfo.InvariantCulture) + " °C  |  H " +
                      sample.HumidityActual.ToString("0.0", CultureInfo.InvariantCulture) + " %RH  |  " +
                      (sample.Status >= 0.5 ? "ON" : "OFF")
                    : "Latest: " + sample.Timestamp.ToString("dd/MM/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) +
                      "\r\nClick the graph to probe a point.";
            }
            finally
            {
                _updatingGrid = false;
            }
        }

        private void SetGridValue(int row, string x, string y)
        {
            _valueGrid.Rows[row].Cells["X"].Value = x;
            _valueGrid.Rows[row].Cells["Y"].Value = y;
        }

        private void Chart_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _mouseDownPoint = e.Location;
        }

        private void Chart_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || _samples.Count == 0)
                return;
            int delta = Math.Abs(e.X - _mouseDownPoint.X) + Math.Abs(e.Y - _mouseDownPoint.Y);
            if (delta > 6)
            {
                _autoFollowCheck.Checked = false;
                _probeLabel.Text = "Zoomed view\r\nUse Reset View to return to the normal axes.";
                return;
            }

            HitTestResult hit = _chart.HitTest(e.X, e.Y);
            ChartArea area = hit.ChartArea ?? _chart.ChartAreas["Values"];
            try
            {
                DateTime clickedTime = DateTime.FromOADate(area.AxisX.PixelPositionToValue(e.X));
                GraphSample nearest = FindNearestSample(clickedTime);
                _autoFollowCheck.Checked = false;
                _probeTime = nearest.Timestamp;
                UpdateValueGrid(nearest, true);
                foreach (ChartArea chartArea in _chart.ChartAreas)
                    chartArea.CursorX.Position = nearest.Timestamp.ToOADate();
                _chart.Invalidate();
            }
            catch (ArgumentException)
            {
                // Click was outside the plotting area.
            }
        }

        private void TimeDivCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetView(true);
            _chartDirty = true;
        }

        private void AutoFollowCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (_autoFollowCheck.Checked)
            {
                foreach (ChartArea area in _chart.ChartAreas)
                    area.AxisX.ScaleView.ZoomReset(0);
            }
            _chartDirty = true;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ResetView(true);
            _chartDirty = true;
        }

        private void ResetView(bool enableAutoFollow)
        {
            foreach (ChartArea area in _chart.ChartAreas)
            {
                area.AxisX.ScaleView.ZoomReset(0);
                area.AxisY.ScaleView.ZoomReset(0);
                if (area.AxisY2.Enabled != AxisEnabled.False)
                    area.AxisY2.ScaleView.ZoomReset(0);
                area.CursorX.Position = double.NaN;
                area.CursorY.Position = double.NaN;
            }
            _probeTime = null;
            if (enableAutoFollow)
                _autoFollowCheck.Checked = true;
            if (_samples.Count > 0)
                UpdateValueGrid(_samples[_samples.Count - 1], false);
        }

        private void ValueGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (_valueGrid.IsCurrentCellDirty)
                _valueGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void ValueGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_updatingGrid || e.RowIndex < 0 || e.ColumnIndex != _valueGrid.Columns["Visible"].Index)
                return;
            string signalName = Convert.ToString(_valueGrid.Rows[e.RowIndex].Tag, CultureInfo.InvariantCulture);
            bool visible = Convert.ToBoolean(_valueGrid.Rows[e.RowIndex].Cells["Visible"].Value, CultureInfo.InvariantCulture);
            Series series = _chart.Series.FindByName(signalName);
            if (series != null)
                series.Enabled = visible;
        }

        private TimeSpan GetVisibleSpan()
        {
            switch (Convert.ToString(_timeDivCombo.SelectedItem, CultureInfo.InvariantCulture))
            {
                case "10 s": return TimeSpan.FromSeconds(100);
                case "30 s": return TimeSpan.FromMinutes(5);
                case "1 min": return TimeSpan.FromMinutes(10);
                case "5 min": return TimeSpan.FromMinutes(50);
                case "10 min": return TimeSpan.FromMinutes(100);
                case "30 min": return TimeSpan.FromHours(5);
                case "1 hr": return TimeSpan.FromHours(10);
                case "6 hr": return TimeSpan.FromHours(24);
                default: return MaximumHistory;
            }
        }

        private int FindFirstIndexAtOrAfter(DateTime timestamp)
        {
            int low = 0;
            int high = _samples.Count - 1;
            int answer = _samples.Count;
            while (low <= high)
            {
                int mid = low + ((high - low) / 2);
                if (_samples[mid].Timestamp >= timestamp)
                {
                    answer = mid;
                    high = mid - 1;
                }
                else
                    low = mid + 1;
            }
            return answer == _samples.Count ? Math.Max(0, _samples.Count - 1) : answer;
        }

        private GraphSample FindNearestSample(DateTime timestamp)
        {
            int index = FindFirstIndexAtOrAfter(timestamp);
            if (index <= 0)
                return _samples[0];
            if (index >= _samples.Count)
                return _samples[_samples.Count - 1];
            GraphSample before = _samples[index - 1];
            GraphSample after = _samples[index];
            return Math.Abs((timestamp - before.Timestamp).Ticks) <= Math.Abs((after.Timestamp - timestamp).Ticks)
                ? before
                : after;
        }

        private void TrimAndCompactHistory(DateTime newestTimestamp)
        {
            DateTime cutoff = newestTimestamp - MaximumHistory;
            int removeCount = FindFirstIndexAtOrAfter(cutoff);
            if (removeCount > 0)
                _samples.RemoveRange(0, removeCount);
            if (_samples.Count <= MaxStoredSamples)
                return;
            int recentStart = _samples.Count - (MaxStoredSamples / 3);
            List<GraphSample> compacted = new List<GraphSample>(MaxStoredSamples);
            for (int i = 0; i < recentStart; i += 2)
                compacted.Add(_samples[i]);
            for (int i = recentStart; i < _samples.Count; i++)
                compacted.Add(_samples[i]);
            _samples.Clear();
            _samples.AddRange(compacted);
        }

        private sealed class GraphSample
        {
            internal DateTime Timestamp;
            internal double TempSet;
            internal double TempActual;
            internal double HumiditySet;
            internal double HumidityActual;
            internal double Status;
        }
    }
}
