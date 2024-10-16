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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dropSerialPorts = new System.Windows.Forms.ComboBox();
            this.btnLoadFirmware = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            this.dropSerialPorts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dropSerialPorts_MouseDoubleClick);
            // 
            // btnLoadFirmware
            // 
            this.btnLoadFirmware.Location = new System.Drawing.Point(12, 76);
            this.btnLoadFirmware.Name = "btnLoadFirmware";
            this.btnLoadFirmware.Size = new System.Drawing.Size(116, 40);
            this.btnLoadFirmware.TabIndex = 1;
            this.btnLoadFirmware.Text = "Load Firmware";
            this.btnLoadFirmware.UseVisualStyleBackColor = true;
            this.btnLoadFirmware.Click += new System.EventHandler(this.btnLoadFirmware_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 450);
            this.Controls.Add(this.btnLoadFirmware);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox dropSerialPorts;
        private System.Windows.Forms.Button btnLoadFirmware;
    }
}

