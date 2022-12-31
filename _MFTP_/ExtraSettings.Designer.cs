
namespace MFTP
{
    partial class ExtraSettings
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
            this.SaveSettings = new System.Windows.Forms.Button();
            this.gb0 = new System.Windows.Forms.GroupBox();
            this.Force_UTF8_chbox = new System.Windows.Forms.CheckBox();
            this.Force_Auto_chbox = new System.Windows.Forms.CheckBox();
            this.Force_UTF7_chbox = new System.Windows.Forms.CheckBox();
            this.Force_ASCII_chbox = new System.Windows.Forms.CheckBox();
            this.l0 = new System.Windows.Forms.Label();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.FXP_Proto_cb0 = new System.Windows.Forms.CheckBox();
            this.l1 = new System.Windows.Forms.Label();
            this.gb0.SuspendLayout();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveSettings
            // 
            this.SaveSettings.Location = new System.Drawing.Point(129, 229);
            this.SaveSettings.Name = "SaveSettings";
            this.SaveSettings.Size = new System.Drawing.Size(80, 23);
            this.SaveSettings.TabIndex = 4;
            this.SaveSettings.Text = "Apply";
            this.SaveSettings.UseVisualStyleBackColor = true;
            this.SaveSettings.Click += new System.EventHandler(this.SaveSettings_Click);
            // 
            // gb0
            // 
            this.gb0.Controls.Add(this.Force_UTF8_chbox);
            this.gb0.Controls.Add(this.Force_Auto_chbox);
            this.gb0.Controls.Add(this.Force_UTF7_chbox);
            this.gb0.Controls.Add(this.Force_ASCII_chbox);
            this.gb0.Controls.Add(this.l0);
            this.gb0.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.gb0.Location = new System.Drawing.Point(3, 0);
            this.gb0.Name = "gb0";
            this.gb0.Size = new System.Drawing.Size(329, 58);
            this.gb0.TabIndex = 5;
            this.gb0.TabStop = false;
            this.gb0.Text = "Encoding";
            // 
            // Force_UTF8_chbox
            // 
            this.Force_UTF8_chbox.AutoSize = true;
            this.Force_UTF8_chbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Force_UTF8_chbox.Location = new System.Drawing.Point(193, 35);
            this.Force_UTF8_chbox.Name = "Force_UTF8_chbox";
            this.Force_UTF8_chbox.Size = new System.Drawing.Size(89, 19);
            this.Force_UTF8_chbox.TabIndex = 6;
            this.Force_UTF8_chbox.Text = "Force UTF-8";
            this.Force_UTF8_chbox.UseVisualStyleBackColor = true;
            this.Force_UTF8_chbox.Click += new System.EventHandler(this.Force_UTF8_chbox_Click);
            // 
            // Force_Auto_chbox
            // 
            this.Force_Auto_chbox.AutoSize = true;
            this.Force_Auto_chbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Force_Auto_chbox.Location = new System.Drawing.Point(193, 19);
            this.Force_Auto_chbox.Name = "Force_Auto_chbox";
            this.Force_Auto_chbox.Size = new System.Drawing.Size(105, 19);
            this.Force_Auto_chbox.TabIndex = 4;
            this.Force_Auto_chbox.Text = "Auto Encoding";
            this.Force_Auto_chbox.UseVisualStyleBackColor = true;
            this.Force_Auto_chbox.Click += new System.EventHandler(this.Force_Auto_chbox_Click);
            // 
            // Force_UTF7_chbox
            // 
            this.Force_UTF7_chbox.AutoSize = true;
            this.Force_UTF7_chbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Force_UTF7_chbox.Location = new System.Drawing.Point(86, 35);
            this.Force_UTF7_chbox.Name = "Force_UTF7_chbox";
            this.Force_UTF7_chbox.Size = new System.Drawing.Size(89, 19);
            this.Force_UTF7_chbox.TabIndex = 3;
            this.Force_UTF7_chbox.Text = "Force UTF-7";
            this.Force_UTF7_chbox.UseVisualStyleBackColor = true;
            this.Force_UTF7_chbox.Click += new System.EventHandler(this.Force_UTF7_chbox_Click);
            // 
            // Force_ASCII_chbox
            // 
            this.Force_ASCII_chbox.AutoSize = true;
            this.Force_ASCII_chbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Force_ASCII_chbox.Location = new System.Drawing.Point(86, 19);
            this.Force_ASCII_chbox.Name = "Force_ASCII_chbox";
            this.Force_ASCII_chbox.Size = new System.Drawing.Size(86, 19);
            this.Force_ASCII_chbox.TabIndex = 2;
            this.Force_ASCII_chbox.Text = "Force ASCII";
            this.Force_ASCII_chbox.UseVisualStyleBackColor = true;
            this.Force_ASCII_chbox.Click += new System.EventHandler(this.Force_ASCII_chbox_Click);
            // 
            // l0
            // 
            this.l0.AutoSize = true;
            this.l0.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.l0.Location = new System.Drawing.Point(6, 20);
            this.l0.MaximumSize = new System.Drawing.Size(70, 15);
            this.l0.MinimumSize = new System.Drawing.Size(60, 15);
            this.l0.Name = "l0";
            this.l0.Size = new System.Drawing.Size(60, 15);
            this.l0.TabIndex = 1;
            this.l0.Text = "Encoding:";
            this.l0.Click += new System.EventHandler(this.l0_Click);
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.FXP_Proto_cb0);
            this.gb1.Controls.Add(this.l1);
            this.gb1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.gb1.Location = new System.Drawing.Point(3, 142);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(329, 58);
            this.gb1.TabIndex = 7;
            this.gb1.TabStop = false;
            this.gb1.Text = "Beta Functional";
            // 
            // FXP_Proto_cb0
            // 
            this.FXP_Proto_cb0.AutoSize = true;
            this.FXP_Proto_cb0.ForeColor = System.Drawing.Color.Red;
            this.FXP_Proto_cb0.Location = new System.Drawing.Point(102, 17);
            this.FXP_Proto_cb0.Name = "FXP_Proto_cb0";
            this.FXP_Proto_cb0.Size = new System.Drawing.Size(94, 19);
            this.FXP_Proto_cb0.TabIndex = 2;
            this.FXP_Proto_cb0.Text = "FXP protocol";
            this.FXP_Proto_cb0.UseVisualStyleBackColor = true;
            this.FXP_Proto_cb0.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // l1
            // 
            this.l1.AutoSize = true;
            this.l1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.l1.Location = new System.Drawing.Point(8, 18);
            this.l1.MaximumSize = new System.Drawing.Size(100, 15);
            this.l1.MinimumSize = new System.Drawing.Size(60, 15);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(88, 15);
            this.l1.TabIndex = 1;
            this.l1.Text = "Beta Functions:";
            this.l1.Click += new System.EventHandler(this.l1_Click);
            // 
            // ExtraSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 264);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.gb0);
            this.Controls.Add(this.SaveSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(354, 280);
            this.Name = "ExtraSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExtraSettings";
            this.Deactivate += new System.EventHandler(this.ExtraSettings_Deactivate);
            this.gb0.ResumeLayout(false);
            this.gb0.PerformLayout();
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SaveSettings;
        private System.Windows.Forms.GroupBox gb0;
        private System.Windows.Forms.Label l0;
        private System.Windows.Forms.CheckBox Force_Auto_chbox;
        private System.Windows.Forms.CheckBox Force_UTF7_chbox;
        private System.Windows.Forms.CheckBox Force_ASCII_chbox;
        private System.Windows.Forms.CheckBox Force_UTF8_chbox;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.CheckBox FXP_Proto_cb0;
        private System.Windows.Forms.Label l1;
    }
}