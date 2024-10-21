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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnToneStop = new System.Windows.Forms.Button();
            this.btnToneStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numFrequency = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequency)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dropSerialPorts);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 58);
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
            this.dropSerialPorts.Size = new System.Drawing.Size(618, 21);
            this.dropSerialPorts.TabIndex = 0;
            this.dropSerialPorts.SelectedIndexChanged += new System.EventHandler(this.dropSerialPorts_SelectedIndexChanged);
            this.dropSerialPorts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dropSerialPorts_MouseDoubleClick);
            // 
            // btnLoadTestFirmware
            // 
            this.btnLoadTestFirmware.Location = new System.Drawing.Point(12, 76);
            this.btnLoadTestFirmware.Name = "btnLoadTestFirmware";
            this.btnLoadTestFirmware.Size = new System.Drawing.Size(157, 64);
            this.btnLoadTestFirmware.TabIndex = 1;
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
            this.splitContainer1.Panel1.Controls.Add(this.btnLoadProdFirmware);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btnLoadTestFirmware);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(654, 638);
            this.splitContainer1.SplitterDistance = 318;
            this.splitContainer1.TabIndex = 2;
            // 
            // btnLoadProdFirmware
            // 
            this.btnLoadProdFirmware.Location = new System.Drawing.Point(175, 76);
            this.btnLoadProdFirmware.Name = "btnLoadProdFirmware";
            this.btnLoadProdFirmware.Size = new System.Drawing.Size(157, 64);
            this.btnLoadProdFirmware.TabIndex = 3;
            this.btnLoadProdFirmware.Text = "Load Product Firmware";
            this.btnLoadProdFirmware.UseVisualStyleBackColor = true;
            this.btnLoadProdFirmware.Click += new System.EventHandler(this.btnLoadProdFirmware_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnToneStop);
            this.groupBox3.Controls.Add(this.btnToneStart);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.numFrequency);
            this.groupBox3.Location = new System.Drawing.Point(12, 146);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(390, 74);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cont. Wave Test";
            // 
            // btnToneStop
            // 
            this.btnToneStop.Location = new System.Drawing.Point(286, 16);
            this.btnToneStop.Name = "btnToneStop";
            this.btnToneStop.Size = new System.Drawing.Size(81, 52);
            this.btnToneStop.TabIndex = 4;
            this.btnToneStop.Text = "Stop";
            this.btnToneStop.UseVisualStyleBackColor = true;
            this.btnToneStop.Click += new System.EventHandler(this.btnToneStop_Click);
            // 
            // btnToneStart
            // 
            this.btnToneStart.Location = new System.Drawing.Point(199, 16);
            this.btnToneStart.Name = "btnToneStart";
            this.btnToneStart.Size = new System.Drawing.Size(81, 52);
            this.btnToneStart.TabIndex = 3;
            this.btnToneStart.Text = "Start";
            this.btnToneStart.UseVisualStyleBackColor = true;
            this.btnToneStart.Click += new System.EventHandler(this.btnToneStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "MHz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Freq:";
            // 
            // numFrequency
            // 
            this.numFrequency.Location = new System.Drawing.Point(55, 34);
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
            this.numFrequency.TabIndex = 0;
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
            this.groupBox2.Size = new System.Drawing.Size(654, 316);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.Lime;
            this.txtLog.Location = new System.Drawing.Point(3, 16);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(648, 297);
            this.txtLog.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "射频:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 638);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequency)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnToneStop;
        private System.Windows.Forms.Button btnToneStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numFrequency;
        private System.Windows.Forms.Button btnLoadProdFirmware;
        private System.Windows.Forms.Label label3;
    }
}

