namespace ShrewSX1280TestBenchApp
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dropSerialPorts = new System.Windows.Forms.ComboBox();
            this.btnLoadTestFirmware = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnLoadProdFirmware = new System.Windows.Forms.Button();
            this.btnToneStop = new System.Windows.Forms.Button();
            this.btnToneStart = new System.Windows.Forms.Button();
            this.lblMhz = new System.Windows.Forms.Label();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.numFrequency = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblPower = new System.Windows.Forms.Label();
            this.numRfPower = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.dropTestMode = new System.Windows.Forms.ComboBox();
            this.lblPacketRate = new System.Windows.Forms.Label();
            this.numPacketRate = new System.Windows.Forms.NumericUpDown();
            this.lblPacketsPerSecond = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequency)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRfPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPacketRate)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dropSerialPorts);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port";
            // 
            // dropSerialPorts
            // 
            this.dropSerialPorts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dropSerialPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropSerialPorts.FormattingEnabled = true;
            this.dropSerialPorts.Location = new System.Drawing.Point(6, 19);
            this.dropSerialPorts.Name = "dropSerialPorts";
            this.dropSerialPorts.Size = new System.Drawing.Size(525, 21);
            this.dropSerialPorts.TabIndex = 1;
            this.dropSerialPorts.SelectedIndexChanged += new System.EventHandler(this.dropSerialPorts_SelectedIndexChanged);
            this.dropSerialPorts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dropSerialPorts_MouseDoubleClick);
            // 
            // btnLoadTestFirmware
            // 
            this.btnLoadTestFirmware.Location = new System.Drawing.Point(6, 6);
            this.btnLoadTestFirmware.Name = "btnLoadTestFirmware";
            this.btnLoadTestFirmware.Size = new System.Drawing.Size(157, 64);
            this.btnLoadTestFirmware.TabIndex = 2;
            this.btnLoadTestFirmware.Text = "Load Testing Firmware";
            this.btnLoadTestFirmware.UseVisualStyleBackColor = true;
            this.btnLoadTestFirmware.Click += new System.EventHandler(this.btnLoadTestFirmware_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(561, 638);
            this.splitContainer1.SplitterDistance = 317;
            this.splitContainer1.TabIndex = 2;
            // 
            // btnLoadProdFirmware
            // 
            this.btnLoadProdFirmware.Location = new System.Drawing.Point(169, 6);
            this.btnLoadProdFirmware.Name = "btnLoadProdFirmware";
            this.btnLoadProdFirmware.Size = new System.Drawing.Size(157, 64);
            this.btnLoadProdFirmware.TabIndex = 3;
            this.btnLoadProdFirmware.Text = "Load Product Firmware";
            this.btnLoadProdFirmware.UseVisualStyleBackColor = true;
            this.btnLoadProdFirmware.Click += new System.EventHandler(this.btnLoadProdFirmware_Click);
            // 
            // btnToneStop
            // 
            this.btnToneStop.Location = new System.Drawing.Point(286, 13);
            this.btnToneStop.Name = "btnToneStop";
            this.btnToneStop.Size = new System.Drawing.Size(81, 52);
            this.btnToneStop.TabIndex = 9;
            this.btnToneStop.Text = "Stop";
            this.btnToneStop.UseVisualStyleBackColor = true;
            this.btnToneStop.Click += new System.EventHandler(this.btnToneStop_Click);
            // 
            // btnToneStart
            // 
            this.btnToneStart.Location = new System.Drawing.Point(199, 13);
            this.btnToneStart.Name = "btnToneStart";
            this.btnToneStart.Size = new System.Drawing.Size(81, 52);
            this.btnToneStart.TabIndex = 8;
            this.btnToneStart.Text = "Start";
            this.btnToneStart.UseVisualStyleBackColor = true;
            this.btnToneStart.Click += new System.EventHandler(this.btnToneStart_Click);
            // 
            // lblMhz
            // 
            this.lblMhz.AutoSize = true;
            this.lblMhz.Location = new System.Drawing.Point(160, 24);
            this.lblMhz.Name = "lblMhz";
            this.lblMhz.Size = new System.Drawing.Size(29, 13);
            this.lblMhz.TabIndex = 2;
            this.lblMhz.Text = "MHz";
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(6, 18);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(31, 13);
            this.lblFrequency.TabIndex = 1;
            this.lblFrequency.Text = "Freq:";
            // 
            // numFrequency
            // 
            this.numFrequency.Location = new System.Drawing.Point(68, 22);
            this.numFrequency.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.numFrequency.Minimum = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            this.numFrequency.Name = "numFrequency";
            this.numFrequency.Size = new System.Drawing.Size(86, 20);
            this.numFrequency.TabIndex = 4;
            this.numFrequency.Value = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLog);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(561, 317);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.Lime;
            this.txtLog.Location = new System.Drawing.Point(3, 16);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(555, 298);
            this.txtLog.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 76);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(555, 239);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnLoadTestFirmware);
            this.tabPage1.Controls.Add(this.btnLoadProdFirmware);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(547, 213);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Firmware";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.lblPacketsPerSecond);
            this.tabPage2.Controls.Add(this.numPacketRate);
            this.tabPage2.Controls.Add(this.lblPacketRate);
            this.tabPage2.Controls.Add(this.dropTestMode);
            this.tabPage2.Controls.Add(this.lblMode);
            this.tabPage2.Controls.Add(this.numRfPower);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.lblPower);
            this.tabPage2.Controls.Add(this.btnToneStop);
            this.tabPage2.Controls.Add(this.lblFrequency);
            this.tabPage2.Controls.Add(this.btnToneStart);
            this.tabPage2.Controls.Add(this.numFrequency);
            this.tabPage2.Controls.Add(this.lblMhz);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(547, 213);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Test";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblPower
            // 
            this.lblPower.AutoSize = true;
            this.lblPower.Location = new System.Drawing.Point(6, 67);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(40, 13);
            this.lblPower.TabIndex = 5;
            this.lblPower.Text = "Power:";
            // 
            // numRfPower
            // 
            this.numRfPower.Location = new System.Drawing.Point(68, 65);
            this.numRfPower.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numRfPower.Minimum = new decimal(new int[] {
            18,
            0,
            0,
            -2147483648});
            this.numRfPower.Name = "numRfPower";
            this.numRfPower.Size = new System.Drawing.Size(86, 20);
            this.numRfPower.TabIndex = 5;
            this.numRfPower.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "dBm";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(6, 111);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(37, 13);
            this.lblMode.TabIndex = 8;
            this.lblMode.Text = "Mode:";
            // 
            // dropTestMode
            // 
            this.dropTestMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dropTestMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropTestMode.FormattingEnabled = true;
            this.dropTestMode.Location = new System.Drawing.Point(68, 108);
            this.dropTestMode.Name = "dropTestMode";
            this.dropTestMode.Size = new System.Drawing.Size(473, 21);
            this.dropTestMode.TabIndex = 6;
            this.dropTestMode.SelectedIndexChanged += new System.EventHandler(this.dropTestMode_SelectedIndexChanged);
            // 
            // lblPacketRate
            // 
            this.lblPacketRate.AutoSize = true;
            this.lblPacketRate.Location = new System.Drawing.Point(6, 153);
            this.lblPacketRate.Name = "lblPacketRate";
            this.lblPacketRate.Size = new System.Drawing.Size(70, 13);
            this.lblPacketRate.TabIndex = 10;
            this.lblPacketRate.Text = "Packet Rate:";
            // 
            // numPacketRate
            // 
            this.numPacketRate.Location = new System.Drawing.Point(93, 151);
            this.numPacketRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPacketRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPacketRate.Name = "numPacketRate";
            this.numPacketRate.Size = new System.Drawing.Size(86, 20);
            this.numPacketRate.TabIndex = 7;
            this.numPacketRate.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lblPacketsPerSecond
            // 
            this.lblPacketsPerSecond.AutoSize = true;
            this.lblPacketsPerSecond.Location = new System.Drawing.Point(185, 147);
            this.lblPacketsPerSecond.Name = "lblPacketsPerSecond";
            this.lblPacketsPerSecond.Size = new System.Drawing.Size(104, 13);
            this.lblPacketsPerSecond.TabIndex = 12;
            this.lblPacketsPerSecond.Text = "Packets per Second";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 638);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFrequency)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRfPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPacketRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox dropSerialPorts;
        private System.Windows.Forms.Button btnLoadTestFirmware;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnToneStop;
        private System.Windows.Forms.Button btnToneStart;
        private System.Windows.Forms.Label lblMhz;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.NumericUpDown numFrequency;
        private System.Windows.Forms.Button btnLoadProdFirmware;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.NumericUpDown numRfPower;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox dropTestMode;
        private System.Windows.Forms.Label lblPacketRate;
        private System.Windows.Forms.Label lblPacketsPerSecond;
        private System.Windows.Forms.NumericUpDown numPacketRate;
    }
}

