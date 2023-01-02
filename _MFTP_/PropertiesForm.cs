using FluentFTP;
using System.IO;
using System.Resources;
using System.Windows.Forms;
namespace _MFTP_
{
    public partial class PropertiesForm : Form
    {
        private ResourceSet rs;

        private void Localizations()
        {
            Localizations locale = new Localizations();
            rs = locale.Setlocale();
            gb0.Text = rs.GetString("Text_Properties_BasicInfo");
            FileName_label.Text = rs.GetString("Text_Properties_Filename");
            Filename.Text = rs.GetString("Text_Properties_FilenameInvalid");
            FileSize_label.Text = rs.GetString("Text_Properties_Size");
            Filesize.Text = rs.GetString("null");
            FileAddress_label.Text = rs.GetString("Text_Properties_Address");
            Address.Text = rs.GetString("null");
            Date0_label.Text = rs.GetString("Text_Properties_ModDate");
            Date0.Text = rs.GetString("null");
            gb1.Text = rs.GetString("Text_Properties_AddInfo");
            Chmod_label.Text = rs.GetString("Text_Properties_Chmod");
            Chmod.Text = rs.GetString("Text_Properties_NoPerms");
            Advanced_label.Text = rs.GetString("Text_Properties_Advanced");
            Advanced.Text = rs.GetString("null");
        }
        public PropertiesForm(string InfFile, bool NetConnected, uint type)
        {
            InitializeComponent();
            Localizations();
            string File = InfFile;
            if (File == null)
            {
                Filename.Text = rs.GetString("Text_Properties_FilenameInvalid");
                goto end;
            }

            if (NetConnected == true)
            {
                FtpClient client = new FtpClient(Properties.Settings.Default.FTP_IP, Properties.Settings.Default.FTP_Username, Properties.Settings.Default.FTP_Password, Properties.Settings.Default.FTP_CustomPort);
                if (Properties.Settings.Default.Encoding == 0)
                    client.Encoding = System.Text.Encoding.Default;
                else if (Properties.Settings.Default.Encoding == 1)
                    client.Encoding = System.Text.Encoding.ASCII;
                else if (Properties.Settings.Default.Encoding == 2)
                    client.Encoding = System.Text.Encoding.UTF7;
                else if (Properties.Settings.Default.Encoding == 3)
                    client.Encoding = System.Text.Encoding.UTF8;
                if (type == 5) // auto
                {
                    client.AutoConnect();
                }
                else // custom and other
                {
                    client.Port = Properties.Settings.Default.FTP_CustomPort;
                    client.Connect();
                }
                Filename.Text = File;
                long tmp = client.GetFileSize(File);
                FtpListItem tmp1 = client.GetFilePermissions(File);
                if(tmp1 == null)
                {
                    Filename.Text = rs.GetString("Text_Properties_FilenameInvalid");
                    goto end;
                }
                else if (tmp1.Type == FtpObjectType.Directory)
                {
                    Filesize.Text = rs.GetString("Text_Folder");
                }
                else
                {
                    Filesize.Text = tmp.ToString() + " bytes";
                }
                Address.Text = File;
                Date0.Text = client.GetModifiedTime(File).ToString();
                if (tmp1 == null)
                {
                    Chmod.Text = "null";
                    Advanced.Text = rs.GetString("Text_Properties_NoPerms");
                }
                else
                {
                    Date0.Text = tmp1.Modified.ToString();
                    Chmod.Text = client.GetChmod(File).ToString();
                    Advanced.Text = tmp1.ToString();
                }
            }
            else
            {
                FileInfo Inf = new FileInfo(File);
                Filename.Text = Inf.Name;
                if(Inf.Name == "..") { 
                    Filename.Text = rs.GetString("Text_Properties_FilenameInvalid"); ;
                    goto end;
                }
                try
                {
                    FileAttributes attr = Inf.Attributes;
                    if (attr.HasFlag(FileAttributes.Directory))
                    {
                        Filesize.Text = rs.GetString("Text_Folder");
                    }
                    else
                    {
                        Filesize.Text = Inf.Length.ToString() + " bytes";
                    }
                }
                catch
                {
                }
                Address.Text = Inf.FullName;
                Date0.Text = Inf.LastWriteTime.ToString();
                Chmod.Text = "";
                Advanced.Text = "";

            }
        end: { }
        }
    }
}
