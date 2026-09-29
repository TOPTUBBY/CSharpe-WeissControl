namespace Form1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.grpComm = new System.Windows.Forms.GroupBox();
            this.txtTcpPort = new System.Windows.Forms.TextBox();
            this.txtTcpHost = new System.Windows.Forms.TextBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.lblCommStatus = new System.Windows.Forms.Label();
            this.lblBaud = new System.Windows.Forms.Label();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.radioTcp = new System.Windows.Forms.RadioButton();
            this.radioSerial = new System.Windows.Forms.RadioButton();
            this.txtErrStr = new System.Windows.Forms.TextBox();
            this.grpControl = new System.Windows.Forms.GroupBox();
            this.btnSetHumidity = new System.Windows.Forms.Button();
            this.btnSetTemp = new System.Windows.Forms.Button();
            this.txtSetHumidity = new System.Windows.Forms.TextBox();
            this.txtSetTemp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnableChamber = new System.Windows.Forms.Button();
            this.grpMonitoring = new System.Windows.Forms.GroupBox();
            this.btnGetHumidity = new System.Windows.Forms.Button();
            this.btnGetCurrentTemp = new System.Windows.Forms.Button();
            this.txtCurrentHumidity = new System.Windows.Forms.TextBox();
            this.txtCurrentTemp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblChamberStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbLogFileMode = new System.Windows.Forms.ComboBox();
            this.btnBrowseLogPath = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFileNamePrefix = new System.Windows.Forms.TextBox();
            this.chkCsvLogging = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAutoGet = new System.Windows.Forms.CheckBox();
            this.cmbSamplingRate = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAbout = new System.Windows.Forms.Label();
            this.btnGraphTab = new System.Windows.Forms.Button();
            this.pnlGraphWorkspace = new System.Windows.Forms.Panel();
            this.splitGraphWorkspace = new System.Windows.Forms.SplitContainer();
            this.chartRealtime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvGraphValues = new System.Windows.Forms.DataGridView();
            this.colGraphVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colGraphSignal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGraphX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGraphY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblGraphProbe = new System.Windows.Forms.Label();
            this.pnlGraphToolbar = new System.Windows.Forms.Panel();
            this.lblGraphTitle = new System.Windows.Forms.Label();
            this.lblGraphTimeDiv = new System.Windows.Forms.Label();
            this.cmbGraphTimeDiv = new System.Windows.Forms.ComboBox();
            this.chkGraphAutoFollow = new System.Windows.Forms.CheckBox();
            this.btnGraphResetView = new System.Windows.Forms.Button();
            this.lblGraphSampling = new System.Windows.Forms.Label();
            this.lblGraphMouseMode = new System.Windows.Forms.Label();
            this.cmbGraphMouseMode = new System.Windows.Forms.ComboBox();
            this.lblGraphTempRange = new System.Windows.Forms.Label();
            this.txtGraphTempMin = new System.Windows.Forms.TextBox();
            this.lblGraphTempTo = new System.Windows.Forms.Label();
            this.txtGraphTempMax = new System.Windows.Forms.TextBox();
            this.lblGraphHumiRange = new System.Windows.Forms.Label();
            this.txtGraphHumiMin = new System.Windows.Forms.TextBox();
            this.lblGraphHumiTo = new System.Windows.Forms.Label();
            this.txtGraphHumiMax = new System.Windows.Forms.TextBox();
            this.btnGraphApplyY = new System.Windows.Forms.Button();
            this.btnGraphAutoY = new System.Windows.Forms.Button();
            this.lblGraphMouseHint = new System.Windows.Forms.Label();
            this.toolTipGraph = new System.Windows.Forms.ToolTip(this.components);
            this.grpComm.SuspendLayout();
            this.grpControl.SuspendLayout();
            this.grpMonitoring.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlGraphWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitGraphWorkspace)).BeginInit();
            this.splitGraphWorkspace.Panel1.SuspendLayout();
            this.splitGraphWorkspace.Panel2.SuspendLayout();
            this.splitGraphWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRealtime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGraphValues)).BeginInit();
            this.pnlGraphToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpComm
            // 
            this.grpComm.Controls.Add(this.txtTcpPort);
            this.grpComm.Controls.Add(this.txtTcpHost);
            this.grpComm.Controls.Add(this.btnDisconnect);
            this.grpComm.Controls.Add(this.btnConnect);
            this.grpComm.Controls.Add(this.txtBaudRate);
            this.grpComm.Controls.Add(this.lblCommStatus);
            this.grpComm.Controls.Add(this.lblBaud);
            this.grpComm.Controls.Add(this.cmbPortName);
            this.grpComm.Controls.Add(this.lblPort);
            this.grpComm.Location = new System.Drawing.Point(12, 17);
            this.grpComm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpComm.Name = "grpComm";
            this.grpComm.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpComm.Size = new System.Drawing.Size(308, 83);
            this.grpComm.TabIndex = 0;
            this.grpComm.TabStop = false;
            this.grpComm.Text = "Communication Status";
            // 
            // txtTcpPort
            // 
            this.txtTcpPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTcpPort.Enabled = false;
            this.txtTcpPort.Location = new System.Drawing.Point(104, 56);
            this.txtTcpPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTcpPort.Name = "txtTcpPort";
            this.txtTcpPort.Size = new System.Drawing.Size(55, 20);
            this.txtTcpPort.TabIndex = 13;
            this.txtTcpPort.Text = "2049";
            this.txtTcpPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTcpHost
            // 
            this.txtTcpHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTcpHost.Enabled = false;
            this.txtTcpHost.Location = new System.Drawing.Point(19, 56);
            this.txtTcpHost.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTcpHost.Name = "txtTcpHost";
            this.txtTcpHost.Size = new System.Drawing.Size(81, 20);
            this.txtTcpHost.TabIndex = 12;
            this.txtTcpHost.Text = "169.254.0.2";
            this.txtTcpHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(224, 33);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(76, 41);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(164, 33);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(56, 41);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBaudRate.Location = new System.Drawing.Point(104, 34);
            this.txtBaudRate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(55, 20);
            this.txtBaudRate.TabIndex = 4;
            this.txtBaudRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCommStatus
            // 
            this.lblCommStatus.AutoSize = true;
            this.lblCommStatus.Location = new System.Drawing.Point(184, 0);
            this.lblCommStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCommStatus.Name = "lblCommStatus";
            this.lblCommStatus.Size = new System.Drawing.Size(40, 13);
            this.lblCommStatus.TabIndex = 3;
            this.lblCommStatus.Text = "Status:";
            // 
            // lblBaud
            // 
            this.lblBaud.AutoSize = true;
            this.lblBaud.Location = new System.Drawing.Point(102, 18);
            this.lblBaud.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBaud.Name = "lblBaud";
            this.lblBaud.Size = new System.Drawing.Size(50, 13);
            this.lblBaud.TabIndex = 3;
            this.lblBaud.Text = "Buadrate";
            // 
            // cmbPortName
            // 
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(19, 33);
            this.cmbPortName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(81, 21);
            this.cmbPortName.TabIndex = 2;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(16, 18);
            this.lblPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(49, 13);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Com port";
            // 
            // radioTcp
            // 
            this.radioTcp.AutoSize = true;
            this.radioTcp.Location = new System.Drawing.Point(139, -1);
            this.radioTcp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioTcp.Name = "radioTcp";
            this.radioTcp.Size = new System.Drawing.Size(95, 17);
            this.radioTcp.TabIndex = 11;
            this.radioTcp.TabStop = true;
            this.radioTcp.Text = "TCP (Ethernet)";
            this.radioTcp.UseVisualStyleBackColor = true;
            this.radioTcp.CheckedChanged += new System.EventHandler(this.RadioMode_CheckedChanged);
            // 
            // radioSerial
            // 
            this.radioSerial.AutoSize = true;
            this.radioSerial.Checked = true;
            this.radioSerial.Location = new System.Drawing.Point(53, -1);
            this.radioSerial.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioSerial.Name = "radioSerial";
            this.radioSerial.Size = new System.Drawing.Size(84, 17);
            this.radioSerial.TabIndex = 10;
            this.radioSerial.TabStop = true;
            this.radioSerial.Text = "Serial (COM)";
            this.radioSerial.UseVisualStyleBackColor = true;
            this.radioSerial.CheckedChanged += new System.EventHandler(this.RadioMode_CheckedChanged);
            // 
            // txtErrStr
            // 
            this.txtErrStr.Location = new System.Drawing.Point(13, 245);
            this.txtErrStr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtErrStr.Multiline = true;
            this.txtErrStr.Name = "txtErrStr";
            this.txtErrStr.ReadOnly = true;
            this.txtErrStr.Size = new System.Drawing.Size(536, 79);
            this.txtErrStr.TabIndex = 4;
            this.txtErrStr.Text = "Comm Status String";
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.btnSetHumidity);
            this.grpControl.Controls.Add(this.btnSetTemp);
            this.grpControl.Controls.Add(this.txtSetHumidity);
            this.grpControl.Controls.Add(this.txtSetTemp);
            this.grpControl.Controls.Add(this.label2);
            this.grpControl.Controls.Add(this.label1);
            this.grpControl.Location = new System.Drawing.Point(13, 103);
            this.grpControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpControl.Name = "grpControl";
            this.grpControl.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpControl.Size = new System.Drawing.Size(220, 67);
            this.grpControl.TabIndex = 0;
            this.grpControl.TabStop = false;
            this.grpControl.Text = "Control : Manual";
            // 
            // btnSetHumidity
            // 
            this.btnSetHumidity.Location = new System.Drawing.Point(151, 40);
            this.btnSetHumidity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSetHumidity.Name = "btnSetHumidity";
            this.btnSetHumidity.Size = new System.Drawing.Size(62, 19);
            this.btnSetHumidity.TabIndex = 5;
            this.btnSetHumidity.Text = "SET";
            this.btnSetHumidity.UseVisualStyleBackColor = true;
            this.btnSetHumidity.Click += new System.EventHandler(this.btnSetHumidity_Click);
            // 
            // btnSetTemp
            // 
            this.btnSetTemp.Location = new System.Drawing.Point(151, 14);
            this.btnSetTemp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSetTemp.Name = "btnSetTemp";
            this.btnSetTemp.Size = new System.Drawing.Size(62, 21);
            this.btnSetTemp.TabIndex = 5;
            this.btnSetTemp.Text = "SET";
            this.btnSetTemp.UseVisualStyleBackColor = true;
            this.btnSetTemp.Click += new System.EventHandler(this.btnSetTemp_Click);
            // 
            // txtSetHumidity
            // 
            this.txtSetHumidity.Location = new System.Drawing.Point(67, 40);
            this.txtSetHumidity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSetHumidity.Name = "txtSetHumidity";
            this.txtSetHumidity.Size = new System.Drawing.Size(76, 20);
            this.txtSetHumidity.TabIndex = 4;
            this.txtSetHumidity.Text = "0.00";
            this.txtSetHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSetHumidity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSet_KeyPress);
            // 
            // txtSetTemp
            // 
            this.txtSetTemp.Location = new System.Drawing.Point(67, 15);
            this.txtSetTemp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSetTemp.Name = "txtSetTemp";
            this.txtSetTemp.Size = new System.Drawing.Size(76, 20);
            this.txtSetTemp.TabIndex = 4;
            this.txtSetTemp.Text = "0.00";
            this.txtSetTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSetTemp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSet_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Humi.Set";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Temp.Set";
            // 
            // btnEnableChamber
            // 
            this.btnEnableChamber.Location = new System.Drawing.Point(236, 107);
            this.btnEnableChamber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEnableChamber.Name = "btnEnableChamber";
            this.btnEnableChamber.Size = new System.Drawing.Size(81, 132);
            this.btnEnableChamber.TabIndex = 5;
            this.btnEnableChamber.Text = "ON";
            this.btnEnableChamber.UseVisualStyleBackColor = true;
            this.btnEnableChamber.Click += new System.EventHandler(this.btnEnableChamber_Click);
            // 
            // grpMonitoring
            // 
            this.grpMonitoring.Controls.Add(this.btnGetHumidity);
            this.grpMonitoring.Controls.Add(this.btnGetCurrentTemp);
            this.grpMonitoring.Controls.Add(this.txtCurrentHumidity);
            this.grpMonitoring.Controls.Add(this.txtCurrentTemp);
            this.grpMonitoring.Controls.Add(this.label4);
            this.grpMonitoring.Controls.Add(this.label3);
            this.grpMonitoring.Location = new System.Drawing.Point(13, 176);
            this.grpMonitoring.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpMonitoring.Name = "grpMonitoring";
            this.grpMonitoring.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpMonitoring.Size = new System.Drawing.Size(220, 67);
            this.grpMonitoring.TabIndex = 0;
            this.grpMonitoring.TabStop = false;
            this.grpMonitoring.Text = "Monitoring";
            // 
            // btnGetHumidity
            // 
            this.btnGetHumidity.Location = new System.Drawing.Point(151, 43);
            this.btnGetHumidity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGetHumidity.Name = "btnGetHumidity";
            this.btnGetHumidity.Size = new System.Drawing.Size(62, 20);
            this.btnGetHumidity.TabIndex = 5;
            this.btnGetHumidity.Text = "GET";
            this.btnGetHumidity.UseVisualStyleBackColor = true;
            this.btnGetHumidity.Click += new System.EventHandler(this.btnGetCurrentParams_Click);
            // 
            // btnGetCurrentTemp
            // 
            this.btnGetCurrentTemp.Location = new System.Drawing.Point(151, 20);
            this.btnGetCurrentTemp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGetCurrentTemp.Name = "btnGetCurrentTemp";
            this.btnGetCurrentTemp.Size = new System.Drawing.Size(62, 22);
            this.btnGetCurrentTemp.TabIndex = 5;
            this.btnGetCurrentTemp.Text = "GET";
            this.btnGetCurrentTemp.UseVisualStyleBackColor = true;
            this.btnGetCurrentTemp.Click += new System.EventHandler(this.btnGetCurrentParams_Click);
            // 
            // txtCurrentHumidity
            // 
            this.txtCurrentHumidity.Location = new System.Drawing.Point(71, 43);
            this.txtCurrentHumidity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCurrentHumidity.Name = "txtCurrentHumidity";
            this.txtCurrentHumidity.ReadOnly = true;
            this.txtCurrentHumidity.Size = new System.Drawing.Size(76, 20);
            this.txtCurrentHumidity.TabIndex = 4;
            this.txtCurrentHumidity.Text = "0.00";
            this.txtCurrentHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCurrentTemp
            // 
            this.txtCurrentTemp.Location = new System.Drawing.Point(71, 20);
            this.txtCurrentTemp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCurrentTemp.Name = "txtCurrentTemp";
            this.txtCurrentTemp.ReadOnly = true;
            this.txtCurrentTemp.Size = new System.Drawing.Size(76, 20);
            this.txtCurrentTemp.TabIndex = 4;
            this.txtCurrentTemp.Text = "0.00";
            this.txtCurrentTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Humi.Act";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Temp.Act";
            // 
            // lblChamberStatus
            // 
            this.lblChamberStatus.AutoSize = true;
            this.lblChamberStatus.BackColor = System.Drawing.Color.LightGray;
            this.lblChamberStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChamberStatus.ForeColor = System.Drawing.Color.Black;
            this.lblChamberStatus.Location = new System.Drawing.Point(493, 3);
            this.lblChamberStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChamberStatus.Name = "lblChamberStatus";
            this.lblChamberStatus.Size = new System.Drawing.Size(58, 26);
            this.lblChamberStatus.TabIndex = 6;
            this.lblChamberStatus.Text = "OFF";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.lblChamberStatus);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1762, 38);
            this.panel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(2, 2);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(332, 32);
            this.label5.TabIndex = 1;
            this.label5.Text = "Weiss Climatic Chamber";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Olive;
            this.panel2.Location = new System.Drawing.Point(-1, 37);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1766, 8);
            this.panel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.radioTcp);
            this.groupBox1.Controls.Add(this.radioSerial);
            this.groupBox1.Controls.Add(this.btnEnableChamber);
            this.groupBox1.Controls.Add(this.grpComm);
            this.groupBox1.Controls.Add(this.grpMonitoring);
            this.groupBox1.Controls.Add(this.txtErrStr);
            this.groupBox1.Controls.Add(this.grpControl);
            this.groupBox1.Location = new System.Drawing.Point(7, 50);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(559, 332);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbLogFileMode);
            this.groupBox3.Controls.Add(this.btnBrowseLogPath);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtLogPath);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtFileNamePrefix);
            this.groupBox3.Controls.Add(this.chkCsvLogging);
            this.groupBox3.Location = new System.Drawing.Point(325, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 132);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logging";
            // 
            // cmbLogFileMode
            // 
            this.cmbLogFileMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogFileMode.FormattingEnabled = true;
            this.cmbLogFileMode.Location = new System.Drawing.Point(108, 17);
            this.cmbLogFileMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbLogFileMode.Name = "cmbLogFileMode";
            this.cmbLogFileMode.Size = new System.Drawing.Size(78, 21);
            this.cmbLogFileMode.TabIndex = 10;
            // 
            // btnBrowseLogPath
            // 
            this.btnBrowseLogPath.Location = new System.Drawing.Point(108, 80);
            this.btnBrowseLogPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBrowseLogPath.Name = "btnBrowseLogPath";
            this.btnBrowseLogPath.Size = new System.Drawing.Size(78, 22);
            this.btnBrowseLogPath.TabIndex = 5;
            this.btnBrowseLogPath.Text = "Browse";
            this.btnBrowseLogPath.UseVisualStyleBackColor = true;
            this.btnBrowseLogPath.Click += new System.EventHandler(this.btnBrowseLogPath_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 85);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Logging path :";
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(16, 104);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(201, 20);
            this.txtLogPath.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 39);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "File name :";
            // 
            // txtFileNamePrefix
            // 
            this.txtFileNamePrefix.Location = new System.Drawing.Point(16, 57);
            this.txtFileNamePrefix.Name = "txtFileNamePrefix";
            this.txtFileNamePrefix.Size = new System.Drawing.Size(201, 20);
            this.txtFileNamePrefix.TabIndex = 7;
            // 
            // chkCsvLogging
            // 
            this.chkCsvLogging.AutoSize = true;
            this.chkCsvLogging.Location = new System.Drawing.Point(16, 19);
            this.chkCsvLogging.Name = "chkCsvLogging";
            this.chkCsvLogging.Size = new System.Drawing.Size(87, 17);
            this.chkCsvLogging.TabIndex = 6;
            this.chkCsvLogging.Text = "Logging start";
            this.chkCsvLogging.UseVisualStyleBackColor = true;
            this.chkCsvLogging.CheckedChanged += new System.EventHandler(this.chkCsvLogging_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAutoGet);
            this.groupBox2.Controls.Add(this.cmbSamplingRate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(325, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 83);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control : Auto";
            // 
            // chkAutoGet
            // 
            this.chkAutoGet.AutoSize = true;
            this.chkAutoGet.Location = new System.Drawing.Point(16, 19);
            this.chkAutoGet.Name = "chkAutoGet";
            this.chkAutoGet.Size = new System.Drawing.Size(63, 17);
            this.chkAutoGet.TabIndex = 6;
            this.chkAutoGet.Text = "Autoget";
            this.chkAutoGet.UseVisualStyleBackColor = true;
            this.chkAutoGet.CheckedChanged += new System.EventHandler(this.chkAutoGet_CheckedChanged);
            // 
            // cmbSamplingRate
            // 
            this.cmbSamplingRate.FormattingEnabled = true;
            this.cmbSamplingRate.Location = new System.Drawing.Point(68, 37);
            this.cmbSamplingRate.Name = "cmbSamplingRate";
            this.cmbSamplingRate.Size = new System.Drawing.Size(102, 21);
            this.cmbSamplingRate.TabIndex = 7;
            this.cmbSamplingRate.SelectedIndexChanged += new System.EventHandler(this.cmbSamplingRate_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(175, 40);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "second";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 40);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Sampling";
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAbout.ForeColor = System.Drawing.Color.Blue;
            this.lblAbout.Location = new System.Drawing.Point(530, 375);
            this.lblAbout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(35, 13);
            this.lblAbout.TabIndex = 9;
            this.lblAbout.Text = "About";
            this.lblAbout.Click += new System.EventHandler(this.lblAbout_Click);
            //
            // btnGraphTab
            //
            this.btnGraphTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(45)))), ((int)(((byte)(112)))));
            this.btnGraphTab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(205)))));
            this.btnGraphTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGraphTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnGraphTab.ForeColor = System.Drawing.Color.White;
            this.btnGraphTab.Location = new System.Drawing.Point(574, 72);
            this.btnGraphTab.Name = "btnGraphTab";
            this.btnGraphTab.Size = new System.Drawing.Size(34, 142);
            this.btnGraphTab.TabIndex = 10;
            this.btnGraphTab.TabStop = false;
            this.btnGraphTab.Text = "G\r\nR\r\nA\r\nP\r\nH\r\n▶";
            this.toolTipGraph.SetToolTip(this.btnGraphTab, "Open or close the real-time graph workspace");
            this.btnGraphTab.UseVisualStyleBackColor = false;
            this.btnGraphTab.Click += new System.EventHandler(this.btnGraphTab_Click);
            //
            // pnlGraphWorkspace
            //
            this.pnlGraphWorkspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGraphWorkspace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.pnlGraphWorkspace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGraphWorkspace.Controls.Add(this.splitGraphWorkspace);
            this.pnlGraphWorkspace.Controls.Add(this.pnlGraphToolbar);
            this.pnlGraphWorkspace.Location = new System.Drawing.Point(608, 0);
            this.pnlGraphWorkspace.MinimumSize = new System.Drawing.Size(620, 320);
            this.pnlGraphWorkspace.Name = "pnlGraphWorkspace";
            this.pnlGraphWorkspace.Size = new System.Drawing.Size(720, 393);
            this.pnlGraphWorkspace.TabIndex = 11;
            //
            // splitGraphWorkspace
            //
            this.splitGraphWorkspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitGraphWorkspace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(219)))), ((int)(((byte)(232)))));
            this.splitGraphWorkspace.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitGraphWorkspace.Location = new System.Drawing.Point(0, 64);
            this.splitGraphWorkspace.Name = "splitGraphWorkspace";
            //
            // splitGraphWorkspace.Panel1
            //
            this.splitGraphWorkspace.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.splitGraphWorkspace.Panel1.Controls.Add(this.chartRealtime);
            this.splitGraphWorkspace.Panel1.Padding = new System.Windows.Forms.Padding(6, 4, 2, 6);
            this.splitGraphWorkspace.Panel1MinSize = 350;
            //
            // splitGraphWorkspace.Panel2
            //
            this.splitGraphWorkspace.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.splitGraphWorkspace.Panel2.Controls.Add(this.dgvGraphValues);
            this.splitGraphWorkspace.Panel2.Controls.Add(this.lblGraphProbe);
            this.splitGraphWorkspace.Panel2.Padding = new System.Windows.Forms.Padding(2, 4, 6, 6);
            this.splitGraphWorkspace.Panel2MinSize = 180;
            this.splitGraphWorkspace.Size = new System.Drawing.Size(718, 327);
            this.splitGraphWorkspace.SplitterDistance = 496;
            this.splitGraphWorkspace.SplitterWidth = 4;
            this.splitGraphWorkspace.TabIndex = 1;
            //
            // chartRealtime
            //
            this.chartRealtime.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.All;
            this.chartRealtime.BackColor = System.Drawing.Color.White;
            this.chartRealtime.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(205)))));
            this.chartRealtime.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartRealtime.BorderlineWidth = 1;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.LabelStyle.Format = "HH:mm:ss";
            chartArea1.AxisX.LabelStyle.IsEndLabelVisible = false;
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            chartArea1.AxisX.ScaleView.Zoomable = true;
            chartArea1.AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            chartArea1.AxisX.ScrollBar.Enabled = true;
            chartArea1.AxisX.Title = "";
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            chartArea1.AxisY.Title = "Temperature (°C)";
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY2.Interval = 20D;
            chartArea1.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            chartArea1.AxisY2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.AxisY2.Maximum = 100D;
            chartArea1.AxisY2.Minimum = 0D;
            chartArea1.AxisY2.Title = "Humidity (%RH)";
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 90F;
            chartArea1.InnerPlotPosition.Width = 76F;
            chartArea1.InnerPlotPosition.X = 12F;
            chartArea1.InnerPlotPosition.Y = 4F;
            chartArea1.Name = "Values";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 68F;
            chartArea1.Position.Width = 100F;
            chartArea2.AlignWithChartArea = "Values";
            chartArea2.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical;
            chartArea2.AxisX.LabelStyle.Angle = 0;
            chartArea2.AxisX.LabelStyle.Format = "HH:mm:ss";
            chartArea2.AxisX.LabelStyle.IsEndLabelVisible = false;
            chartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            chartArea2.AxisX.ScaleView.Zoomable = true;
            chartArea2.AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            chartArea2.AxisX.ScrollBar.Enabled = true;
            chartArea2.AxisX.Title = "Time";
            chartArea2.AxisY.CustomLabels.Add(-0.35D, 0.35D, "OFF");
            chartArea2.AxisY.CustomLabels.Add(0.65D, 1.35D, "ON");
            chartArea2.AxisY.Interval = 1D;
            chartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(244)))));
            chartArea2.AxisY.Maximum = 1D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY.Title = "Status";
            chartArea2.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 42F;
            chartArea2.InnerPlotPosition.Width = 76F;
            chartArea2.InnerPlotPosition.X = 12F;
            chartArea2.InnerPlotPosition.Y = 3F;
            chartArea2.Name = "Status";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 31F;
            chartArea2.Position.Width = 100F;
            chartArea2.Position.Y = 67F;
            this.chartRealtime.ChartAreas.Add(chartArea1);
            this.chartRealtime.ChartAreas.Add(chartArea2);
            this.chartRealtime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartRealtime.Location = new System.Drawing.Point(6, 4);
            this.chartRealtime.Name = "chartRealtime";
            series1.BorderWidth = 2;
            series1.ChartArea = "Values";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Firebrick;
            series1.IsVisibleInLegend = false;
            series1.Name = "Temp Set";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.BorderWidth = 2;
            series2.ChartArea = "Values";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.DarkOrange;
            series2.IsVisibleInLegend = false;
            series2.Name = "Temp Actual";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.BorderWidth = 2;
            series3.ChartArea = "Values";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.RoyalBlue;
            series3.IsVisibleInLegend = false;
            series3.Name = "Humi Set";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series4.BorderWidth = 2;
            series4.ChartArea = "Values";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.DeepSkyBlue;
            series4.IsVisibleInLegend = false;
            series4.Name = "Humi Actual";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series4.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series5.BorderWidth = 2;
            series5.ChartArea = "Status";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series5.Color = System.Drawing.Color.Black;
            series5.IsVisibleInLegend = false;
            series5.Name = "On/Off Status";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chartRealtime.Series.Add(series1);
            this.chartRealtime.Series.Add(series2);
            this.chartRealtime.Series.Add(series3);
            this.chartRealtime.Series.Add(series4);
            this.chartRealtime.Series.Add(series5);
            this.chartRealtime.Size = new System.Drawing.Size(488, 317);
            this.chartRealtime.TabIndex = 0;
            this.chartRealtime.Text = "Realtime chamber graph";
            //
            // dgvGraphValues
            //
            this.dgvGraphValues.AllowUserToAddRows = false;
            this.dgvGraphValues.AllowUserToDeleteRows = false;
            this.dgvGraphValues.AllowUserToResizeRows = false;
            this.dgvGraphValues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGraphValues.BackgroundColor = System.Drawing.Color.White;
            this.dgvGraphValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(234)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(48)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGraphValues.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGraphValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGraphValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGraphVisible,
            this.colGraphSignal,
            this.colGraphX,
            this.colGraphY});
            this.dgvGraphValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGraphValues.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvGraphValues.EnableHeadersVisualStyles = false;
            this.dgvGraphValues.Location = new System.Drawing.Point(2, 4);
            this.dgvGraphValues.MultiSelect = false;
            this.dgvGraphValues.Name = "dgvGraphValues";
            this.dgvGraphValues.RowHeadersVisible = false;
            this.dgvGraphValues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGraphValues.Size = new System.Drawing.Size(210, 241);
            this.dgvGraphValues.TabIndex = 0;
            //
            // colGraphVisible
            //
            this.colGraphVisible.FalseValue = false;
            this.colGraphVisible.FillWeight = 35F;
            this.colGraphVisible.HeaderText = "Show";
            this.colGraphVisible.Name = "Visible";
            this.colGraphVisible.TrueValue = true;
            //
            // colGraphSignal
            //
            this.colGraphSignal.FillWeight = 90F;
            this.colGraphSignal.HeaderText = "Signal";
            this.colGraphSignal.Name = "Signal";
            this.colGraphSignal.ReadOnly = true;
            //
            // colGraphX
            //
            this.colGraphX.FillWeight = 68F;
            this.colGraphX.HeaderText = "X";
            this.colGraphX.Name = "X";
            this.colGraphX.ReadOnly = true;
            //
            // colGraphY
            //
            this.colGraphY.FillWeight = 52F;
            this.colGraphY.HeaderText = "Y";
            this.colGraphY.Name = "Y";
            this.colGraphY.ReadOnly = true;
            //
            // lblGraphProbe
            //
            this.lblGraphProbe.BackColor = System.Drawing.Color.White;
            this.lblGraphProbe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGraphProbe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblGraphProbe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(58)))), ((int)(((byte)(75)))));
            this.lblGraphProbe.Location = new System.Drawing.Point(2, 245);
            this.lblGraphProbe.Name = "lblGraphProbe";
            this.lblGraphProbe.Padding = new System.Windows.Forms.Padding(8, 6, 6, 4);
            this.lblGraphProbe.Size = new System.Drawing.Size(210, 76);
            this.lblGraphProbe.TabIndex = 1;
            this.lblGraphProbe.Text = "Probe: click a point on the graph\r\nDrag a rectangle to zoom.";
            //
            // pnlGraphToolbar
            //
            this.pnlGraphToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGraphToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(45)))), ((int)(((byte)(112)))));
            this.pnlGraphToolbar.Controls.Add(this.lblGraphTitle);
            this.pnlGraphToolbar.Controls.Add(this.lblGraphTimeDiv);
            this.pnlGraphToolbar.Controls.Add(this.cmbGraphTimeDiv);
            this.pnlGraphToolbar.Controls.Add(this.chkGraphAutoFollow);
            this.pnlGraphToolbar.Controls.Add(this.btnGraphResetView);
            this.pnlGraphToolbar.Controls.Add(this.lblGraphSampling);
            this.pnlGraphToolbar.Controls.Add(this.lblGraphMouseMode);
            this.pnlGraphToolbar.Controls.Add(this.cmbGraphMouseMode);
            this.pnlGraphToolbar.Controls.Add(this.lblGraphTempRange);
            this.pnlGraphToolbar.Controls.Add(this.txtGraphTempMin);
            this.pnlGraphToolbar.Controls.Add(this.lblGraphTempTo);
            this.pnlGraphToolbar.Controls.Add(this.txtGraphTempMax);
            this.pnlGraphToolbar.Controls.Add(this.lblGraphHumiRange);
            this.pnlGraphToolbar.Controls.Add(this.txtGraphHumiMin);
            this.pnlGraphToolbar.Controls.Add(this.lblGraphHumiTo);
            this.pnlGraphToolbar.Controls.Add(this.txtGraphHumiMax);
            this.pnlGraphToolbar.Controls.Add(this.btnGraphApplyY);
            this.pnlGraphToolbar.Controls.Add(this.btnGraphAutoY);
            this.pnlGraphToolbar.Controls.Add(this.lblGraphMouseHint);
            this.pnlGraphToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlGraphToolbar.Name = "pnlGraphToolbar";
            this.pnlGraphToolbar.Size = new System.Drawing.Size(718, 64);
            this.pnlGraphToolbar.TabIndex = 0;
            //
            // lblGraphTitle
            //
            this.lblGraphTitle.AutoSize = true;
            this.lblGraphTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblGraphTitle.ForeColor = System.Drawing.Color.White;
            this.lblGraphTitle.Location = new System.Drawing.Point(10, 10);
            this.lblGraphTitle.Name = "lblGraphTitle";
            this.lblGraphTitle.Size = new System.Drawing.Size(125, 15);
            this.lblGraphTitle.TabIndex = 0;
            this.lblGraphTitle.Text = "SIGNAL WORKSPACE";
            //
            // lblGraphTimeDiv
            //
            this.lblGraphTimeDiv.AutoSize = true;
            this.lblGraphTimeDiv.ForeColor = System.Drawing.Color.White;
            this.lblGraphTimeDiv.Location = new System.Drawing.Point(142, 11);
            this.lblGraphTimeDiv.Name = "lblGraphTimeDiv";
            this.lblGraphTimeDiv.Size = new System.Drawing.Size(50, 13);
            this.lblGraphTimeDiv.TabIndex = 1;
            this.lblGraphTimeDiv.Text = "Time/Div";
            //
            // cmbGraphTimeDiv
            //
            this.cmbGraphTimeDiv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGraphTimeDiv.FormattingEnabled = true;
            this.cmbGraphTimeDiv.Items.AddRange(new object[] {
            "10 s",
            "30 s",
            "1 min",
            "5 min",
            "10 min",
            "30 min",
            "1 hr",
            "6 hr",
            "All (24 hr)"});
            this.cmbGraphTimeDiv.Location = new System.Drawing.Point(198, 7);
            this.cmbGraphTimeDiv.Name = "cmbGraphTimeDiv";
            this.cmbGraphTimeDiv.Size = new System.Drawing.Size(94, 21);
            this.cmbGraphTimeDiv.TabIndex = 2;
            //
            // chkGraphAutoFollow
            //
            this.chkGraphAutoFollow.AutoSize = true;
            this.chkGraphAutoFollow.BackColor = System.Drawing.Color.Transparent;
            this.chkGraphAutoFollow.Checked = true;
            this.chkGraphAutoFollow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGraphAutoFollow.ForeColor = System.Drawing.Color.White;
            this.chkGraphAutoFollow.Location = new System.Drawing.Point(302, 9);
            this.chkGraphAutoFollow.Name = "chkGraphAutoFollow";
            this.chkGraphAutoFollow.Size = new System.Drawing.Size(81, 17);
            this.chkGraphAutoFollow.TabIndex = 3;
            this.chkGraphAutoFollow.Text = "Auto Follow";
            this.chkGraphAutoFollow.UseVisualStyleBackColor = false;
            //
            // btnGraphResetView
            //
            this.btnGraphResetView.BackColor = System.Drawing.Color.White;
            this.btnGraphResetView.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(184)))), ((int)(((byte)(224)))));
            this.btnGraphResetView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGraphResetView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(45)))), ((int)(((byte)(112)))));
            this.btnGraphResetView.Location = new System.Drawing.Point(392, 5);
            this.btnGraphResetView.Name = "btnGraphResetView";
            this.btnGraphResetView.Size = new System.Drawing.Size(82, 26);
            this.btnGraphResetView.TabIndex = 4;
            this.btnGraphResetView.Text = "Reset View";
            this.btnGraphResetView.UseVisualStyleBackColor = false;
            //
            // lblGraphSampling
            //
            this.lblGraphSampling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGraphSampling.AutoEllipsis = true;
            this.lblGraphSampling.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblGraphSampling.Location = new System.Drawing.Point(482, 10);
            this.lblGraphSampling.Name = "lblGraphSampling";
            this.lblGraphSampling.Size = new System.Drawing.Size(230, 18);
            this.lblGraphSampling.TabIndex = 5;
            this.lblGraphSampling.Text = "Source: Hold last value  |  Sampling: 10s";
            this.lblGraphSampling.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            // lblGraphMouseMode
            //
            this.lblGraphMouseMode.AutoSize = true;
            this.lblGraphMouseMode.ForeColor = System.Drawing.Color.White;
            this.lblGraphMouseMode.Location = new System.Drawing.Point(10, 42);
            this.lblGraphMouseMode.Name = "lblGraphMouseMode";
            this.lblGraphMouseMode.Size = new System.Drawing.Size(34, 13);
            this.lblGraphMouseMode.TabIndex = 6;
            this.lblGraphMouseMode.Text = "Mode";
            //
            // cmbGraphMouseMode
            //
            this.cmbGraphMouseMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGraphMouseMode.FormattingEnabled = true;
            this.cmbGraphMouseMode.Items.AddRange(new object[] {
            "Zoom Box",
            "Pan Hand"});
            this.cmbGraphMouseMode.Location = new System.Drawing.Point(47, 37);
            this.cmbGraphMouseMode.Name = "cmbGraphMouseMode";
            this.cmbGraphMouseMode.Size = new System.Drawing.Size(82, 21);
            this.cmbGraphMouseMode.TabIndex = 7;
            this.toolTipGraph.SetToolTip(this.cmbGraphMouseMode, "Zoom Box: drag a rectangle. Pan Hand: drag left or right.");
            //
            // lblGraphTempRange
            //
            this.lblGraphTempRange.AutoSize = true;
            this.lblGraphTempRange.ForeColor = System.Drawing.Color.White;
            this.lblGraphTempRange.Location = new System.Drawing.Point(136, 42);
            this.lblGraphTempRange.Name = "lblGraphTempRange";
            this.lblGraphTempRange.Size = new System.Drawing.Size(46, 13);
            this.lblGraphTempRange.TabIndex = 8;
            this.lblGraphTempRange.Text = "Temp °C";
            //
            // txtGraphTempMin
            //
            this.txtGraphTempMin.Location = new System.Drawing.Point(184, 38);
            this.txtGraphTempMin.Name = "txtGraphTempMin";
            this.txtGraphTempMin.Size = new System.Drawing.Size(40, 20);
            this.txtGraphTempMin.TabIndex = 9;
            this.txtGraphTempMin.Text = "-40";
            this.txtGraphTempMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // lblGraphTempTo
            //
            this.lblGraphTempTo.AutoSize = true;
            this.lblGraphTempTo.ForeColor = System.Drawing.Color.White;
            this.lblGraphTempTo.Location = new System.Drawing.Point(227, 42);
            this.lblGraphTempTo.Name = "lblGraphTempTo";
            this.lblGraphTempTo.Size = new System.Drawing.Size(10, 13);
            this.lblGraphTempTo.TabIndex = 10;
            this.lblGraphTempTo.Text = "-";
            //
            // txtGraphTempMax
            //
            this.txtGraphTempMax.Location = new System.Drawing.Point(239, 38);
            this.txtGraphTempMax.Name = "txtGraphTempMax";
            this.txtGraphTempMax.Size = new System.Drawing.Size(40, 20);
            this.txtGraphTempMax.TabIndex = 11;
            this.txtGraphTempMax.Text = "120";
            this.txtGraphTempMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // lblGraphHumiRange
            //
            this.lblGraphHumiRange.AutoSize = true;
            this.lblGraphHumiRange.ForeColor = System.Drawing.Color.White;
            this.lblGraphHumiRange.Location = new System.Drawing.Point(287, 42);
            this.lblGraphHumiRange.Name = "lblGraphHumiRange";
            this.lblGraphHumiRange.Size = new System.Drawing.Size(44, 13);
            this.lblGraphHumiRange.TabIndex = 12;
            this.lblGraphHumiRange.Text = "Humi %";
            //
            // txtGraphHumiMin
            //
            this.txtGraphHumiMin.Location = new System.Drawing.Point(334, 38);
            this.txtGraphHumiMin.Name = "txtGraphHumiMin";
            this.txtGraphHumiMin.Size = new System.Drawing.Size(38, 20);
            this.txtGraphHumiMin.TabIndex = 13;
            this.txtGraphHumiMin.Text = "0";
            this.txtGraphHumiMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // lblGraphHumiTo
            //
            this.lblGraphHumiTo.AutoSize = true;
            this.lblGraphHumiTo.ForeColor = System.Drawing.Color.White;
            this.lblGraphHumiTo.Location = new System.Drawing.Point(375, 42);
            this.lblGraphHumiTo.Name = "lblGraphHumiTo";
            this.lblGraphHumiTo.Size = new System.Drawing.Size(10, 13);
            this.lblGraphHumiTo.TabIndex = 14;
            this.lblGraphHumiTo.Text = "-";
            //
            // txtGraphHumiMax
            //
            this.txtGraphHumiMax.Location = new System.Drawing.Point(387, 38);
            this.txtGraphHumiMax.Name = "txtGraphHumiMax";
            this.txtGraphHumiMax.Size = new System.Drawing.Size(38, 20);
            this.txtGraphHumiMax.TabIndex = 15;
            this.txtGraphHumiMax.Text = "100";
            this.txtGraphHumiMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // btnGraphApplyY
            //
            this.btnGraphApplyY.BackColor = System.Drawing.Color.White;
            this.btnGraphApplyY.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(184)))), ((int)(((byte)(224)))));
            this.btnGraphApplyY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGraphApplyY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(45)))), ((int)(((byte)(112)))));
            this.btnGraphApplyY.Location = new System.Drawing.Point(434, 35);
            this.btnGraphApplyY.Name = "btnGraphApplyY";
            this.btnGraphApplyY.Size = new System.Drawing.Size(64, 26);
            this.btnGraphApplyY.TabIndex = 16;
            this.btnGraphApplyY.Text = "Apply Y";
            this.btnGraphApplyY.UseVisualStyleBackColor = false;
            //
            // btnGraphAutoY
            //
            this.btnGraphAutoY.BackColor = System.Drawing.Color.White;
            this.btnGraphAutoY.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(184)))), ((int)(((byte)(224)))));
            this.btnGraphAutoY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGraphAutoY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(45)))), ((int)(((byte)(112)))));
            this.btnGraphAutoY.Location = new System.Drawing.Point(504, 35);
            this.btnGraphAutoY.Name = "btnGraphAutoY";
            this.btnGraphAutoY.Size = new System.Drawing.Size(58, 26);
            this.btnGraphAutoY.TabIndex = 17;
            this.btnGraphAutoY.Text = "Y Auto";
            this.btnGraphAutoY.UseVisualStyleBackColor = false;
            //
            // lblGraphMouseHint
            //
            this.lblGraphMouseHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblGraphMouseHint.Location = new System.Drawing.Point(568, 38);
            this.lblGraphMouseHint.Name = "lblGraphMouseHint";
            this.lblGraphMouseHint.Size = new System.Drawing.Size(144, 22);
            this.lblGraphMouseHint.TabIndex = 18;
            this.lblGraphMouseHint.Text = "Drag: rectangle zoom";
            this.lblGraphMouseHint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 393);
            this.Controls.Add(this.pnlGraphWorkspace);
            this.Controls.Add(this.btnGraphTab);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weiss/Votsch Control - DQT EVSBG DELTA v2.1.08.2026 DET9-RD1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpComm.ResumeLayout(false);
            this.grpComm.PerformLayout();
            this.grpControl.ResumeLayout(false);
            this.grpControl.PerformLayout();
            this.grpMonitoring.ResumeLayout(false);
            this.grpMonitoring.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlGraphWorkspace.ResumeLayout(false);
            this.splitGraphWorkspace.Panel1.ResumeLayout(false);
            this.splitGraphWorkspace.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitGraphWorkspace)).EndInit();
            this.splitGraphWorkspace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRealtime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGraphValues)).EndInit();
            this.pnlGraphToolbar.ResumeLayout(false);
            this.pnlGraphToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpComm;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtBaudRate;
        private System.Windows.Forms.Label lblCommStatus;
        private System.Windows.Forms.Label lblBaud;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtErrStr;
        private System.Windows.Forms.GroupBox grpControl;
        private System.Windows.Forms.Button btnSetHumidity;
        private System.Windows.Forms.Button btnSetTemp;
        private System.Windows.Forms.TextBox txtSetHumidity;
        private System.Windows.Forms.TextBox txtSetTemp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnableChamber;
        private System.Windows.Forms.GroupBox grpMonitoring;
        private System.Windows.Forms.Button btnGetHumidity;
        private System.Windows.Forms.Button btnGetCurrentTemp;
        private System.Windows.Forms.TextBox txtCurrentHumidity;
        private System.Windows.Forms.TextBox txtCurrentTemp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblChamberStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbLogFileMode;
        private System.Windows.Forms.Button btnBrowseLogPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFileNamePrefix;
        private System.Windows.Forms.CheckBox chkCsvLogging;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAutoGet;
        private System.Windows.Forms.ComboBox cmbSamplingRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Button btnGraphTab;
        private System.Windows.Forms.Panel pnlGraphWorkspace;
        private System.Windows.Forms.SplitContainer splitGraphWorkspace;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRealtime;
        private System.Windows.Forms.DataGridView dgvGraphValues;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colGraphVisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGraphSignal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGraphX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGraphY;
        private System.Windows.Forms.Label lblGraphProbe;
        private System.Windows.Forms.Panel pnlGraphToolbar;
        private System.Windows.Forms.Label lblGraphTitle;
        private System.Windows.Forms.Label lblGraphTimeDiv;
        private System.Windows.Forms.ComboBox cmbGraphTimeDiv;
        private System.Windows.Forms.CheckBox chkGraphAutoFollow;
        private System.Windows.Forms.Button btnGraphResetView;
        private System.Windows.Forms.Label lblGraphSampling;
        private System.Windows.Forms.Label lblGraphMouseMode;
        private System.Windows.Forms.ComboBox cmbGraphMouseMode;
        private System.Windows.Forms.Label lblGraphTempRange;
        private System.Windows.Forms.TextBox txtGraphTempMin;
        private System.Windows.Forms.Label lblGraphTempTo;
        private System.Windows.Forms.TextBox txtGraphTempMax;
        private System.Windows.Forms.Label lblGraphHumiRange;
        private System.Windows.Forms.TextBox txtGraphHumiMin;
        private System.Windows.Forms.Label lblGraphHumiTo;
        private System.Windows.Forms.TextBox txtGraphHumiMax;
        private System.Windows.Forms.Button btnGraphApplyY;
        private System.Windows.Forms.Button btnGraphAutoY;
        private System.Windows.Forms.Label lblGraphMouseHint;
        private System.Windows.Forms.ToolTip toolTipGraph;

        // New controls for TCP/Serial mode
        private System.Windows.Forms.RadioButton radioSerial;
        private System.Windows.Forms.RadioButton radioTcp;
        private System.Windows.Forms.TextBox txtTcpHost;
        private System.Windows.Forms.TextBox txtTcpPort;
    }
}
