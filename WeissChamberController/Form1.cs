//################################################################################
//FileName: Form1.cs
//FileType: Visual C# Source file
//Author : TOPTUBBY (AnonymouS)
//Created On : 27/11/2025 12:00:00 PM
//Last Modified On : 29/11/2025 11:48:00 PM
//Copy Rights : Delta Electronics Thailand PCL.
//Description : Class for defining database related functions
//  ------------------------------------------------------------------------------
//v1.0.11.25                                                           29 Nov 2025
//  - Program for RS232 communication with Weiss Environmental Test Chamber
//  - Program can be set/get/output control
//  - Program can autoget parameter at user defined rate and CSV logging supported
//  ..............................................................................
//################################################################################

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

        // Chamber controller instance
        private WeissChamberController chamberController = new WeissChamberController();

        // Timer for automatic parameter retrieval
        private System.Windows.Forms.Timer tmrAutoGet;

        // Used to cancel running tasks when disconnecting
        private CancellationTokenSource _cancellationTokenSource;

        // Prevents concurrent communication (race condition)
        private bool _isCommunicating = false;

        // Indicates if CSV logging is active
        private bool _isLogging = false;

        private StreamWriter _logWriter;
        private string _logFilePath;

        // Stores the log directory path
        private string _logDirectoryPath;

        private List<string> BlackList = new List<string>();
        private List<string> file_List = new List<string>();

        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
            InitializeCommControls();
            UpdateUIStatus(false); // Start with Disconnected status
                                   //this.lblAbout.Click += new System.EventHandler(this.lblAbout_Click);
        }

        /// <summary>
        /// User blacklist check on form load.
        /// </summary>
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

        /// <summary>
        /// Initializes the timer for automatic parameter retrieval.
        /// </summary>
        private void InitializeTimer()
        {
            tmrAutoGet = new System.Windows.Forms.Timer();
            tmrAutoGet.Tick += new EventHandler(tmrAutoGet_Tick);
            tmrAutoGet.Interval = 5000; // Default to 5 seconds
        }

        /// <summary>
        /// Initializes communication controls and default values.
        /// </summary>
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

            // Set default log directory path
            //_logDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            _logDirectoryPath = "D:\\Data";
            txtLogPath.Text = _logDirectoryPath;

            // Populate sampling rate options
            cmbSamplingRate.Items.AddRange(new object[]
            {
                    "1ms", "10ms", "100ms", "500ms", "1s", "2s", "5s", "10s", "30s",
                    "1min", "5min", "10min", "30min", "1hr"
            });
            cmbSamplingRate.SelectedIndex = 7; // Default to 10s
        }

        /// <summary>
        /// Updates the UI controls based on connection status.
        /// </summary>
        private void UpdateUIStatus(bool isConnected)
        {
            btnConnect.Enabled = !isConnected;
            btnDisconnect.Enabled = isConnected;
            cmbPortName.Enabled = !isConnected;
            txtBaudRate.Enabled = !isConnected;

            // Enable control and monitoring groups only when connected
            grpControl.Enabled = isConnected;
            grpMonitoring.Enabled = isConnected;

            // Enable auto-get controls only when connected
            chkAutoGet.Enabled = isConnected;
            cmbSamplingRate.Enabled = isConnected;

            // Enable logging controls only when connected and auto-get is checked
            if (isConnected)
            {
                chkCsvLogging.Enabled = chkAutoGet.Checked;

                // Allow editing log path and file name only when not logging
                bool logControlsEditable = !_isLogging;
                txtFileNamePrefix.Enabled = logControlsEditable;
                txtLogPath.Enabled = logControlsEditable;
                btnBrowseLogPath.Enabled = logControlsEditable;
            }
            else
            {
                tmrAutoGet.Stop();
                StopLogging();

                chkAutoGet.Checked = false;
                chkCsvLogging.Enabled = false;

                // Always allow editing log path and file name when disconnected
                txtFileNamePrefix.Enabled = true;
                txtLogPath.Enabled = true;
                btnBrowseLogPath.Enabled = true;
            }

            // Update communication status label
            lblCommStatus.Text = isConnected ? "Connected" : "Disconnected";
            lblCommStatus.BackColor = isConnected ? System.Drawing.Color.LightGreen : System.Drawing.Color.LightGray;

            // Update chamber status label and button
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

        /// <summary>
        /// Safely stops CSV logging and updates the UI.
        /// </summary>
        private void StopLogging()
        {
            if (!_isLogging) return;
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

        /// <summary>
        /// Logs the current chamber parameters to the CSV file.
        /// </summary>
        private void LogCurrentParams(double tSet, double tCurr, double hSet, double hCurr, bool isEnabled)
        {
            if (_isLogging && _logWriter != null)
            {
                string timestamp = DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss");
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

        /// <summary>
        /// Retrieves and displays current chamber parameters.
        /// </summary>
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

        /// <summary>
        /// Handles the Connect button click event.
        /// </summary>
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            string portName = cmbPortName.SelectedItem?.ToString();
            int baudRate;

            if (string.IsNullOrEmpty(portName))
            {
                MessageBox.Show("Please select com port", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtBaudRate.Text, out baudRate))
            {
                MessageBox.Show("Baud Rate not correct format", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _cancellationTokenSource = new CancellationTokenSource();

            bool isConnected = await Task.Run(() => chamberController.InitializeSerialPort(portName, baudRate));

            if (isConnected)
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

        /// <summary>
        /// Handles the Disconnect button click event.
        /// </summary>
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

        /// <summary>
        /// Handles the Enable Chamber button click event.
        /// </summary>
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

        /// <summary>
        /// Handles the Get Current Params button click event.
        /// </summary>
        private async void btnGetCurrentParams_Click(object sender, EventArgs e)
        {
            await GetAndDisplayCurrentParams();
        }

        /// <summary>
        /// Handles the Setpoint textbox key press event (Enter key).
        /// </summary>
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

        /// <summary>
        /// Sends setpoint and enable/disable command to the chamber.
        /// </summary>
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

        /// <summary>
        /// Handles the Set Temperature button click event.
        /// </summary>
        private async void btnSetTemp_Click(object sender, EventArgs e)
        {
            bool isCurrentlyEnabled = (btnEnableChamber.Text == "OFF");
            await SetChamberParams(isCurrentlyEnabled);
            await GetAndDisplayCurrentParams();
        }

        /// <summary>
        /// Handles the Set Humidity button click event.
        /// </summary>
        private async void btnSetHumidity_Click(object sender, EventArgs e)
        {
            bool isCurrentlyEnabled = (btnEnableChamber.Text == "OFF");
            await SetChamberParams(isCurrentlyEnabled);
            await GetAndDisplayCurrentParams();
        }

        /// <summary>
        /// Timer tick event for automatic parameter retrieval.
        /// </summary>
        private async void tmrAutoGet_Tick(object sender, EventArgs e)
        {
            await GetAndDisplayCurrentParams();
        }

        /// <summary>
        /// Handles the Browse Log Path button click event.
        /// </summary>
        private void btnBrowseLogPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = txtLogPath.Text;
                folderDialog.Description = "Select a directory to save the CSV log file. (You can also type directly into the textbox)";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    _logDirectoryPath = "folderDialog.SelectedPath";
                    txtLogPath.Text = _logDirectoryPath;
                }
            }
        }

        /// <summary>
        /// Handles the Auto Get checkbox change event.
        /// </summary>
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
                int intervalMs = 0;

                switch (selectedRate)
                {
                    case "1s": intervalMs = 1000; break;
                    case "2s": intervalMs = 2000; break;
                    case "5s": intervalMs = 5000; break;
                    case "10s": intervalMs = 10000; break;
                    case "30s": intervalMs = 30000; break;
                    case "60s": intervalMs = 60000; break;
                    default: intervalMs = 5000; break;
                }

                tmrAutoGet.Interval = intervalMs;
                tmrAutoGet.Start();
                txtErrStr.Text = $"Start autoget at {selectedRate}";

                chkCsvLogging.Enabled = true;
                await GetAndDisplayCurrentParams();
            }
            else
            {
                tmrAutoGet.Stop();
                txtErrStr.Text = "Autoget stopped";

                if (chkCsvLogging.Checked)
                    chkCsvLogging.Checked = false;
                chkCsvLogging.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the CSV Logging checkbox change event.
        /// </summary>
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

                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                    string fileName = $"CBLOG_{prefix}_{timestamp}.csv";
                    _logFilePath = Path.Combine(_logDirectoryPath, fileName);

                    _logWriter = new StreamWriter(_logFilePath, false);
                    _logWriter.WriteLine("Timestamp,SetTemp,ActTemp,SetHumi,ActHumi,Status");
                    _logWriter.Flush();

                    _isLogging = true;
                    txtFileNamePrefix.Enabled = false;
                    txtLogPath.Enabled = false;
                    btnBrowseLogPath.Enabled = false;
                    txtErrStr.Text = $"CSV logging started. File saved at: {_logFilePath}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Invalid log path or cannot create/write to directory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtErrStr.Text = $"Failed to start logging: {ex.Message}";
                    chkCsvLogging.Checked = false;
                    _isLogging = false;
                    txtFileNamePrefix.Enabled = true;
                    txtLogPath.Enabled = true;
                    btnBrowseLogPath.Enabled = true;
                }
            }
            else
            {
                StopLogging();
            }
        }

        /// <summary>
        /// Handles the sampling rate ComboBox change event.
        /// </summary>
        private async void cmbSamplingRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkAutoGet.Checked)
            {
                string selectedRate = cmbSamplingRate.SelectedItem.ToString();
                int intervalMs = 0;

                switch (selectedRate)
                {
                    case "1ms": intervalMs = 1; break;
                    case "10ms": intervalMs = 10; break;
                    case "100ms": intervalMs = 100; break;
                    case "500ms": intervalMs = 500; break;
                    case "1s": intervalMs = 1000; break;
                    case "2s": intervalMs = 2000; break;
                    case "5s": intervalMs = 5000; break;
                    case "10s": intervalMs = 10000; break;
                    case "30s": intervalMs = 30000; break;
                    case "1min": intervalMs = 60000; break;
                    case "5min": intervalMs = 300000; break;
                    case "10min": intervalMs = 600000; break;
                    case "30min": intervalMs = 1800000; break;
                    case "1hr": intervalMs = 3600000; break;
                    default: intervalMs = 10000; break;
                }

                tmrAutoGet.Stop();
                tmrAutoGet.Interval = intervalMs;
                tmrAutoGet.Start();
                txtErrStr.Text = $"Change autoget sampling rate to {selectedRate}";

                await GetAndDisplayCurrentParams();
            }
        }

        /// <summary>
        /// Handles the About label click event to show program information.
        /// </summary>
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
                          $"- This software is used for RS232 communication with the Weiss Environmental Test Chamber." +
                          $"\n" +
                          $"- Program can be set/get/output control, autoget the parameter at user defined rate and CSV logging supported";

            MessageBox.Show(info, "About Weiss Chamber Controller", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}