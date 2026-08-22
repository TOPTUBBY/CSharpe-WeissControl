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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.grpComm = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.lblCommStatus = new System.Windows.Forms.Label();
            this.lblBaud = new System.Windows.Forms.Label();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
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
            this.grpComm.SuspendLayout();
            this.grpControl.SuspendLayout();
            this.grpMonitoring.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpComm
            // 
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
            this.grpComm.Size = new System.Drawing.Size(308, 74);
            this.grpComm.TabIndex = 0;
            this.grpComm.TabStop = false;
            this.grpComm.Text = "Communication Status";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(224, 31);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(76, 36);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(164, 31);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(56, 36);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.Location = new System.Drawing.Point(100, 40);
            this.txtBaudRate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(56, 20);
            this.txtBaudRate.TabIndex = 4;
            this.txtBaudRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCommStatus
            // 
            this.lblCommStatus.AutoSize = true;
            this.lblCommStatus.Location = new System.Drawing.Point(161, 14);
            this.lblCommStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCommStatus.Name = "lblCommStatus";
            this.lblCommStatus.Size = new System.Drawing.Size(40, 13);
            this.lblCommStatus.TabIndex = 3;
            this.lblCommStatus.Text = "Status:";
            // 
            // lblBaud
            // 
            this.lblBaud.AutoSize = true;
            this.lblBaud.Location = new System.Drawing.Point(100, 15);
            this.lblBaud.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBaud.Name = "lblBaud";
            this.lblBaud.Size = new System.Drawing.Size(50, 13);
            this.lblBaud.TabIndex = 3;
            this.lblBaud.Text = "Buadrate";
            // 
            // cmbPortName
            // 
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(14, 40);
            this.cmbPortName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(81, 21);
            this.cmbPortName.TabIndex = 2;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(12, 14);
            this.lblPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(49, 13);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Com port";
            // 
            // txtErrStr
            // 
            this.txtErrStr.Location = new System.Drawing.Point(12, 240);
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
            this.grpControl.Location = new System.Drawing.Point(12, 96);
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
            this.btnEnableChamber.Location = new System.Drawing.Point(239, 103);
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
            this.grpMonitoring.Location = new System.Drawing.Point(12, 168);
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
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnEnableChamber);
            this.groupBox1.Controls.Add(this.grpComm);
            this.groupBox1.Controls.Add(this.grpMonitoring);
            this.groupBox1.Controls.Add(this.txtErrStr);
            this.groupBox1.Controls.Add(this.grpControl);
            this.groupBox1.Location = new System.Drawing.Point(7, 50);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(559, 330);
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
            this.groupBox2.Size = new System.Drawing.Size(223, 74);
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
            this.lblAbout.Location = new System.Drawing.Point(530, 372);
            this.lblAbout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(35, 13);
            this.lblAbout.TabIndex = 9;
            this.lblAbout.Text = "About";
            this.lblAbout.Click += new System.EventHandler(this.lblAbout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 392);
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
            this.Text = "Weiss/Votsch Control - DQT EVSBG DELTA v1.1.08.2026 DET9-RD1";
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpComm;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtBaudRate;
        private System.Windows.Forms.Label lblBaud;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox txtErrStr;
        private System.Windows.Forms.Label lblCommStatus;
        private System.Windows.Forms.GroupBox grpControl;
        private System.Windows.Forms.Button btnEnableChamber;
        private System.Windows.Forms.TextBox txtSetHumidity;
        private System.Windows.Forms.TextBox txtSetTemp;
        private System.Windows.Forms.GroupBox grpMonitoring;
        private System.Windows.Forms.Button btnGetHumidity;
        private System.Windows.Forms.Button btnGetCurrentTemp;
        private System.Windows.Forms.TextBox txtCurrentHumidity;
        private System.Windows.Forms.TextBox txtCurrentTemp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetHumidity;
        private System.Windows.Forms.Button btnSetTemp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblChamberStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAutoGet;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbLogFileMode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSamplingRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFileNamePrefix;
        private System.Windows.Forms.CheckBox chkCsvLogging;
        private System.Windows.Forms.Button btnBrowseLogPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Label lblAbout;
    }
}
