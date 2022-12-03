using System;
using System.Windows.Forms;

namespace _MFTP_
{
    public partial class InputBoxForm : Form
    {
        private static string output;
        public InputBoxForm(string[] IBForm)
        {
            InitializeComponent();
            Textlabel.Text = IBForm[0];
            TextBox.PlaceholderText = IBForm[1];
            Button.Text = IBForm[2];
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (TextBox.Text == "")
            {
                output = "New Folder";
            }
            else
            {
                output = TextBox.Text;
            }
            Close();
        }
        public static string Output()
        {
            return output;
        }
    }
}
