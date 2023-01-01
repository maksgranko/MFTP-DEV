using System;
using System.Resources;
using System.Windows.Forms;

namespace _MFTP_
{
    public partial class InputBoxForm : Form
    {
        public static bool CorrectlyClosed = false;
        private ResourceSet rs;
        private static string output;
        public InputBoxForm(ushort IBF)
        {
            InitializeComponent();
            CorrectlyClosed = false;
            Localizations(IBF);
        }
        private void Localizations(ushort IBF)
        {
            Localizations locale = new Localizations();
            rs = locale.Setlocale();

            if (IBF == 0) // create folder
            {
                Textlabel.Text = rs.GetString("Info_InputNameFolder");
                TextBox.PlaceholderText = rs.GetString("Info_NewFolder");
                Button.Text = rs.GetString("Text_CreateFolder");
            }
            else if (IBF == 1) // rename file/folder
            {
                Textlabel.Text = rs.GetString("Info_InputNewName");
                TextBox.PlaceholderText = rs.GetString("Info_Example");
                Button.Text = rs.GetString("Info_RenameIt");
            }
            else if (IBF == 2) // none
            {
            }
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            if (TextBox.Text == "")
            {
                output = rs.GetString("Info_NewFolder");
            }
            else
            {
                output = TextBox.Text;
            }
            CorrectlyClosed = true;
            Close();
        }
        public static string Output()
        {
            return output;
        }
    }
}
