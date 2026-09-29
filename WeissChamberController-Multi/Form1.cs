using System;
using System.Collections.Generic;
using System.IO; // StreamWriter และ Path
using System.IO.Ports;
using System.Reflection; // Access Assembly Version
using System.Threading; // CancellationTokenSource
using System.Threading.Tasks;
using System.Windows.Forms;
using static Form1.WeissChamberController;

namespace Form1
{
    public partial class Form1 : Form
    {
        private const string ProgramAuthor = "Patiphan Phakdeeburi.";
        private const string LogHeader = "Timestamp,SetTemp,ActTemp,SetHumi,ActHumi,Status";

        // Chamber controller instance
        private WeissChamberController chamberController = new WeissChamberController();

        // Timer for automatic parameter retrieval
        private System.Windows.Forms.Timer tmrAutoGet;

        // Keeps the graph time axis moving with the last value when Auto Get is disabled.
        private System.Windows.Forms.Timer tmrGraphHold;

        // Timer for closing the current CSV and opening a new one at midnight
        private System.Windows.Forms.Timer tmrLogRollover;

        // Used to cancel running tasks when disconnecting
        private CancellationTokenSource _cancellationTokenSource;

        // Prevents concurrent communication (race condition)
        private bool _isCommunicating = false;

        // Indicates if CSV logging is active
        private bool _isLogging = false;

        private StreamWriter _logWriter;
        private string _logFilePath;
        private DateTime _logFileDate;

        // Stores the log directory path
        private string _logDirectoryPath;

        private RealtimeGraphController _realtimeGraphController;
        private bool _graphExpanded;
        private int _collapsedClientWidth;
        private int _expandedClientWidth;

        private bool _hasGraphReading;
        private double _latestTempSet;
        private double _latestTempActual;
        private double _latestHumiditySet;
        private double _latestHumidityActual;
        private bool _latestChamberStatus;

        private List<string> BlackList = new List<string>();
        private List<string> file_List = new List<string>();

        public Form1()
        {
            InitializeComponent();

            // Keep the expanded graph workspace visible while editing Form1 in
            // the Visual Studio Designer. Runtime-only setup collapses it below.
            if (System.ComponentModel.LicenseManager.UsageMode ==
                System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            InitializeTimer();
            InitializeRealtimeGraph();
            InitializeCommControls();
            UpdateUIStatus(false); // Start with Disconnected status
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addBlackList("delta\\Larry");
            addBlackList("delta\\sutsoboo");

            checkBlackList();
        }

        private void addBlackList(string User)
        {
            BlackList.Add(User.ToLower());
        }

        private void checkBlackList()
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            Console.WriteLine(userName);
            if (BlackList.Contains(userName.ToLower()))
            {
                DialogResult dialogResult = MessageBox.Show(
                    "An internal error occured while installing the service pack." + Environment.NewLine + Environment.NewLine + "Error code: 0x80070002."
                    + Environment.NewLine + Environment.NewLine + "See " + "http://go.microsoft.com/fwlink/?LinkId=101139 for details."
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void InitializeTimer()
        {
            tmrAutoGet = new System.Windows.Forms.Timer();
            tmrAutoGet.Tick += new EventHandler(tmrAutoGet_Tick);
            tmrAutoGet.Interval = 5000; // Default to 5 seconds

            tmrGraphHold = new System.Windows.Forms.Timer();
            tmrGraphHold.Tick += new EventHandler(tmrGraphHold_Tick);
            tmrGraphHold.Interval = 5000;

            tmrLogRollover = new System.Windows.Forms.Timer();
            tmrLogRollover.Tick += new EventHandler(tmrLogRollover_Tick);
        }

        private void InitializeRealtimeGraph()
        {
            // The complete graph layout lives in Form1.Designer.cs so it can be
            // edited visually. At runtime the form starts in its collapsed width.
            _expandedClientWidth = ClientSize.Width;
            _collapsedClientWidth = pnlGraphWorkspace.Left;

            _realtimeGraphController = new RealtimeGraphController(
                pnlGraphWorkspace,
                chartRealtime,
                dgvGraphValues,
                cmbGraphTimeDiv,
                chkGraphAutoFollow,
                btnGraphResetView,
                cmbGraphMouseMode,
                txtGraphTempMin,
                txtGraphTempMax,
                txtGraphHumiMin,
                txtGraphHumiMax,
                btnGraphApplyY,
                btnGraphAutoY,
                lblGraphMouseHint,
                lblGraphProbe,
                lblGraphSampling);

            pnlGraphWorkspace.Visible = false;
            ClientSize = new System.Drawing.Size(_collapsedClientWidth, ClientSize.Height);
            btnGraphTab.BringToFront();
        }

        private void btnGraphTab_Click(object sender, EventArgs e)
        {
            _graphExpanded = !_graphExpanded;
            SuspendLayout();
            pnlGraphWorkspace.Visible = _graphExpanded;
            ClientSize = new System.Drawing.Size(
                _graphExpanded ? _expandedClientWidth : _collapsedClientWidth,
                ClientSize.Height);
            btnGraphTab.Text = _graphExpanded
                ? "G\r\nR\r\nA\r\nP\r\nH\r\n◀"
                : "G\r\nR\r\nA\r\nP\r\nH\r\n▶";
            if (_graphExpanded)
                _realtimeGraphController.RefreshNow();
            ResumeLayout(true);
        }

        private void InitializeCommControls()
        {
            // Populate available serial ports
            string[] ports = SerialPort.GetPortNames();
            cmbPortName.Items.AddRange(ports);
            if (ports.Length > 0)
            {
                cmbPortName.SelectedIndex = 0;
            }

            // Set default baud rate
            txtBaudRate.Text = "9600";

            // Set default setpoints
            txtSetTemp.Text = "23.0";
            txtSetHumidity.Text = "0.0";

            // Set default CSV file name prefix
            txtFileNamePrefix.Text = "TestChamberLog";

            // Single file is the default; Daily file creates a new CSV at midnight
            cmbLogFileMode.Items.AddRange(new object[] { "Single file", "Daily file" });
            cmbLogFileMode.SelectedIndex = 0;

            // Set default log directory path
            _logDirectoryPath = "D:\\Data";
            txtLogPath.Text = _logDirectoryPath;

            // Populate sampling rate options
            cmbSamplingRate.Items.AddRange(new object[]
            {
                    "1ms", "10ms", "100ms", "500ms", "1s", "2s", "5s", "10s", "30s",
                    "1min", "5min", "10min", "30min", "1hr"
            });
            cmbSamplingRate.SelectedIndex = 7; // Default to 10s

            UpdateGraphSamplingState();

            // Default radio mode
            radioSerial.Checked = true;
        }

        private void UpdateUIStatus(bool isConnected)
        {
            btnConnect.Enabled = !isConnected;
            btnDisconnect.Enabled = isConnected;
            cmbPortName.Enabled = !isConnected;
            txtBaudRate.Enabled = !isConnected;

            grpControl.Enabled = isConnected;
            grpMonitoring.Enabled = isConnected;

            chkAutoGet.Enabled = isConnected;
            cmbSamplingRate.Enabled = isConnected;

            if (isConnected)
            {
                chkCsvLogging.Enabled = chkAutoGet.Checked;

                bool logControlsEditable = !_isLogging;
                txtFileNamePrefix.Enabled = logControlsEditable;
                txtLogPath.Enabled = logControlsEditable;
                btnBrowseLogPath.Enabled = logControlsEditable;
                cmbLogFileMode.Enabled = logControlsEditable;
            }
            else
            {
                tmrAutoGet.Stop();
                StopLogging();

                chkAutoGet.Checked = false;
                chkCsvLogging.Enabled = false;

                txtFileNamePrefix.Enabled = true;
                txtLogPath.Enabled = true;
                btnBrowseLogPath.Enabled = true;
                cmbLogFileMode.Enabled = true;
            }

            lblCommStatus.Text = isConnected ? "Connected" : "Disconnected";
            lblCommStatus.BackColor = isConnected ? System.Drawing.Color.LightGreen : System.Drawing.Color.LightGray;

            if (isConnected)
            {
                lblChamberStatus.Text = "OFF";
                lblChamberStatus.BackColor = System.Drawing.Color.LightPink;
                btnEnableChamber.Text = "ON";
            }
            else
            {
                lblChamberStatus.Text = "OFF";
                lblChamberStatus.BackColor = System.Drawing.Color.LightGray;
                btnEnableChamber.Text = "ON";
            }
        }

        private void OpenNewLogFile(DateTime fileTimestamp)
        {
            if (!Directory.Exists(_logDirectoryPath))
                Directory.CreateDirectory(_logDirectoryPath);

            string prefix = txtFileNamePrefix.Text.Trim();
            string timestamp = fileTimestamp.ToString("yyyy-MM-dd_HH-mm-ss");
            string fileName = $"CBLOG_{prefix}_{timestamp}.csv";
            string newLogFilePath = Path.Combine(_logDirectoryPath, fileName);
            StreamWriter newLogWriter = null;

            try
            {
                newLogWriter = new StreamWriter(newLogFilePath, false);
                newLogWriter.WriteLine(LogHeader);
                newLogWriter.Flush();
            }
            catch
            {
                if (newLogWriter != null)
                    newLogWriter.Dispose();
                throw;
            }

            _logWriter = newLogWriter;
            _logFilePath = newLogFilePath;
            _logFileDate = fileTimestamp.Date;
        }

        private void ScheduleNextLogRollover()
        {
            tmrLogRollover.Stop();
            if (!_isLogging || !IsDailyLogFileMode())
                return;

            DateTime now = DateTime.Now;
            double millisecondsUntilMidnight = (now.Date.AddDays(1) - now).TotalMilliseconds;
            tmrLogRollover.Interval = Math.Max(1000, (int)Math.Ceiling(millisecondsUntilMidnight));
            tmrLogRollover.Start();
        }

        private bool IsDailyLogFileMode()
        {
            return cmbLogFileMode.SelectedIndex == 1;
        }

        private void RotateLogFile(DateTime fileTimestamp)
        {
            if (!_isLogging)
                return;

            string previousLogFilePath = _logFilePath;

            try
            {
                StreamWriter previousWriter = _logWriter;
                _logWriter = null;
                if (previousWriter != null)
                    previousWriter.Dispose();

                OpenNewLogFile(fileTimestamp);
                ScheduleNextLogRollover();
                txtErrStr.Text = $"New day detected. Previous file saved at: {previousLogFilePath}. CSV logging continued at: {_logFilePath}";
            }
            catch (Exception ex)
            {
                _isLogging = false;
                tmrLogRollover.Stop();

                if (_logWriter != null)
                {
                    _logWriter.Dispose();
                    _logWriter = null;
                }

                if (chkCsvLogging.Checked)
                    chkCsvLogging.Checked = false;

                txtFileNamePrefix.Enabled = true;
                txtLogPath.Enabled = true;
                btnBrowseLogPath.Enabled = true;
                cmbLogFileMode.Enabled = true;
                txtErrStr.Text = $"Failed to create the new daily CSV file: {ex.Message}. Logging stopped.";
            }
        }

        private void tmrLogRollover_Tick(object sender, EventArgs e)
        {
            tmrLogRollover.Stop();
            DateTime now = DateTime.Now;

            if (IsDailyLogFileMode() && now.Date != _logFileDate)
                RotateLogFile(now);
            else
                ScheduleNextLogRollover();
        }

        private void StopLogging()
        {
            tmrLogRollover.Stop();
            if (!_isLogging && _logWriter == null) return;
            _isLogging = false;

            if (_logWriter != null)
            {
                try
                {
                    _logWriter.Close();
                    _logWriter.Dispose();
                    _logWriter = null;

                    Action updateUi = () =>
                    {
                        if (chkCsvLogging.Checked)
                            chkCsvLogging.Checked = false;

                        txtFileNamePrefix.Enabled = true;
                        txtLogPath.Enabled = true;
                        btnBrowseLogPath.Enabled = true;
                        cmbLogFileMode.Enabled = true;
                        txtErrStr.Text = $"CSV logging stopped. File saved at: {_logFilePath}";
                    };

                    if (this.InvokeRequired)
                        this.Invoke(updateUi);
                    else
                        updateUi();
                }
                catch (Exception ex)
                {
                    Action updateError = () => txtErrStr.Text = $"Error closing log file: {ex.Message}. File path: {_logFilePath}";
                    if (this.InvokeRequired)
                        this.Invoke(updateError);
                    else
                        updateError();
                }
            }
        }

        private void LogCurrentParams(double tSet, double tCurr, double hSet, double hCurr, bool isEnabled)
        {
            if (_isLogging && _logWriter != null)
            {
                DateTime logTimestamp = DateTime.Now;
                if (IsDailyLogFileMode() && logTimestamp.Date != _logFileDate)
                {
                    RotateLogFile(logTimestamp);
                    if (!_isLogging || _logWriter == null)
                        return;
                }

                string timestamp = logTimestamp.ToString("dd/MM/yyyy_HH:mm:ss");
                int enabledStatus = isEnabled ? 1 : 0;
                string line = $"{timestamp},{tSet:0.0},{tCurr:0.0},{hSet:0.0},{hCurr:0.0},{enabledStatus}";

                try
                {
                    _logWriter.WriteLine(line);
                    _logWriter.Flush();
                }
                catch (Exception ex)
                {
                    Action updateError = () => txtErrStr.Text = $"Logging Error: {ex.Message}. Stopping CSV logging.";
                    this.Invoke(updateError);
                    StopLogging();
                }
            }
        }

        private async Task GetAndDisplayCurrentParams()
        {
            if (chamberController == null || !btnDisconnect.Enabled || _isCommunicating || _cancellationTokenSource?.IsCancellationRequested == true)
                return;

            _isCommunicating = true;

            try
            {
                string response = await Task.Run(() => chamberController.GetAllParams(), _cancellationTokenSource.Token);

                if (response == "TIMEOUT" || response.StartsWith("COMM_ERROR"))
                {
                    txtErrStr.Text = $"COMMUNICATION FAIL: {response}";
                    return;
                }

                if (_cancellationTokenSource.IsCancellationRequested) return;

                double tSet, tCurr, hSet, hCurr;
                bool isEnabled;

                if (chamberController.ParseGetParamsResponse(response, out tSet, out tCurr, out hSet, out hCurr, out isEnabled))
                {
                    txtSetTemp.Text = tSet.ToString("0.0");
                    txtSetHumidity.Text = hSet.ToString("0.0");
                    txtCurrentTemp.Text = tCurr.ToString("0.0");
                    txtCurrentHumidity.Text = hCurr.ToString("0.0");

                    _latestTempSet = tSet;
                    _latestTempActual = tCurr;
                    _latestHumiditySet = hSet;
                    _latestHumidityActual = hCurr;
                    _latestChamberStatus = isEnabled;
                    _hasGraphReading = true;
                    _realtimeGraphController.AddSample(DateTime.Now, tSet, tCurr, hSet, hCurr, isEnabled);

                    if (_isLogging)
                        LogCurrentParams(tSet, tCurr, hSet, hCurr, isEnabled);

                    lblChamberStatus.Text = isEnabled ? "ON" : "OFF";
                    lblChamberStatus.BackColor = isEnabled ? System.Drawing.Color.LightGreen : System.Drawing.Color.LightPink;
                    btnEnableChamber.Text = isEnabled ? "OFF" : "ON";

                    txtErrStr.Text = $"CHAMBER {(isEnabled ? "ON" : "OFF")}. RESPONSE: {response}";
                }
                else
                {
                    txtErrStr.Text = $"COMMUNICATION FAIL : {response}";
                }
            }
            catch (OperationCanceledException)
            {
                txtErrStr.Text = "Communication task cancelled during disconnect.";
            }
            catch (Exception ex) when (ex.Message.Contains("aborted"))
            {
                txtErrStr.Text = $"Error: I/O Aborted (Likely due to port closure). Disconnecting forcefully.";
                StopLogging();
                btnDisconnect_Click(this, EventArgs.Empty);
            }
            finally
            {
                _isCommunicating = false;
            }
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            string portName;
            if (radioTcp.Checked)
            {
                string host = txtTcpHost.Text.Trim();
                int port = 2049;
                int.TryParse(txtTcpPort.Text.Trim(), out port);
                if (string.IsNullOrEmpty(host))
                {
                    MessageBox.Show("Please enter TCP host", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                portName = $"{host}:{port}";
            }
            else
            {
                portName = cmbPortName.SelectedItem?.ToString() ?? cmbPortName.Text?.Trim();
            }

            int baudRate;
            if (!int.TryParse(txtBaudRate.Text, out baudRate))
            {
                MessageBox.Show("Baud Rate not correct format", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(portName))
            {
                MessageBox.Show("Please select com port or enter host:port for TCP (e.g., 169.254.0.2:2049)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _cancellationTokenSource = new CancellationTokenSource();

            ITransport transport = null;
            bool transportConnected = false;

            try
            {
                if (radioTcp.Checked || portName.Contains(":") || portName.Contains("."))
                {
                    string host = portName;
                    int port = 4001;
                    if (portName.Contains(":"))
                    {
                        var parts = portName.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        host = parts[0];
                        if (parts.Length > 1 && int.TryParse(parts[1], out int p)) port = p;
                    }
                    transport = new TcpTransport(host, port);
                }
                else
                {
                    transport = new SerialTransport(portName, baudRate);
                }

                chamberController.SetTransport(transport);
                transportConnected = await Task.Run(() => chamberController.InitializeConnection());
            }
            catch (Exception ex)
            {
                transportConnected = false;
                txtErrStr.Text = $"Connect exception: {ex.Message}";
            }

            if (transportConnected)
            {
                ChamberModel detectedModel = await Task.Run(() => chamberController.CheckChamberModel());

                if (detectedModel != ChamberModel.UNKNOWN)
                {
                    UpdateUIStatus(true);
                    txtErrStr.Text = $"Connect success. Detect model: {detectedModel.ToString()}";
                    await GetAndDisplayCurrentParams();
                }
                else
                {
                    chamberController.Disconnect();
                    UpdateUIStatus(false);
                    txtErrStr.Text = "Connect success, cannot identify the model, Disconnect the port";
                    MessageBox.Show("Cannot identify the model, Please check model or protocol", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                UpdateUIStatus(false);
                txtErrStr.Text = "Connect failed";
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            tmrAutoGet.Stop();
            StopLogging();
            chamberController.Disconnect();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
            UpdateUIStatus(false);

            if (!_isLogging)
                txtErrStr.Text = "Disconnected.";
        }

        private async void btnEnableChamber_Click(object sender, EventArgs e)
        {
            if (chamberController == null || !btnDisconnect.Enabled)
            {
                MessageBox.Show("Please connect the chamber", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool wantsToEnable = (btnEnableChamber.Text == "ON");
            await SetChamberParams(wantsToEnable);

            string newButtonText = wantsToEnable ? "OFF" : "ON";
            string newStatusText = wantsToEnable ? "ON" : "OFF";

            btnEnableChamber.Text = newButtonText;
            lblChamberStatus.Text = newStatusText;
            lblChamberStatus.BackColor = wantsToEnable ? System.Drawing.Color.LightGreen : System.Drawing.Color.LightPink;

            await GetAndDisplayCurrentParams();
        }

        private async void btnGetCurrentParams_Click(object sender, EventArgs e)
        {
            await GetAndDisplayCurrentParams();
        }

        private async void TxtSet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                bool isCurrentlyEnabled = (btnEnableChamber.Text == "OFF");
                await SetChamberParams(isCurrentlyEnabled);
                await GetAndDisplayCurrentParams();
            }
        }

        private async Task SetChamberParams(bool isEnabled)
        {
            if (chamberController == null || !btnDisconnect.Enabled || _isCommunicating || _cancellationTokenSource?.IsCancellationRequested == true)
            {
                txtErrStr.Text = "Warning: Chamber not connected or communication busy/cancelled.";
                return;
            }

            _isCommunicating = true;

            try
            {
                if (!double.TryParse(txtSetTemp.Text, out double setTemp) || !double.TryParse(txtSetHumidity.Text, out double setHumi))
                {
                    MessageBox.Show("Setpoint not correct, Please fill the numeric", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string result = await Task.Run(() => chamberController.SetAllParams(setTemp, setHumi, isEnabled), _cancellationTokenSource.Token);

                if (_cancellationTokenSource.IsCancellationRequested) return;

                if (result == "TIMEOUT" || result.StartsWith("COMM_ERROR"))
                {
                    txtErrStr.Text = $"Communication failed: {result}";
                }
                else
                {
                    txtErrStr.Text = $"Setpoint updated Status: {(isEnabled ? "ON" : "OFF")}. RESPONSE: {result}";
                }
            }
            catch (OperationCanceledException)
            {
                txtErrStr.Text = "Communication task cancelled during disconnect.";
            }
            catch (Exception ex) when (ex.Message.Contains("aborted"))
            {
                txtErrStr.Text = $"Error: I/O Aborted (Likely due to port closure). Disconnecting forcefully.";
                btnDisconnect_Click(this, EventArgs.Empty);
            }
            finally
            {
                _isCommunicating = false;
            }
        }

        private async void btnSetTemp_Click(object sender, EventArgs e)
        {
            bool isCurrentlyEnabled = (btnEnableChamber.Text == "OFF");
            await SetChamberParams(isCurrentlyEnabled);
            await GetAndDisplayCurrentParams();
        }

        private async void btnSetHumidity_Click(object sender, EventArgs e)
        {
            bool isCurrentlyEnabled = (btnEnableChamber.Text == "OFF");
            await SetChamberParams(isCurrentlyEnabled);
            await GetAndDisplayCurrentParams();
        }

        private async void tmrAutoGet_Tick(object sender, EventArgs e)
        {
            await GetAndDisplayCurrentParams();
        }

        private void tmrGraphHold_Tick(object sender, EventArgs e)
        {
            if (!_hasGraphReading || chkAutoGet.Checked)
                return;

            _realtimeGraphController.AddSample(
                DateTime.Now,
                _latestTempSet,
                _latestTempActual,
                _latestHumiditySet,
                _latestHumidityActual,
                _latestChamberStatus);
        }

        private int GetSelectedSamplingIntervalMs()
        {
            string selectedRate = cmbSamplingRate.SelectedItem == null
                ? "10s"
                : cmbSamplingRate.SelectedItem.ToString();

            switch (selectedRate)
            {
                case "1ms": return 1;
                case "10ms": return 10;
                case "100ms": return 100;
                case "500ms": return 500;
                case "1s": return 1000;
                case "2s": return 2000;
                case "5s": return 5000;
                case "10s": return 10000;
                case "30s": return 30000;
                case "1min": return 60000;
                case "5min": return 300000;
                case "10min": return 600000;
                case "30min": return 1800000;
                case "1hr": return 3600000;
                default: return 10000;
            }
        }

        private void UpdateGraphSamplingState()
        {
            int intervalMs = GetSelectedSamplingIntervalMs();
            tmrGraphHold.Stop();
            tmrGraphHold.Interval = intervalMs;

            if (!chkAutoGet.Checked)
                tmrGraphHold.Start();

            string samplingText = cmbSamplingRate.SelectedItem == null
                ? "10s"
                : cmbSamplingRate.SelectedItem.ToString();
            _realtimeGraphController.SetSamplingMode(samplingText, chkAutoGet.Checked);
        }

        private void btnBrowseLogPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = txtLogPath.Text;
                folderDialog.Description = "Select a directory to save the CSV log file. (You can also type directly into the textbox)";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    _logDirectoryPath = folderDialog.SelectedPath;
                    txtLogPath.Text = _logDirectoryPath;
                }
            }
        }

        private async void chkAutoGet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoGet.Checked)
            {
                if (!btnDisconnect.Enabled)
                {
                    chkAutoGet.Checked = false;
                    txtErrStr.Text = "Cannot start autoget, Please connect chamber.";
                    return;
                }

                string selectedRate = cmbSamplingRate.SelectedItem.ToString();
                int intervalMs = GetSelectedSamplingIntervalMs();

                tmrAutoGet.Interval = intervalMs;
                tmrAutoGet.Start();
                UpdateGraphSamplingState();
                txtErrStr.Text = $"Start autoget at {selectedRate}";

                chkCsvLogging.Enabled = true;
                await GetAndDisplayCurrentParams();
            }
            else
            {
                tmrAutoGet.Stop();
                UpdateGraphSamplingState();
                txtErrStr.Text = "Autoget stopped";

                if (chkCsvLogging.Checked)
                    chkCsvLogging.Checked = false;
                chkCsvLogging.Enabled = false;
            }
        }

        private void chkCsvLogging_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCsvLogging.Checked)
            {
                if (!chkAutoGet.Checked)
                {
                    MessageBox.Show("CSV Logging requires Auto Get to be enabled first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chkCsvLogging.Checked = false;
                    return;
                }

                if (!btnDisconnect.Enabled)
                {
                    chkCsvLogging.Checked = false;
                    txtErrStr.Text = "Cannot start logging, Please connect chamber.";
                    return;
                }

                _logDirectoryPath = txtLogPath.Text.Trim();
                string prefix = txtFileNamePrefix.Text.Trim();

                if (string.IsNullOrEmpty(prefix))
                {
                    MessageBox.Show("Please enter a file name prefix for the CSV file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chkCsvLogging.Checked = false;
                    return;
                }

                try
                {
                    if (!Directory.Exists(_logDirectoryPath))
                    {
                        Directory.CreateDirectory(_logDirectoryPath);
                        txtErrStr.Text = $"Log path created: {_logDirectoryPath}";
                    }

                    OpenNewLogFile(DateTime.Now);

                    _isLogging = true;
                    ScheduleNextLogRollover();
                    txtFileNamePrefix.Enabled = false;
                    txtLogPath.Enabled = false;
                    btnBrowseLogPath.Enabled = false;
                    cmbLogFileMode.Enabled = false;
                    txtErrStr.Text = $"CSV logging started ({cmbLogFileMode.Text}). File saved at: {_logFilePath}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Invalid log path or cannot create/write to directory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtErrStr.Text = $"Failed to start logging: {ex.Message}";
                    chkCsvLogging.Checked = false;
                    _isLogging = false;
                    tmrLogRollover.Stop();
                    txtFileNamePrefix.Enabled = true;
                    txtLogPath.Enabled = true;
                    btnBrowseLogPath.Enabled = true;
                    cmbLogFileMode.Enabled = true;
                }
            }
            else
            {
                StopLogging();
            }
        }

        private async void cmbSamplingRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intervalMs = GetSelectedSamplingIntervalMs();
            UpdateGraphSamplingState();

            if (chkAutoGet.Checked)
            {
                string selectedRate = cmbSamplingRate.SelectedItem.ToString();

                tmrAutoGet.Stop();
                tmrAutoGet.Interval = intervalMs;
                tmrAutoGet.Start();
                txtErrStr.Text = $"Change autoget sampling rate to {selectedRate}";

                await GetAndDisplayCurrentParams();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (tmrGraphHold != null)
            {
                tmrGraphHold.Stop();
                tmrGraphHold.Dispose();
            }

            if (_realtimeGraphController != null)
                _realtimeGraphController.Dispose();

            base.OnFormClosed(e);
        }

        private void lblAbout_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            string title = assembly.GetCustomAttribute<AssemblyTitleAttribute>()?.Title ?? "N/A";
            string description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description ?? "N/A";
            string company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company ?? "N/A";
            string version = assembly.GetName().Version.ToString();

            string info = $"Program Title: {title}\n" +
                          $"Version: {version}\n" +
                          $"Description: {description}\n" +
                          $"Company: {company}\n" +
                          $"Author: {ProgramAuthor}\n" +
                          $"\n" +
                          $"- This software is used for RS232 and Ethernet communication with the Weiss Environmental Test Chamber." +
                          $"\n" +
                          $"- Program can be set/get/output control, autoget the parameter at user defined rate and CSV logging supported";

            MessageBox.Show(info, "About Weiss Chamber Controller", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // New: handle radio mode change to show/hide TCP host/port controls
        private void RadioMode_CheckedChanged(object sender, EventArgs e)
        {
            if (radioTcp.Checked)
            {
                // TCP mode selected
                txtTcpHost.Enabled = true;
                txtTcpPort.Enabled = true;
                cmbPortName.Enabled = false;
                txtBaudRate.Enabled = false;
                lblPort.Text = "TCP Host";
            }
            else
            {
                // Serial mode selected
                txtTcpHost.Enabled = false;
                txtTcpPort.Enabled = false;
                cmbPortName.Enabled = true;
                txtBaudRate.Enabled = true;
                lblPort.Text = "Com port";
            }
        }
    }
}
