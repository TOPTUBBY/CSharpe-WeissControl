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
            this.btnEnableChamber = new System.Windows.Forms.Button();
            this.tbTempHotChamAct = new System.Windows.Forms.TextBox();
            this.lblChamberStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbTempCradSet = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTempCradAct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCycleAct = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCycleSet = new System.Windows.Forms.TextBox();
            this.lblAbout = new System.Windows.Forms.Label();
            this.tbTempColdChamAct = new System.Windows.Forms.TextBox();
            this.tbTempColdChamSet = new System.Windows.Forms.TextBox();
            this.tbTempHotChamSet = new System.Windows.Forms.TextBox();
            this.btnSetCradPos = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBrowseLogPath = new System.Windows.Forms.Button();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFileNamePrefix = new System.Windows.Forms.TextBox();
            this.chkCsvLogging = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnManualGet = new System.Windows.Forms.Button();
            this.chkAutoGet = new System.Windows.Forms.CheckBox();
            this.cmbSamplingRate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbCradPos = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpComm.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCradPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.grpComm.Margin = new System.Windows.Forms.Padding(2);
            this.grpComm.Name = "grpComm";
            this.grpComm.Padding = new System.Windows.Forms.Padding(2);
            this.grpComm.Size = new System.Drawing.Size(352, 83);
            this.grpComm.TabIndex = 0;
            this.grpComm.TabStop = false;
            this.grpComm.Text = "Communication Status";
            // 
            // txtTcpPort
            // 
            this.txtTcpPort.BackColor = System.Drawing.SystemColors.Window;
            this.txtTcpPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTcpPort.Enabled = false;
            this.txtTcpPort.Location = new System.Drawing.Point(104, 56);
            this.txtTcpPort.Margin = new System.Windows.Forms.Padding(2);
            this.txtTcpPort.Name = "txtTcpPort";
            this.txtTcpPort.Size = new System.Drawing.Size(66, 20);
            this.txtTcpPort.TabIndex = 13;
            this.txtTcpPort.Text = "2049";
            this.txtTcpPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTcpHost
            // 
            this.txtTcpHost.BackColor = System.Drawing.SystemColors.Window;
            this.txtTcpHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTcpHost.Enabled = false;
            this.txtTcpHost.Location = new System.Drawing.Point(19, 56);
            this.txtTcpHost.Margin = new System.Windows.Forms.Padding(2);
            this.txtTcpHost.Name = "txtTcpHost";
            this.txtTcpHost.Size = new System.Drawing.Size(81, 20);
            this.txtTcpHost.TabIndex = 12;
            this.txtTcpHost.Text = "169.254.0.2";
            this.txtTcpHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(266, 33);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(76, 41);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(182, 33);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(76, 41);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.BackColor = System.Drawing.SystemColors.Window;
            this.txtBaudRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBaudRate.Location = new System.Drawing.Point(104, 34);
            this.txtBaudRate.Margin = new System.Windows.Forms.Padding(2);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(66, 20);
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
            this.cmbPortName.BackColor = System.Drawing.SystemColors.Window;
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(19, 33);
            this.cmbPortName.Margin = new System.Windows.Forms.Padding(2);
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
            this.radioTcp.Margin = new System.Windows.Forms.Padding(2);
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
            this.radioSerial.Margin = new System.Windows.Forms.Padding(2);
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
            this.txtErrStr.BackColor = System.Drawing.SystemColors.Control;
            this.txtErrStr.Location = new System.Drawing.Point(12, 454);
            this.txtErrStr.Margin = new System.Windows.Forms.Padding(2);
            this.txtErrStr.Multiline = true;
            this.txtErrStr.Name = "txtErrStr";
            this.txtErrStr.ReadOnly = true;
            this.txtErrStr.Size = new System.Drawing.Size(648, 79);
            this.txtErrStr.TabIndex = 4;
            this.txtErrStr.Text = "Comm Status String";
            // 
            // btnEnableChamber
            // 
            this.btnEnableChamber.Location = new System.Drawing.Point(580, 105);
            this.btnEnableChamber.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnableChamber.Name = "btnEnableChamber";
            this.btnEnableChamber.Size = new System.Drawing.Size(81, 204);
            this.btnEnableChamber.TabIndex = 5;
            this.btnEnableChamber.Text = "ON";
            this.btnEnableChamber.UseVisualStyleBackColor = true;
            this.btnEnableChamber.Click += new System.EventHandler(this.btnEnableChamber_Click);
            // 
            // tbTempHotChamAct
            // 
            this.tbTempHotChamAct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.tbTempHotChamAct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTempHotChamAct.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F);
            this.tbTempHotChamAct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(67)))));
            this.tbTempHotChamAct.Location = new System.Drawing.Point(475, 133);
            this.tbTempHotChamAct.Margin = new System.Windows.Forms.Padding(2);
            this.tbTempHotChamAct.Name = "tbTempHotChamAct";
            this.tbTempHotChamAct.ReadOnly = true;
            this.tbTempHotChamAct.Size = new System.Drawing.Size(63, 28);
            this.tbTempHotChamAct.TabIndex = 4;
            this.tbTempHotChamAct.Text = "220.0";
            this.tbTempHotChamAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblChamberStatus
            // 
            this.lblChamberStatus.AutoSize = true;
            this.lblChamberStatus.BackColor = System.Drawing.Color.LightGray;
            this.lblChamberStatus.Font = new System.Drawing.Font("Noto Sans TC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChamberStatus.ForeColor = System.Drawing.Color.Black;
            this.lblChamberStatus.Location = new System.Drawing.Point(611, 3);
            this.lblChamberStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChamberStatus.Name = "lblChamberStatus";
            this.lblChamberStatus.Size = new System.Drawing.Size(57, 32);
            this.lblChamberStatus.TabIndex = 6;
            this.lblChamberStatus.Text = "OFF";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.lblChamberStatus);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
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
            this.label5.Size = new System.Drawing.Size(428, 32);
            this.label5.TabIndex = 1;
            this.label5.Text = "Weiss Thermal Shock Monitoring";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Olive;
            this.panel2.Location = new System.Drawing.Point(-1, 37);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1766, 8);
            this.panel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.tbTempCradSet);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbTempCradAct);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pictureBox6);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.lblAbout);
            this.groupBox1.Controls.Add(this.tbTempColdChamAct);
            this.groupBox1.Controls.Add(this.tbTempHotChamAct);
            this.groupBox1.Controls.Add(this.tbTempColdChamSet);
            this.groupBox1.Controls.Add(this.tbTempHotChamSet);
            this.groupBox1.Controls.Add(this.btnSetCradPos);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.radioTcp);
            this.groupBox1.Controls.Add(this.radioSerial);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnEnableChamber);
            this.groupBox1.Controls.Add(this.grpComm);
            this.groupBox1.Controls.Add(this.txtErrStr);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pbCradPos);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(7, 50);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(670, 545);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // tbTempCradSet
            // 
            this.tbTempCradSet.BackColor = System.Drawing.SystemColors.Window;
            this.tbTempCradSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTempCradSet.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTempCradSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(67)))));
            this.tbTempCradSet.Location = new System.Drawing.Point(287, 201);
            this.tbTempCradSet.Margin = new System.Windows.Forms.Padding(2);
            this.tbTempCradSet.Name = "tbTempCradSet";
            this.tbTempCradSet.Size = new System.Drawing.Size(74, 28);
            this.tbTempCradSet.TabIndex = 4;
            this.tbTempCradSet.Text = "50.0";
            this.tbTempCradSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbTempCradSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSet_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.label7.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(67)))));
            this.label7.Location = new System.Drawing.Point(360, 208);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 21);
            this.label7.TabIndex = 3;
            this.label7.Text = "°C";
            // 
            // tbTempCradAct
            // 
            this.tbTempCradAct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.tbTempCradAct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTempCradAct.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTempCradAct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(67)))));
            this.tbTempCradAct.Location = new System.Drawing.Point(475, 201);
            this.tbTempCradAct.Margin = new System.Windows.Forms.Padding(2);
            this.tbTempCradAct.Name = "tbTempCradAct";
            this.tbTempCradAct.ReadOnly = true;
            this.tbTempCradAct.Size = new System.Drawing.Size(63, 28);
            this.tbTempCradAct.TabIndex = 4;
            this.tbTempCradAct.Text = "50.0";
            this.tbTempCradAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbTempCradAct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSet_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(67)))));
            this.label2.Location = new System.Drawing.Point(537, 208);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "°C";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(398, 175);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(176, 64);
            this.pictureBox6.TabIndex = 14;
            this.pictureBox6.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.tbCycleAct);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.tbCycleSet);
            this.groupBox4.Location = new System.Drawing.Point(259, 314);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(401, 42);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(67)))));
            this.label4.Location = new System.Drawing.Point(240, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "CYCLES";
            // 
            // tbCycleAct
            // 
            this.tbCycleAct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.tbCycleAct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCycleAct.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCycleAct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(67)))));
            this.tbCycleAct.Location = new System.Drawing.Point(71, 9);
            this.tbCycleAct.Margin = new System.Windows.Forms.Padding(2);
            this.tbCycleAct.Name = "tbCycleAct";
            this.tbCycleAct.ReadOnly = true;
            this.tbCycleAct.Size = new System.Drawing.Size(81, 28);
            this.tbCycleAct.TabIndex = 15;
            this.tbCycleAct.Text = "1000";
            this.tbCycleAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(151, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "/";
            // 
            // tbCycleSet
            // 
            this.tbCycleSet.BackColor = System.Drawing.SystemColors.Window;
            this.tbCycleSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCycleSet.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCycleSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(67)))));
            this.tbCycleSet.Location = new System.Drawing.Point(174, 9);
            this.tbCycleSet.Margin = new System.Windows.Forms.Padding(2);
            this.tbCycleSet.Name = "tbCycleSet";
            this.tbCycleSet.Size = new System.Drawing.Size(63, 28);
            this.tbCycleSet.TabIndex = 15;
            this.tbCycleSet.Text = "1000";
            this.tbCycleSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbCycleSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSet_KeyPress);
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAbout.ForeColor = System.Drawing.Color.Blue;
            this.lblAbout.Location = new System.Drawing.Point(634, 534);
            this.lblAbout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(35, 13);
            this.lblAbout.TabIndex = 9;
            this.lblAbout.Text = "About";
            this.lblAbout.Click += new System.EventHandler(this.lblAbout_Click);
            // 
            // tbTempColdChamAct
            // 
            this.tbTempColdChamAct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.tbTempColdChamAct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTempColdChamAct.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F);
            this.tbTempColdChamAct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(67)))));
            this.tbTempColdChamAct.Location = new System.Drawing.Point(475, 273);
            this.tbTempColdChamAct.Margin = new System.Windows.Forms.Padding(2);
            this.tbTempColdChamAct.Name = "tbTempColdChamAct";
            this.tbTempColdChamAct.ReadOnly = true;
            this.tbTempColdChamAct.Size = new System.Drawing.Size(63, 28);
            this.tbTempColdChamAct.TabIndex = 4;
            this.tbTempColdChamAct.Text = "-80.0";
            this.tbTempColdChamAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbTempColdChamSet
            // 
            this.tbTempColdChamSet.BackColor = System.Drawing.SystemColors.Window;
            this.tbTempColdChamSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTempColdChamSet.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTempColdChamSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(67)))));
            this.tbTempColdChamSet.Location = new System.Drawing.Point(292, 273);
            this.tbTempColdChamSet.Margin = new System.Windows.Forms.Padding(2);
            this.tbTempColdChamSet.Name = "tbTempColdChamSet";
            this.tbTempColdChamSet.Size = new System.Drawing.Size(69, 28);
            this.tbTempColdChamSet.TabIndex = 4;
            this.tbTempColdChamSet.Text = "-80.0";
            this.tbTempColdChamSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbTempColdChamSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSet_KeyPress);
            // 
            // tbTempHotChamSet
            // 
            this.tbTempHotChamSet.BackColor = System.Drawing.SystemColors.Window;
            this.tbTempHotChamSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTempHotChamSet.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTempHotChamSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(67)))));
            this.tbTempHotChamSet.Location = new System.Drawing.Point(287, 133);
            this.tbTempHotChamSet.Margin = new System.Windows.Forms.Padding(2);
            this.tbTempHotChamSet.Name = "tbTempHotChamSet";
            this.tbTempHotChamSet.Size = new System.Drawing.Size(74, 28);
            this.tbTempHotChamSet.TabIndex = 4;
            this.tbTempHotChamSet.Text = "220.0";
            this.tbTempHotChamSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbTempHotChamSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSet_KeyPress);
            // 
            // btnSetCradPos
            // 
            this.btnSetCradPos.BackColor = System.Drawing.SystemColors.Control;
            this.btnSetCradPos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetCradPos.BackgroundImage")));
            this.btnSetCradPos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetCradPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetCradPos.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSetCradPos.Location = new System.Drawing.Point(209, 316);
            this.btnSetCradPos.Name = "btnSetCradPos";
            this.btnSetCradPos.Size = new System.Drawing.Size(44, 40);
            this.btnSetCradPos.TabIndex = 12;
            this.btnSetCradPos.UseVisualStyleBackColor = false;
            this.btnSetCradPos.Click += new System.EventHandler(this.btnSetCradPos_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.btnBrowseLogPath);
            this.groupBox3.Controls.Add(this.txtLogPath);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtFileNamePrefix);
            this.groupBox3.Controls.Add(this.chkCsvLogging);
            this.groupBox3.Location = new System.Drawing.Point(209, 362);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(451, 87);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logging";
            // 
            // btnBrowseLogPath
            // 
            this.btnBrowseLogPath.Location = new System.Drawing.Point(16, 41);
            this.btnBrowseLogPath.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowseLogPath.Name = "btnBrowseLogPath";
            this.btnBrowseLogPath.Size = new System.Drawing.Size(88, 35);
            this.btnBrowseLogPath.TabIndex = 5;
            this.btnBrowseLogPath.Text = "Browse";
            this.btnBrowseLogPath.UseVisualStyleBackColor = true;
            this.btnBrowseLogPath.Click += new System.EventHandler(this.btnBrowseLogPath_Click);
            // 
            // txtLogPath
            // 
            this.txtLogPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtLogPath.Location = new System.Drawing.Point(148, 56);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(297, 20);
            this.txtLogPath.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(85, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "File name :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(108, 59);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Path :";
            // 
            // txtFileNamePrefix
            // 
            this.txtFileNamePrefix.BackColor = System.Drawing.SystemColors.Window;
            this.txtFileNamePrefix.Location = new System.Drawing.Point(148, 17);
            this.txtFileNamePrefix.Name = "txtFileNamePrefix";
            this.txtFileNamePrefix.Size = new System.Drawing.Size(297, 20);
            this.txtFileNamePrefix.TabIndex = 7;
            // 
            // chkCsvLogging
            // 
            this.chkCsvLogging.AutoSize = true;
            this.chkCsvLogging.Location = new System.Drawing.Point(16, 19);
            this.chkCsvLogging.Name = "chkCsvLogging";
            this.chkCsvLogging.Size = new System.Drawing.Size(64, 17);
            this.chkCsvLogging.TabIndex = 6;
            this.chkCsvLogging.Text = "Logging";
            this.chkCsvLogging.UseVisualStyleBackColor = true;
            this.chkCsvLogging.CheckedChanged += new System.EventHandler(this.chkCsvLogging_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnManualGet);
            this.groupBox2.Controls.Add(this.chkAutoGet);
            this.groupBox2.Controls.Add(this.cmbSamplingRate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(369, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 83);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // btnManualGet
            // 
            this.btnManualGet.Location = new System.Drawing.Point(15, 16);
            this.btnManualGet.Margin = new System.Windows.Forms.Padding(2);
            this.btnManualGet.Name = "btnManualGet";
            this.btnManualGet.Size = new System.Drawing.Size(64, 59);
            this.btnManualGet.TabIndex = 15;
            this.btnManualGet.Text = "UPDATE VALUE";
            this.btnManualGet.UseVisualStyleBackColor = true;
            this.btnManualGet.Click += new System.EventHandler(this.btnGetCurrentParams_Click);
            // 
            // chkAutoGet
            // 
            this.chkAutoGet.AutoSize = true;
            this.chkAutoGet.Location = new System.Drawing.Point(100, 21);
            this.chkAutoGet.Name = "chkAutoGet";
            this.chkAutoGet.Size = new System.Drawing.Size(103, 17);
            this.chkAutoGet.TabIndex = 6;
            this.chkAutoGet.Text = "AUTO UPDATE";
            this.chkAutoGet.UseVisualStyleBackColor = true;
            this.chkAutoGet.CheckedChanged += new System.EventHandler(this.chkAutoGet_CheckedChanged);
            // 
            // cmbSamplingRate
            // 
            this.cmbSamplingRate.BackColor = System.Drawing.SystemColors.Window;
            this.cmbSamplingRate.FormattingEnabled = true;
            this.cmbSamplingRate.Location = new System.Drawing.Point(179, 44);
            this.cmbSamplingRate.Name = "cmbSamplingRate";
            this.cmbSamplingRate.Size = new System.Drawing.Size(102, 21);
            this.cmbSamplingRate.TabIndex = 7;
            this.cmbSamplingRate.SelectedIndexChanged += new System.EventHandler(this.cmbSamplingRate_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 47);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Sampling time :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.label13.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(67)))));
            this.label13.Location = new System.Drawing.Point(537, 280);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 21);
            this.label13.TabIndex = 3;
            this.label13.Text = "°C";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.label11.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(67)))));
            this.label11.Location = new System.Drawing.Point(537, 140);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 21);
            this.label11.TabIndex = 3;
            this.label11.Text = "°C";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.label12.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(67)))));
            this.label12.Location = new System.Drawing.Point(360, 280);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 21);
            this.label12.TabIndex = 3;
            this.label12.Text = "°C";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(67)))));
            this.label3.Location = new System.Drawing.Point(360, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "°C";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(398, 245);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(176, 64);
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(209, 175);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(184, 64);
            this.pictureBox5.TabIndex = 14;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(209, 245);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(184, 64);
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(398, 105);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(176, 64);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pbCradPos
            // 
            this.pbCradPos.BackColor = System.Drawing.SystemColors.Control;
            this.pbCradPos.Image = ((System.Drawing.Image)(resources.GetObject("pbCradPos.Image")));
            this.pbCradPos.Location = new System.Drawing.Point(13, 105);
            this.pbCradPos.Name = "pbCradPos";
            this.pbCradPos.Size = new System.Drawing.Size(189, 344);
            this.pbCradPos.TabIndex = 14;
            this.pbCradPos.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(209, 105);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 64);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(683, 602);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weiss/Votsch Thermal Shock Monitoring - QE APEBU DELTA v1.0.04.2026 DET9-RD1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpComm.ResumeLayout(false);
            this.grpComm.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCradPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnEnableChamber;
        private System.Windows.Forms.TextBox tbTempHotChamAct;
        private System.Windows.Forms.Label lblChamberStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBrowseLogPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFileNamePrefix;
        private System.Windows.Forms.CheckBox chkCsvLogging;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAutoGet;
        private System.Windows.Forms.ComboBox cmbSamplingRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAbout;

        // New controls for TCP/Serial mode
        private System.Windows.Forms.RadioButton radioSerial;
        private System.Windows.Forms.RadioButton radioTcp;
        private System.Windows.Forms.TextBox txtTcpHost;
        private System.Windows.Forms.TextBox txtTcpPort;
        private System.Windows.Forms.Button btnSetCradPos;
        private System.Windows.Forms.TextBox tbTempHotChamSet;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbTempColdChamAct;
        private System.Windows.Forms.TextBox tbTempColdChamSet;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox tbTempCradAct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pbCradPos;
        private System.Windows.Forms.Button btnManualGet;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCycleAct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCycleSet;
        private System.Windows.Forms.TextBox tbTempCradSet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}
