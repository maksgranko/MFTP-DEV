using _MFTP_.Properties;
using System;
using System.Resources;
using System.Windows.Forms;

namespace _MFTP_
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
            rs = locale.Setlocale();
            gb0.Text = rs.GetString("Text_Settings_Encoding");
            l0.Text = rs.GetString("Text_Settings_Encoding") + ":";
            Force_ASCII_chbox.Text = rs.GetString("Text_Settings_ForceASCII");
            Force_Auto_chbox.Text = rs.GetString("Text_Settings_AutoEncode");
            Force_UTF7_chbox.Text = rs.GetString("Text_Settings_ForceUTF7");
            Force_UTF8_chbox.Text = rs.GetString("Text_Settings_ForceUTF8");

            gb_other.Text = rs.GetString("Text_Settings_Other");
            language_label.Text = rs.GetString("Text_Settings_Language") + "∙:";

            gb1.Text = rs.GetString("Text_Settings_BetaFunctional");
            l1.Text = rs.GetString("Text_Settings_BetaFunctional") + "∙:";
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
            if (Properties.Settings.Default.Autolocale == true)
            {
                language_ComboBox.Text = "Auto";
            }
            else if (Properties.Settings.Default.SelectedLocale == "ru_RU")
            {
                language_ComboBox.Text = "Русский";
            }
            else if (Properties.Settings.Default.SelectedLocale == "en_US")
            {
                language_ComboBox.Text = "English";
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

        private void L0_Click(object sender, EventArgs e)
        {
            Settings.Default.Encoding = 0;
            Force_ASCII_chbox.Checked = false;
            Force_UTF7_chbox.Checked = false;
            Force_UTF8_chbox.Checked = false;
            Force_Auto_chbox.Checked = true;
        }

        private void L1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(rs.GetString("Text_Settings_BetaMessage"));
        }

        private void Language_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (language_ComboBox.Text == "Auto")
            {
                Properties.Settings.Default.Autolocale = true;
            }
            else
            {
                Properties.Settings.Default.Autolocale = false;
            }
            if (language_ComboBox.Text == "Русский")
            {
                Properties.Settings.Default.SelectedLocale = "ru_RU";
            }
            else if (language_ComboBox.Text == "English")
            {
                Properties.Settings.Default.SelectedLocale = "en_US";
            }

        }

        private void Language_label_Click(object sender, EventArgs e)
        {

            MessageBox.Show(rs.GetString("Text_Settings_LanguageMessage"));
        }
    }
}
