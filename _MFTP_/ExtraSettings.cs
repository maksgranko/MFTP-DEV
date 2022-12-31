using _MFTP_;
using _MFTP_.Properties;
using System;
using System.Resources;
using System.Windows.Forms;

namespace MFTP
{
    public partial class ExtraSettings : Form
    {
        private ResourceSet rs;
        public ExtraSettings()
        {
            InitializeComponent();
            Localizations();
            InitializeConfiguration();
        }
        private void Localizations()
        {
            Localizations locale = new Localizations();
            rs = locale.setlocale();
            gb0.Text = rs.GetString("Text_Settings_Encoding");
            l0.Text = rs.GetString("Text_Settings_Encoding") + ":";
            Force_ASCII_chbox.Text = rs.GetString("Text_Settings_ForceASCII");
            Force_Auto_chbox.Text = rs.GetString("Text_Settings_AutoEncode");
            Force_UTF7_chbox.Text = rs.GetString("Text_Settings_ForceUTF7");
            Force_UTF8_chbox.Text = rs.GetString("Text_Settings_ForceUTF8");
            gb1.Text = rs.GetString("Text_Settings_BetaFunctional");
            l1.Text = rs.GetString("Text_Settings_BetaFunctional") + ":";
            FXP_Proto_cb0.Text = rs.GetString("Text_Settings_FXPProto");
            SaveSettings.Text = rs.GetString("Text_Apply");




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
            MessageBox.Show(rs.GetString("Text_Settings_BetaMessage"));
        }

    }
}
