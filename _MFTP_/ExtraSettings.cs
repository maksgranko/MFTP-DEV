using _MFTP_.Properties;
using System;
using System.Windows.Forms;

namespace MFTP
{
    public partial class ExtraSettings : Form
    {
        public ExtraSettings()
        {
            InitializeComponent();
            InitializeConfiguration();
        }

        private void InitializeConfiguration()
        {
            //ASCII
            if (Settings.Default.Encoding == 1)
            {
                Force_ASCII_chbox.Checked = true;
            }
            //UTF-7
            else if (Settings.Default.Encoding == 2)
            {
                Force_UTF7_chbox.Checked = true;
            }
            //UTF-8
            else if (Settings.Default.Encoding == 3)
            {
                Force_UTF8_chbox.Checked = true;
            }
            else
            {
                Settings.Default.Encoding = 0;
                Force_Auto_chbox.Checked = true;
            }
        }

        private void SaveSettings_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            this.Close();
        }

        private void ExtraSettings_Deactivate(object sender, EventArgs e)
        {
            Settings.Default.Save();
        }

        private void Force_ASCII_chbox_Click(object sender, EventArgs e)
        {
            Settings.Default.Encoding = 1;
            Force_ASCII_chbox.Checked = true;
            Force_UTF7_chbox.Checked = false;
            Force_UTF8_chbox.Checked = false;
            Force_Auto_chbox.Checked = false;

        }

        private void Force_UTF7_chbox_Click(object sender, EventArgs e)
        {
            Settings.Default.Encoding = 2;
            Force_ASCII_chbox.Checked = false;
            Force_UTF7_chbox.Checked = true;
            Force_UTF8_chbox.Checked = false;
            Force_Auto_chbox.Checked = false;
        }

        private void Force_UTF8_chbox_Click(object sender, EventArgs e)
        {
            Settings.Default.Encoding = 3;
            Force_ASCII_chbox.Checked = false;
            Force_UTF7_chbox.Checked = false;
            Force_UTF8_chbox.Checked = true;
            Force_Auto_chbox.Checked = false;
        }

        private void Force_Auto_chbox_Click(object sender, EventArgs e)
        {
            Settings.Default.Encoding = 0;
            Force_ASCII_chbox.Checked = false;
            Force_UTF7_chbox.Checked = false;
            Force_UTF8_chbox.Checked = false;
            Force_Auto_chbox.Checked = true;
        }

        private void l0_Click(object sender, EventArgs e)
        {
            Settings.Default.Encoding = 0;
            Force_ASCII_chbox.Checked = false;
            Force_UTF7_chbox.Checked = false;
            Force_UTF8_chbox.Checked = false;
            Force_Auto_chbox.Checked = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void l1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Beta functional is unstable, it don't working or working too bad and it has been planed in program.\nRED: Function isn't working.\nYELLOW: Function unstable.\nWHITE: New fuction, uncategorized(or developer is lazy)");
        }

    }
}
