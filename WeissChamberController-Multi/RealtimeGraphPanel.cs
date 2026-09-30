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
        private readonly ComboBox _mouseModeCombo;
        private readonly TextBox _tempMinText;
        private readonly TextBox _tempMaxText;
        private readonly TextBox _humidityMinText;
        private readonly TextBox _humidityMaxText;
        private readonly Button _applyYButton;
        private readonly Button _autoYButton;
        private readonly Label _mouseHintLabel;
        private readonly Label _probeLabel;
        private readonly Label _samplingLabel;
        private readonly Timer _renderTimer;
        private readonly Dictionary<string, Color> _seriesColors = new Dictionary<string, Color>();

        private bool _chartDirty;
        private bool _updatingGrid;
        private bool _disposed;
        private Point _mouseDownPoint;
        private Rectangle _selectionRectangle;
        private bool _dragging;
        private bool _selectionFrameVisible;
        private double _panStartMinimum;
        private double _panStartMaximum;
        private DateTime? _probeTime;

        internal RealtimeGraphController(
            Control workspace,
            Chart chart,
            DataGridView valueGrid,
            ComboBox timeDivCombo,
            CheckBox autoFollowCheck,
            Button resetButton,
            ComboBox mouseModeCombo,
            TextBox tempMinText,
            TextBox tempMaxText,
            TextBox humidityMinText,
            TextBox humidityMaxText,
            Button applyYButton,
            Button autoYButton,
            Label mouseHintLabel,
            Label probeLabel,
            Label samplingLabel)
        {
            _workspace = workspace;
            _chart = chart;
            _valueGrid = valueGrid;
            _timeDivCombo = timeDivCombo;
            _autoFollowCheck = autoFollowCheck;
            _resetButton = resetButton;
            _mouseModeCombo = mouseModeCombo;
            _tempMinText = tempMinText;
            _tempMaxText = tempMaxText;
            _humidityMinText = humidityMinText;
            _humidityMaxText = humidityMaxText;
            _applyYButton = applyYButton;
            _autoYButton = autoYButton;
            _mouseHintLabel = mouseHintLabel;
            _probeLabel = probeLabel;
            _samplingLabel = samplingLabel;

            foreach (Series series in _chart.Series)
                _seriesColors[series.Name] = series.Color;

            foreach (ChartArea area in _chart.ChartAreas)
                ConfigureInteractiveArea(area);

            _chart.MouseDown += Chart_MouseDown;
            _chart.MouseMove += Chart_MouseMove;
            _chart.MouseUp += Chart_MouseUp;
            _timeDivCombo.SelectedIndexChanged += TimeDivCombo_SelectedIndexChanged;
            _autoFollowCheck.CheckedChanged += AutoFollowCheck_CheckedChanged;
            _resetButton.Click += ResetButton_Click;
            _mouseModeCombo.SelectedIndexChanged += MouseModeCombo_SelectedIndexChanged;
            _applyYButton.Click += ApplyYButton_Click;
            _autoYButton.Click += AutoYButton_Click;
            _valueGrid.CellValueChanged += ValueGrid_CellValueChanged;
            _valueGrid.CurrentCellDirtyStateChanged += ValueGrid_CurrentCellDirtyStateChanged;

            PopulateValueGrid();
            if (_timeDivCombo.SelectedIndex < 0 && _timeDivCombo.Items.Count > 0)
                _timeDivCombo.SelectedIndex = _timeDivCombo.Items.Count - 1;
            if (_mouseModeCombo.SelectedIndex < 0 && _mouseModeCombo.Items.Count > 0)
                _mouseModeCombo.SelectedIndex = 0;
            UpdateMouseModeUi();

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
            _chart.MouseMove -= Chart_MouseMove;
            _chart.MouseUp -= Chart_MouseUp;
            _timeDivCombo.SelectedIndexChanged -= TimeDivCombo_SelectedIndexChanged;
            _autoFollowCheck.CheckedChanged -= AutoFollowCheck_CheckedChanged;
            _resetButton.Click -= ResetButton_Click;
            _mouseModeCombo.SelectedIndexChanged -= MouseModeCombo_SelectedIndexChanged;
            _applyYButton.Click -= ApplyYButton_Click;
            _autoYButton.Click -= AutoYButton_Click;
            _valueGrid.CellValueChanged -= ValueGrid_CellValueChanged;
            _valueGrid.CurrentCellDirtyStateChanged -= ValueGrid_CurrentCellDirtyStateChanged;
        }

        private static void ConfigureInteractiveArea(ChartArea area)
        {
            area.CursorX.IsUserEnabled = true;
            area.CursorX.IsUserSelectionEnabled = false;
            area.CursorX.SelectionColor = Color.FromArgb(80, 25, 115, 220);
            area.CursorX.LineColor = Color.FromArgb(40, 55, 75);
            area.CursorX.LineDashStyle = ChartDashStyle.Dash;
            area.CursorY.IsUserEnabled = true;
            area.CursorY.IsUserSelectionEnabled = false;
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
            if (!_chartDirty || !_workspace.Visible || _disposed || _dragging)
                return;
            RefreshNow();
        }

        private void RefreshChart()
        {
            GraphSample latest = _samples[_samples.Count - 1];
            TimeSpan visibleSpan = GetVisibleSpan();
            DateTime visibleStart = latest.Timestamp - visibleSpan;
            DateTime visibleEnd = latest.Timestamp;
            DateTime historyStart = latest.Timestamp - MaximumHistory;
            int firstIndex = FindFirstIndexAtOrAfter(historyStart);
            int historyCount = _samples.Count - firstIndex;
            int step = Math.Max(1, (int)Math.Ceiling(historyCount / (double)MaxRenderedSamples));
            DateTime axisStart = _samples[firstIndex].Timestamp < visibleStart
                ? _samples[firstIndex].Timestamp
                : visibleStart;

            foreach (Series series in _chart.Series)
                series.Points.Clear();
            for (int i = firstIndex; i < _samples.Count; i += step)
                AppendRenderedPoint(_samples[i], axisStart, visibleEnd, visibleSpan == MaximumHistory);
            if ((_samples.Count - 1 - firstIndex) % step != 0)
                AppendRenderedPoint(latest, axisStart, visibleEnd, visibleSpan == MaximumHistory);

            ChartArea valuesArea = _chart.ChartAreas["Values"];
            ChartArea statusArea = _chart.ChartAreas["Status"];
            ConfigureTimeView(valuesArea, axisStart, visibleStart, visibleEnd, visibleSpan);
            ConfigureTimeView(statusArea, axisStart, visibleStart, visibleEnd, visibleSpan);
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

        private void ConfigureTimeView(ChartArea area, DateTime dataStart, DateTime viewStart,
            DateTime end, TimeSpan span)
        {
            Axis axis = area.AxisX;
            bool preserveView = !_autoFollowCheck.Checked && axis.ScaleView.IsZoomed;
            double preservedMinimum = preserveView ? axis.ScaleView.ViewMinimum : double.NaN;
            double preservedMaximum = preserveView ? axis.ScaleView.ViewMaximum : double.NaN;
            axis.IsMarginVisible = false;
            axis.LabelStyle.Angle = 0;
            axis.LabelStyle.IsEndLabelVisible = false;

            if (span.TotalMinutes <= 10)
            {
                axis.LabelStyle.Format = "HH:mm:ss";
                axis.IntervalType = DateTimeIntervalType.Seconds;
                axis.Interval = Math.Max(1.0, Math.Ceiling(span.TotalSeconds / 5.0));
            }
            else if (span.TotalHours <= 6)
            {
                axis.LabelStyle.Format = "HH:mm";
                axis.IntervalType = DateTimeIntervalType.Minutes;
                axis.Interval = Math.Max(1.0, Math.Ceiling(span.TotalMinutes / 5.0));
            }
            else
            {
                axis.LabelStyle.Format = span.TotalHours >= 24 ? "dd/MM HH:mm" : "HH:mm";
                axis.IntervalType = DateTimeIntervalType.Hours;
                axis.Interval = Math.Max(1.0, Math.Ceiling(span.TotalHours / 5.0));
            }

            double dataMinimum = dataStart.ToOADate();
            double dataMaximum = Math.Max(dataStart.AddSeconds(1).ToOADate(), end.ToOADate());
            axis.Minimum = dataMinimum;
            axis.Maximum = dataMaximum;
            if (_autoFollowCheck.Checked)
            {
                // Move the existing view instead of resetting zoom on every sample.
                // Resetting briefly removes the scrollbar and changes plot geometry.
                SetTimeWindow(axis, viewStart.ToOADate(), end.ToOADate());
            }
            else if (preserveView)
            {
                double viewWidth = preservedMaximum - preservedMinimum;
                double minimum = Math.Max(dataMinimum, preservedMinimum);
                double maximum = minimum + viewWidth;
                if (maximum > dataMaximum)
                {
                    maximum = dataMaximum;
                    minimum = Math.Max(dataMinimum, maximum - viewWidth);
                }
                if (maximum > minimum)
                    SetTimeWindow(axis, minimum, maximum);
            }
        }

        private static void SetTimeWindow(Axis axis, double minimum, double maximum)
        {
            double width = maximum - minimum;
            if (width <= 0 || double.IsNaN(width) || double.IsInfinity(width))
                return;

            AxisScaleView view = axis.ScaleView;
            double currentWidth = view.ViewMaximum - view.ViewMinimum;
            if (view.IsZoomed && Math.Abs(currentWidth - width) < 1e-8)
            {
                // Scroll preserves the zoom size, scrollbar and zoom history.
                view.Scroll(minimum);
            }
            else
            {
                // Realtime updates must not accumulate a saved zoom per sample.
                view.Zoom(minimum, width, DateTimeIntervalType.Number, false);
            }
        }

        private void UpdateValueGrid(GraphSample sample, bool isProbe)
        {
            if (_valueGrid.Rows.Count < 5)
                return;
            _updatingGrid = true;
            try
            {
                // Milliseconds stay available in the probe details, while the
                // compact table uses seconds so the fixed-width columns stay tidy.
                string x = sample.Timestamp.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
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
                    : "Latest: " + sample.Timestamp.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
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
            if (e.Button != MouseButtons.Left || _samples.Count == 0)
                return;

            Rectangle plotRectangle = GetValuesPlotRectangle();
            if (!plotRectangle.Contains(e.Location))
                return;

            _mouseDownPoint = e.Location;
            _dragging = true;
            _chart.Capture = true;

            if (IsPanMode())
            {
                Axis axis = _chart.ChartAreas["Values"].AxisX;
                try
                {
                    _panStartMinimum = axis.ScaleView.ViewMinimum;
                    _panStartMaximum = axis.ScaleView.ViewMaximum;
                }
                catch (ArgumentException)
                {
                    _dragging = false;
                    _chart.Capture = false;
                }
            }
            else
            {
                _selectionRectangle = new Rectangle(e.Location, Size.Empty);
            }
        }

        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_dragging)
                return;

            if (IsPanMode())
            {
                PanChart(e.X);
                return;
            }

            if (_selectionFrameVisible)
                ToggleSelectionFrame();

            Point current = ClampToRectangle(e.Location, GetValuesPlotRectangle());
            _selectionRectangle = NormalizeRectangle(_mouseDownPoint, current);
            if (_selectionRectangle.Width > 1 && _selectionRectangle.Height > 1)
            {
                ToggleSelectionFrame();
                _selectionFrameVisible = true;
            }
        }

        private void Chart_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || !_dragging)
                return;

            _dragging = false;
            _chart.Capture = false;

            if (IsPanMode())
            {
                _probeLabel.Text = "Pan view\r\nDrag again or use Reset View / Auto Follow.";
                return;
            }

            if (_selectionFrameVisible)
            {
                ToggleSelectionFrame();
                _selectionFrameVisible = false;
            }

            if (_selectionRectangle.Width >= 8 && _selectionRectangle.Height >= 8)
            {
                ApplyRectangleZoom(_selectionRectangle);
                _selectionRectangle = Rectangle.Empty;
                return;
            }

            ProbeAt(e.Location);
            _selectionRectangle = Rectangle.Empty;
        }

        private void ProbeAt(Point location)
        {
            ChartArea area = _chart.ChartAreas["Values"];
            try
            {
                DateTime clickedTime = DateTime.FromOADate(area.AxisX.PixelPositionToValue(location.X));
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

        private void ApplyRectangleZoom(Rectangle rectangle)
        {
            ChartArea valuesArea = _chart.ChartAreas["Values"];
            try
            {
                double x1 = valuesArea.AxisX.PixelPositionToValue(rectangle.Left);
                double x2 = valuesArea.AxisX.PixelPositionToValue(rectangle.Right);
                double y1 = valuesArea.AxisY.PixelPositionToValue(rectangle.Bottom);
                double y2 = valuesArea.AxisY.PixelPositionToValue(rectangle.Top);
                double y21 = valuesArea.AxisY2.PixelPositionToValue(rectangle.Bottom);
                double y22 = valuesArea.AxisY2.PixelPositionToValue(rectangle.Top);

                ApplyXZoom(Math.Min(x1, x2), Math.Max(x1, x2));
                valuesArea.AxisY.ScaleView.Zoom(Math.Min(y1, y2), Math.Max(y1, y2));
                valuesArea.AxisY2.ScaleView.Zoom(Math.Min(y21, y22), Math.Max(y21, y22));
                _autoFollowCheck.Checked = false;
                _probeTime = null;
                _probeLabel.Text = "Rectangle zoom active\r\nChoose Pan Hand to move, or Reset View to restore.";
                _chart.Invalidate();
            }
            catch (ArgumentException)
            {
                _probeLabel.Text = "Zoom area is outside the graph plot.";
            }
        }

        private void PanChart(int mouseX)
        {
            ChartArea valuesArea = _chart.ChartAreas["Values"];
            Axis axis = valuesArea.AxisX;
            try
            {
                double viewWidth = _panStartMaximum - _panStartMinimum;
                double delta = (_mouseDownPoint.X - mouseX) * viewWidth /
                    Math.Max(1.0, GetValuesPlotRectangle().Width);
                double minimum = _panStartMinimum + delta;
                double maximum = _panStartMaximum + delta;
                double dataMinimum = axis.Minimum;
                double dataMaximum = axis.Maximum;

                if (minimum < dataMinimum)
                {
                    minimum = dataMinimum;
                    maximum = minimum + viewWidth;
                }
                if (maximum > dataMaximum)
                {
                    maximum = dataMaximum;
                    minimum = maximum - viewWidth;
                }

                _autoFollowCheck.Checked = false;
                ApplyXZoom(minimum, maximum);
                _chart.Invalidate();
            }
            catch (ArgumentException)
            {
                // Ignore a drag that leaves the plotting area.
            }
        }

        private void ApplyXZoom(double minimum, double maximum)
        {
            if (double.IsNaN(minimum) || double.IsNaN(maximum) ||
                double.IsInfinity(minimum) || double.IsInfinity(maximum) || maximum <= minimum)
                return;

            foreach (ChartArea area in _chart.ChartAreas)
                SetTimeWindow(area.AxisX, minimum, maximum);
        }

        private Rectangle GetValuesPlotRectangle()
        {
            ChartArea area = _chart.ChartAreas["Values"];
            ElementPosition outer = area.Position;
            ElementPosition inner = area.InnerPlotPosition;
            int x = (int)Math.Round(_chart.ClientSize.Width *
                (outer.X + (outer.Width * inner.X / 100F)) / 100F);
            int y = (int)Math.Round(_chart.ClientSize.Height *
                (outer.Y + (outer.Height * inner.Y / 100F)) / 100F);
            int width = (int)Math.Round(_chart.ClientSize.Width *
                (outer.Width * inner.Width / 100F) / 100F);
            int height = (int)Math.Round(_chart.ClientSize.Height *
                (outer.Height * inner.Height / 100F) / 100F);
            return new Rectangle(x, y, Math.Max(1, width), Math.Max(1, height));
        }

        private static Point ClampToRectangle(Point point, Rectangle bounds)
        {
            return new Point(
                Math.Max(bounds.Left, Math.Min(bounds.Right - 1, point.X)),
                Math.Max(bounds.Top, Math.Min(bounds.Bottom - 1, point.Y)));
        }

        private static Rectangle NormalizeRectangle(Point first, Point second)
        {
            return Rectangle.FromLTRB(
                Math.Min(first.X, second.X),
                Math.Min(first.Y, second.Y),
                Math.Max(first.X, second.X),
                Math.Max(first.Y, second.Y));
        }

        private void ToggleSelectionFrame()
        {
            Rectangle screenRectangle = _chart.RectangleToScreen(_selectionRectangle);
            ControlPaint.DrawReversibleFrame(screenRectangle, Color.Black, FrameStyle.Dashed);
        }

        private void TimeDivCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetView(true);
            _chartDirty = true;
        }

        private void MouseModeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectionFrameVisible)
            {
                ToggleSelectionFrame();
                _selectionFrameVisible = false;
            }
            _dragging = false;
            _selectionRectangle = Rectangle.Empty;
            UpdateMouseModeUi();
        }

        private bool IsPanMode()
        {
            return _mouseModeCombo.SelectedIndex == 1;
        }

        private void UpdateMouseModeUi()
        {
            bool panMode = IsPanMode();
            _chart.Cursor = panMode ? Cursors.Hand : Cursors.Cross;
            _mouseHintLabel.Text = panMode
                ? "Drag: move graph"
                : "Drag: rectangle zoom";
            _probeLabel.Text = panMode
                ? "Pan Hand: drag left or right to move through history."
                : "Zoom Box: drag a rectangle, or click to probe a point.";
        }

        private void ApplyYButton_Click(object sender, EventArgs e)
        {
            double tempMinimum;
            double tempMaximum;
            double humidityMinimum;
            double humidityMaximum;
            if (!TryParseAxisValue(_tempMinText.Text, out tempMinimum) ||
                !TryParseAxisValue(_tempMaxText.Text, out tempMaximum) ||
                !TryParseAxisValue(_humidityMinText.Text, out humidityMinimum) ||
                !TryParseAxisValue(_humidityMaxText.Text, out humidityMaximum))
            {
                _probeLabel.Text = "Y axis error: enter numeric Min/Max values.";
                return;
            }

            if (tempMinimum >= tempMaximum || humidityMinimum >= humidityMaximum)
            {
                _probeLabel.Text = "Y axis error: each Min value must be lower than Max.";
                return;
            }

            ChartArea area = _chart.ChartAreas["Values"];
            area.AxisY.ScaleView.ZoomReset(0);
            area.AxisY2.ScaleView.ZoomReset(0);
            area.AxisY.Minimum = double.NaN;
            area.AxisY.Maximum = double.NaN;
            area.AxisY2.Minimum = double.NaN;
            area.AxisY2.Maximum = double.NaN;
            area.AxisY.Minimum = tempMinimum;
            area.AxisY.Maximum = tempMaximum;
            area.AxisY.Interval = 0D;
            area.AxisY2.Minimum = humidityMinimum;
            area.AxisY2.Maximum = humidityMaximum;
            area.AxisY2.Interval = 0D;
            _probeLabel.Text = string.Format(CultureInfo.InvariantCulture,
                "Y axes fixed\r\nTemp {0:0.##}…{1:0.##} °C | Humi {2:0.##}…{3:0.##} %RH",
                tempMinimum, tempMaximum, humidityMinimum, humidityMaximum);
            _chart.Invalidate();
        }

        private void AutoYButton_Click(object sender, EventArgs e)
        {
            ChartArea area = _chart.ChartAreas["Values"];
            area.AxisY.ScaleView.ZoomReset(0);
            area.AxisY2.ScaleView.ZoomReset(0);
            area.AxisY.Minimum = double.NaN;
            area.AxisY.Maximum = double.NaN;
            area.AxisY.Interval = 0D;
            area.AxisY2.Minimum = double.NaN;
            area.AxisY2.Maximum = double.NaN;
            area.AxisY2.Interval = 0D;
            _probeLabel.Text = "Y Auto enabled\r\nTemperature and humidity axes follow visible data.";
            _chart.Invalidate();
        }

        private static bool TryParseAxisValue(string text, out double value)
        {
            return double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out value) ||
                   double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        private void AutoFollowCheck_CheckedChanged(object sender, EventArgs e)
        {
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
