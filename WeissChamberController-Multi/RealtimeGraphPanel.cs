using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Form1
{
    /// <summary>
    /// Collapsible real-time trend workspace for the Multi chamber controller.
    /// The control intentionally uses the .NET Framework chart component so the
    /// application remains self-contained and compatible with .NET Framework 4.5.
    /// </summary>
    internal sealed class RealtimeGraphPanel : UserControl
    {
        private const int MaxStoredSamples = 30000;
        private const int MaxRenderedSamples = 4000;
        private static readonly TimeSpan MaximumHistory = TimeSpan.FromDays(1);

        private readonly List<GraphSample> _samples = new List<GraphSample>();
        private readonly Chart _chart;
        private readonly DataGridView _valueGrid;
        private ComboBox _timeDivCombo;
        private CheckBox _autoFollowCheck;
        private readonly Label _probeLabel;
        private Label _samplingLabel;
        private readonly Timer _renderTimer;
        private readonly Dictionary<string, Color> _seriesColors = new Dictionary<string, Color>();

        private bool _chartDirty;
        private bool _updatingGrid;
        private Point _mouseDownPoint;
        private DateTime? _probeTime;

        internal RealtimeGraphPanel()
        {
            BackColor = Color.FromArgb(245, 248, 252);
            BorderStyle = BorderStyle.FixedSingle;
            MinimumSize = new Size(620, 320);

            Panel toolbar = BuildToolbar();
            Controls.Add(toolbar);

            SplitContainer split = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Size = new Size(718, 280),
                FixedPanel = FixedPanel.Panel2,
                IsSplitterFixed = false,
                SplitterDistance = 500,
                SplitterWidth = 4,
                BackColor = Color.FromArgb(210, 219, 232)
            };

            _chart = BuildChart();
            split.Panel1.Padding = new Padding(6, 4, 2, 6);
            split.Panel1.Controls.Add(_chart);

            _valueGrid = BuildValueGrid();
            _probeLabel = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 70,
                Padding = new Padding(8, 6, 6, 4),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(45, 58, 75),
                BorderStyle = BorderStyle.FixedSingle,
                Text = "Probe: click a point on the graph\r\nDrag a rectangle to zoom."
            };

            split.Panel2.Padding = new Padding(2, 4, 6, 6);
            split.Panel2.Controls.Add(_valueGrid);
            split.Panel2.Controls.Add(_probeLabel);
            Controls.Add(split);
            toolbar.BringToFront();

            _renderTimer = new Timer { Interval = 200 };
            _renderTimer.Tick += RenderTimer_Tick;
            _renderTimer.Start();

            PopulateValueGrid();
            _timeDivCombo.SelectedIndex = 8;
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
            if (_samplingLabel == null)
                return;

            _samplingLabel.Text = autoGetEnabled
                ? "Source: Auto Get  |  Sampling: " + samplingText
                : "Source: Hold last value  |  Sampling: " + samplingText;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _renderTimer != null)
            {
                _renderTimer.Stop();
                _renderTimer.Dispose();
            }

            base.Dispose(disposing);
        }

        private Panel BuildToolbar()
        {
            Panel toolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 36,
                BackColor = Color.FromArgb(9, 45, 112)
            };

            Label title = new Label
            {
                AutoSize = true,
                Location = new Point(10, 10),
                ForeColor = Color.White,
                Font = new Font(Font.FontFamily, 9F, FontStyle.Bold),
                Text = "SIGNAL WORKSPACE"
            };

            Label timeDivLabel = new Label
            {
                AutoSize = true,
                Location = new Point(142, 11),
                ForeColor = Color.White,
                Text = "Time/Div"
            };

            _timeDivCombo = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(198, 7),
                Width = 94
            };
            _timeDivCombo.Items.AddRange(new object[]
            {
                "10 s", "30 s", "1 min", "5 min", "10 min", "30 min", "1 hr", "6 hr", "All (24 hr)"
            });
            _timeDivCombo.SelectedIndexChanged += TimeDivCombo_SelectedIndexChanged;

            _autoFollowCheck = new CheckBox
            {
                AutoSize = true,
                Checked = true,
                Location = new Point(302, 9),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Text = "Auto Follow"
            };
            _autoFollowCheck.CheckedChanged += AutoFollowCheck_CheckedChanged;

            Button resetButton = new Button
            {
                Location = new Point(392, 5),
                Size = new Size(82, 26),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(9, 45, 112),
                Text = "Reset View"
            };
            resetButton.FlatAppearance.BorderColor = Color.FromArgb(154, 184, 224);
            resetButton.Click += ResetButton_Click;

            _samplingLabel = new Label
            {
                AutoEllipsis = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(482, 10),
                Size = new Size(230, 18),
                ForeColor = Color.FromArgb(210, 230, 255),
                TextAlign = ContentAlignment.TopRight,
                Text = "Source: Hold last value  |  Sampling: 10s"
            };

            toolbar.Controls.Add(title);
            toolbar.Controls.Add(timeDivLabel);
            toolbar.Controls.Add(_timeDivCombo);
            toolbar.Controls.Add(_autoFollowCheck);
            toolbar.Controls.Add(resetButton);
            toolbar.Controls.Add(_samplingLabel);
            return toolbar;
        }

        private Chart BuildChart()
        {
            Chart chart = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                BorderlineColor = Color.FromArgb(180, 190, 205),
                BorderlineDashStyle = ChartDashStyle.Solid,
                BorderlineWidth = 1,
                AntiAliasing = AntiAliasingStyles.All,
                TextAntiAliasingQuality = TextAntiAliasingQuality.High
            };

            ChartArea valuesArea = new ChartArea("Values")
            {
                Position = new ElementPosition(0F, 0F, 100F, 75F),
                InnerPlotPosition = new ElementPosition(10F, 7F, 82F, 82F),
                BackColor = Color.White
            };
            ConfigureTimeAxis(valuesArea.AxisX, false);
            valuesArea.AxisY.Title = "Temperature (°C)";
            valuesArea.AxisY.IsStartedFromZero = false;
            valuesArea.AxisY.MajorGrid.LineColor = Color.FromArgb(228, 232, 240);
            valuesArea.AxisY.LineColor = Color.FromArgb(120, 130, 145);
            valuesArea.AxisY.LabelStyle.ForeColor = Color.FromArgb(90, 35, 35);
            valuesArea.AxisY2.Enabled = AxisEnabled.True;
            valuesArea.AxisY2.Title = "Humidity (%RH)";
            valuesArea.AxisY2.Minimum = 0;
            valuesArea.AxisY2.Maximum = 100;
            valuesArea.AxisY2.Interval = 20;
            valuesArea.AxisY2.MajorGrid.Enabled = false;
            valuesArea.AxisY2.LineColor = Color.FromArgb(120, 130, 145);
            valuesArea.AxisY2.LabelStyle.ForeColor = Color.FromArgb(35, 75, 130);
            ConfigureInteractiveArea(valuesArea);

            ChartArea statusArea = new ChartArea("Status")
            {
                Position = new ElementPosition(0F, 74F, 100F, 26F),
                InnerPlotPosition = new ElementPosition(10F, 5F, 82F, 66F),
                AlignWithChartArea = "Values",
                AlignmentOrientation = AreaAlignmentOrientations.Vertical,
                BackColor = Color.White
            };
            ConfigureTimeAxis(statusArea.AxisX, true);
            statusArea.AxisY.Title = "Status";
            statusArea.AxisY.Minimum = 0;
            statusArea.AxisY.Maximum = 1;
            statusArea.AxisY.Interval = 1;
            statusArea.AxisY.CustomLabels.Add(-0.35, 0.35, "OFF");
            statusArea.AxisY.CustomLabels.Add(0.65, 1.35, "ON");
            statusArea.AxisY.MajorGrid.LineColor = Color.FromArgb(235, 238, 244);
            statusArea.AxisY.LineColor = Color.FromArgb(120, 130, 145);
            statusArea.AxisY2.Enabled = AxisEnabled.False;
            ConfigureInteractiveArea(statusArea);

            chart.ChartAreas.Add(valuesArea);
            chart.ChartAreas.Add(statusArea);

            // Line (rather than FastLine) is used so each historical point can
            // carry its own progressively lighter color in the 24-hour view.
            AddSeries(chart, "Temp Set", "Values", Color.Firebrick, AxisType.Primary, SeriesChartType.Line);
            AddSeries(chart, "Temp Actual", "Values", Color.DarkOrange, AxisType.Primary, SeriesChartType.Line);
            AddSeries(chart, "Humi Set", "Values", Color.RoyalBlue, AxisType.Secondary, SeriesChartType.Line);
            AddSeries(chart, "Humi Actual", "Values", Color.DeepSkyBlue, AxisType.Secondary, SeriesChartType.Line);
            AddSeries(chart, "On/Off Status", "Status", Color.Black, AxisType.Primary, SeriesChartType.StepLine);

            chart.MouseDown += Chart_MouseDown;
            chart.MouseUp += Chart_MouseUp;
            return chart;
        }

        private static void ConfigureTimeAxis(Axis axis, bool showLabels)
        {
            axis.LabelStyle.Enabled = showLabels;
            axis.LabelStyle.Format = "HH:mm:ss";
            axis.LabelStyle.Angle = -30;
            axis.MajorGrid.LineColor = Color.FromArgb(228, 232, 240);
            axis.LineColor = Color.FromArgb(120, 130, 145);
            axis.ScaleView.Zoomable = true;
            axis.ScrollBar.Enabled = true;
            axis.ScrollBar.IsPositionedInside = true;
            axis.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
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
            area.AxisY.ScaleView.Zoomable = true;
        }

        private void AddSeries(Chart chart, string name, string chartArea, Color color,
            AxisType yAxisType, SeriesChartType chartType)
        {
            Series series = new Series(name)
            {
                ChartArea = chartArea,
                ChartType = chartType,
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double,
                YAxisType = yAxisType,
                BorderWidth = 2,
                Color = color,
                IsVisibleInLegend = false
            };
            chart.Series.Add(series);
            _seriesColors[name] = color;
        }

        private DataGridView BuildValueGrid()
        {
            DataGridView grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                EditMode = DataGridViewEditMode.EditOnEnter
            };

            grid.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Visible",
                HeaderText = "Show",
                FillWeight = 35,
                TrueValue = true,
                FalseValue = false
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Signal",
                HeaderText = "Signal",
                ReadOnly = true,
                FillWeight = 90
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "X",
                HeaderText = "X",
                ReadOnly = true,
                FillWeight = 68
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Y",
                HeaderText = "Y",
                ReadOnly = true,
                FillWeight = 52
            });

            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(225, 234, 246);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 48, 75);
            grid.ColumnHeadersDefaultCellStyle.Font = new Font(grid.Font, FontStyle.Bold);
            grid.EnableHeadersVisualStyles = false;
            grid.CellValueChanged += ValueGrid_CellValueChanged;
            grid.CurrentCellDirtyStateChanged += ValueGrid_CurrentCellDirtyStateChanged;
            return grid;
        }

        private void PopulateValueGrid()
        {
            _updatingGrid = true;
            try
            {
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
            row.DefaultCellStyle.ForeColor = _seriesColors[signalName];
            row.DefaultCellStyle.SelectionForeColor = _seriesColors[signalName];
            row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 235, 248);
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            if (!_chartDirty || !Visible || IsDisposed)
                return;

            _chartDirty = false;
            RefreshChart();
        }

        private void RefreshChart()
        {
            if (_samples.Count == 0)
                return;

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
                AppendRenderedPoint(_samples[i], visibleStart, visibleEnd);

            if ((_samples.Count - 1 - firstIndex) % step != 0)
                AppendRenderedPoint(latest, visibleStart, visibleEnd);

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

        private void AppendRenderedPoint(GraphSample sample, DateTime start, DateTime end)
        {
            AddPoint("Temp Set", sample.Timestamp, sample.TempSet, start, end);
            AddPoint("Temp Actual", sample.Timestamp, sample.TempActual, start, end);
            AddPoint("Humi Set", sample.Timestamp, sample.HumiditySet, start, end);
            AddPoint("Humi Actual", sample.Timestamp, sample.HumidityActual, start, end);
            AddPoint("On/Off Status", sample.Timestamp, sample.Status, start, end);
        }

        private void AddPoint(string seriesName, DateTime timestamp, double value, DateTime start, DateTime end)
        {
            Series series = _chart.Series[seriesName];
            int index = series.Points.AddXY(timestamp.ToOADate(), value);
            series.Points[index].Color = GetFadedColor(_seriesColors[seriesName], timestamp, start, end);
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
            if (_valueGrid == null || _valueGrid.Rows.Count < 5)
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
            if (e.Button != MouseButtons.Left)
                return;

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
                double xValue = area.AxisX.PixelPositionToValue(e.X);
                DateTime clickedTime = DateTime.FromOADate(xValue);
                GraphSample nearest = FindNearestSample(clickedTime);
                _autoFollowCheck.Checked = false;
                _probeTime = nearest.Timestamp;
                UpdateValueGrid(nearest, true);

                foreach (ChartArea chartArea in _chart.ChartAreas)
                {
                    chartArea.CursorX.SetCursorPosition(nearest.Timestamp.ToOADate());
                    chartArea.CursorX.Position = nearest.Timestamp.ToOADate();
                }

                _chart.Invalidate();
            }
            catch (ArgumentException)
            {
                // The click was outside the plotting area; leave the current probe unchanged.
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
                {
                    low = mid + 1;
                }
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
