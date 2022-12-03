
namespace _MFTP_
{
    partial class PropertiesForm
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
            this.gb0 = new System.Windows.Forms.GroupBox();
            this.Date0 = new System.Windows.Forms.Label();
            this.Date0_label = new System.Windows.Forms.Label();
            this.Filename = new System.Windows.Forms.TextBox();
            this.Filesize = new System.Windows.Forms.Label();
            this.Address = new System.Windows.Forms.Label();
            this.FileAddress_label = new System.Windows.Forms.Label();
            this.FileSize_label = new System.Windows.Forms.Label();
            this.FileName_label = new System.Windows.Forms.Label();
            this.addgb0 = new System.Windows.Forms.GroupBox();
            this.Perms = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Chmod_label = new System.Windows.Forms.Label();
            this.Chmod = new System.Windows.Forms.Label();
            this.gb0.SuspendLayout();
            this.addgb0.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb0
            // 
            this.gb0.Controls.Add(this.Date0);
            this.gb0.Controls.Add(this.Date0_label);
            this.gb0.Controls.Add(this.Filename);
            this.gb0.Controls.Add(this.Filesize);
            this.gb0.Controls.Add(this.Address);
            this.gb0.Controls.Add(this.FileAddress_label);
            this.gb0.Controls.Add(this.FileSize_label);
            this.gb0.Controls.Add(this.FileName_label);
            this.gb0.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.gb0.Location = new System.Drawing.Point(4, 1);
            this.gb0.Name = "gb0";
            this.gb0.Size = new System.Drawing.Size(329, 123);
            this.gb0.TabIndex = 6;
            this.gb0.TabStop = false;
            this.gb0.Text = "Basic information";
            // 
            // Date0
            // 
            this.Date0.AutoSize = true;
            this.Date0.Location = new System.Drawing.Point(79, 101);
            this.Date0.MaximumSize = new System.Drawing.Size(246, 15);
            this.Date0.Name = "Date0";
            this.Date0.Size = new System.Drawing.Size(46, 15);
            this.Date0.TabIndex = 8;
            this.Date0.Text = "NaN???";
            // 
            // Date0_label
            // 
            this.Date0_label.AutoSize = true;
            this.Date0_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Date0_label.Location = new System.Drawing.Point(14, 101);
            this.Date0_label.MaximumSize = new System.Drawing.Size(80, 15);
            this.Date0_label.MinimumSize = new System.Drawing.Size(60, 15);
            this.Date0_label.Name = "Date0_label";
            this.Date0_label.Size = new System.Drawing.Size(64, 15);
            this.Date0_label.TabIndex = 7;
            this.Date0_label.Text = "Mod. date:";
            // 
            // Filename
            // 
            this.Filename.Location = new System.Drawing.Point(79, 14);
            this.Filename.MaxLength = 255;
            this.Filename.Name = "Filename";
            this.Filename.Size = new System.Drawing.Size(240, 23);
            this.Filename.TabIndex = 6;
            this.Filename.Text = "Example.png";
            // 
            // Filesize
            // 
            this.Filesize.AutoSize = true;
            this.Filesize.Location = new System.Drawing.Point(79, 40);
            this.Filesize.MaximumSize = new System.Drawing.Size(246, 15);
            this.Filesize.Name = "Filesize";
            this.Filesize.Size = new System.Drawing.Size(46, 15);
            this.Filesize.TabIndex = 5;
            this.Filesize.Text = "NaN???";
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.Location = new System.Drawing.Point(79, 55);
            this.Address.MaximumSize = new System.Drawing.Size(246, 45);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(27, 15);
            this.Address.TabIndex = 4;
            this.Address.Text = "null";
            // 
            // FileAddress_label
            // 
            this.FileAddress_label.AutoSize = true;
            this.FileAddress_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FileAddress_label.Location = new System.Drawing.Point(14, 55);
            this.FileAddress_label.MaximumSize = new System.Drawing.Size(80, 15);
            this.FileAddress_label.MinimumSize = new System.Drawing.Size(60, 15);
            this.FileAddress_label.Name = "FileAddress_label";
            this.FileAddress_label.Size = new System.Drawing.Size(60, 15);
            this.FileAddress_label.TabIndex = 3;
            this.FileAddress_label.Text = "Address:";
            // 
            // FileSize_label
            // 
            this.FileSize_label.AutoSize = true;
            this.FileSize_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FileSize_label.Location = new System.Drawing.Point(14, 40);
            this.FileSize_label.MaximumSize = new System.Drawing.Size(80, 15);
            this.FileSize_label.MinimumSize = new System.Drawing.Size(60, 15);
            this.FileSize_label.Name = "FileSize_label";
            this.FileSize_label.Size = new System.Drawing.Size(60, 15);
            this.FileSize_label.TabIndex = 2;
            this.FileSize_label.Text = "Size:";
            // 
            // FileName_label
            // 
            this.FileName_label.AutoSize = true;
            this.FileName_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FileName_label.Location = new System.Drawing.Point(13, 18);
            this.FileName_label.MaximumSize = new System.Drawing.Size(80, 15);
            this.FileName_label.MinimumSize = new System.Drawing.Size(60, 15);
            this.FileName_label.Name = "FileName_label";
            this.FileName_label.Size = new System.Drawing.Size(61, 15);
            this.FileName_label.TabIndex = 1;
            this.FileName_label.Text = "File name:";
            // 
            // addgb0
            // 
            this.addgb0.Controls.Add(this.Perms);
            this.addgb0.Controls.Add(this.label2);
            this.addgb0.Controls.Add(this.Chmod_label);
            this.addgb0.Controls.Add(this.Chmod);
            this.addgb0.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.addgb0.Location = new System.Drawing.Point(4, 130);
            this.addgb0.Name = "addgb0";
            this.addgb0.Size = new System.Drawing.Size(329, 92);
            this.addgb0.TabIndex = 8;
            this.addgb0.TabStop = false;
            this.addgb0.Text = "Additional information";
            // 
            // Perms
            // 
            this.Perms.AutoSize = true;
            this.Perms.Location = new System.Drawing.Point(79, 34);
            this.Perms.MaximumSize = new System.Drawing.Size(246, 60);
            this.Perms.Name = "Perms";
            this.Perms.Size = new System.Drawing.Size(27, 15);
            this.Perms.TabIndex = 11;
            this.Perms.Text = "null";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(14, 34);
            this.label2.MaximumSize = new System.Drawing.Size(80, 15);
            this.label2.MinimumSize = new System.Drawing.Size(60, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Advanced:";
            // 
            // Chmod_label
            // 
            this.Chmod_label.AutoSize = true;
            this.Chmod_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Chmod_label.Location = new System.Drawing.Point(14, 19);
            this.Chmod_label.MaximumSize = new System.Drawing.Size(80, 15);
            this.Chmod_label.MinimumSize = new System.Drawing.Size(60, 15);
            this.Chmod_label.Name = "Chmod_label";
            this.Chmod_label.Size = new System.Drawing.Size(60, 15);
            this.Chmod_label.TabIndex = 9;
            this.Chmod_label.Text = "Chmod:";
            // 
            // Chmod
            // 
            this.Chmod.AutoSize = true;
            this.Chmod.Location = new System.Drawing.Point(79, 19);
            this.Chmod.MaximumSize = new System.Drawing.Size(246, 15);
            this.Chmod.Name = "Chmod";
            this.Chmod.Size = new System.Drawing.Size(22, 15);
            this.Chmod.TabIndex = 0;
            this.Chmod.Text = "???";
            // 
            // PropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 229);
            this.Controls.Add(this.addgb0);
            this.Controls.Add(this.gb0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PropertiesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Properties";
            this.gb0.ResumeLayout(false);
            this.gb0.PerformLayout();
            this.addgb0.ResumeLayout(false);
            this.addgb0.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb0;
        private System.Windows.Forms.Label FileName_label;
        private System.Windows.Forms.Label FileSize_label;
        private System.Windows.Forms.Label FileAddress_label;
        private System.Windows.Forms.Label Address;
        private System.Windows.Forms.Label Filesize;
        private System.Windows.Forms.Label Date0;
        private System.Windows.Forms.Label Date0_label;
        private System.Windows.Forms.TextBox Filename;
        private System.Windows.Forms.GroupBox addgb0;
        private System.Windows.Forms.Label Perms;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Chmod_label;
        private System.Windows.Forms.Label Chmod;
    }
}