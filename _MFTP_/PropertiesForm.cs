using FluentFTP;
using System.IO;
using System.Windows.Forms;
namespace _MFTP_
{
    public partial class PropertiesForm : Form
    {
        public PropertiesForm(string InfFile, bool NetConnected)
        {
            InitializeComponent();
            string File = InfFile;
            if (File == null)
            {
                Filename.Text = "File is unavailable.";
                goto end;
            }

            if (NetConnected == true)
            {
                var client = new FtpClient(Properties.Settings.Default.FTP_IP, Properties.Settings.Default.FTP_Username, Properties.Settings.Default.FTP_Password);
                client.AutoConnect();

                Filename.Text = File;
                long tmp = client.GetFileSize(File);
                FtpListItem tmp1 = client.GetFilePermissions(File);
                if(tmp1 == null)
                {
                    Filename.Text = "File is unavailable.";
                    goto end;
                }
                else if (tmp1.Type == FtpObjectType.Directory)
                {
                    Filesize.Text = "Folder";
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
                    Perms.Text = "No permissions.";
                }
                else
                {
                    Date0.Text = tmp1.Modified.ToString();
                    Chmod.Text = client.GetChmod(File).ToString();
                    Perms.Text = tmp1.ToString();
                }
            }
            else
            {
                FileInfo Inf = new FileInfo(File);
                Filename.Text = Inf.Name;
                try
                {
                    FileAttributes attr = Inf.Attributes;
                    if (attr.HasFlag(FileAttributes.Directory))
                    {
                        Filesize.Text = "Folder";
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
                Perms.Text = "";


            }
        end: { }
        }
    }
}
