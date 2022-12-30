using FluentFTP;
using MFTP;
using System;
using System.IO;
using System.Windows.Forms;
namespace _MFTP_
{
    public partial class MFTP : Form
    {
        private ushort FTP_ConnectedState;
        private ushort FTP_FTPType;
        private ushort FTP_PortFromType;
        private ushort Copycount_0;
        private ushort Copycount_1;
        private ushort Deletecount_0;
        private ushort Deletecount_1;
        private ushort Uploadcount;
        private ushort Downloadcount;
        private bool FTP_ConnectStatusIsNeedUpdate;
        private bool FTP_CustomPortIsNeedUpdate;
        private bool ConnectedBefore;
        private bool CopyMoveMode_1;
        private bool CopyMoveMode_0;
        private bool Disk_block;
        private string[] UploadTarget = new string[255];
        private string[] DownloadTarget = new string[255];
        private string[] UploadItemName = new string[255];
        private string[] DownloadItemName = new string[255];
        private string[] CopyMoveTarget_0 = new string[255];
        private string[] CopyMoveTarget_1 = new string[255];
        private string[] MoveItemName_0 = new string[255];
        private string[] MoveItemName_1 = new string[255];
        private string[] DeleteTarget_0 = new string[255];
        private string[] DeleteTarget_1 = new string[255];
        private string[] DeleteItemName_0 = new string[255];
        private string[] DeleteItemName_1 = new string[255];
        private string WorkingDirectory_0 = "";
        private string WorkingDirectory_1 = "/";

        public MFTP()
        {
            InitializeComponent();
            InitializeConfiguration();
            UpdateVar();
            InitializeServer_0_ListBox();
        }

        private void UpdateVar()
        {
            if (FTP_FTPType == 0)
            {
                customPortToolStripMenuItem.Checked = false;
                sFTPToolStripMenuItem.Checked = false;
                sSLToolStripMenuItem.Checked = false;
                fTPToolStripMenuItem.Checked = true;
                tLSToolStripMenuItem.Checked = false;
                autoToolStripMenuItem.Checked = false;
                FTP_PortFromType = 21;
            }
            else if (FTP_FTPType == 1)
            {
                customPortToolStripMenuItem.Checked = false;
                sFTPToolStripMenuItem.Checked = true;
                sSLToolStripMenuItem.Checked = false;
                fTPToolStripMenuItem.Checked = false;
                tLSToolStripMenuItem.Checked = false;
                autoToolStripMenuItem.Checked = false;
                FTP_PortFromType = 22;
            }
            else if (FTP_FTPType == 2)
            {
                customPortToolStripMenuItem.Checked = false;
                sFTPToolStripMenuItem.Checked = false;
                sSLToolStripMenuItem.Checked = true;
                fTPToolStripMenuItem.Checked = false;
                tLSToolStripMenuItem.Checked = false;
                autoToolStripMenuItem.Checked = false;
                FTP_PortFromType = 443;
            }
            else if (FTP_FTPType == 3)
            {
                customPortToolStripMenuItem.Checked = false;
                sFTPToolStripMenuItem.Checked = false;
                sSLToolStripMenuItem.Checked = false;
                fTPToolStripMenuItem.Checked = false;
                autoToolStripMenuItem.Checked = false;
                tLSToolStripMenuItem.Checked = true;
                FTP_CustomPortIsNeedUpdate = false;
                FTP_PortFromType = 389;
            }
            else if (FTP_FTPType == 4)
            {
                customPortToolStripMenuItem.Checked = true;
                sFTPToolStripMenuItem.Checked = false;
                sSLToolStripMenuItem.Checked = false;
                fTPToolStripMenuItem.Checked = false;
                tLSToolStripMenuItem.Checked = false;
                autoToolStripMenuItem.Checked = false;
                FTP_CustomPortIsNeedUpdate = true;
            }
            else if (FTP_FTPType == 5)
            {
                customPortToolStripMenuItem.Checked = false;
                sFTPToolStripMenuItem.Checked = false;
                sSLToolStripMenuItem.Checked = false;
                fTPToolStripMenuItem.Checked = false;
                tLSToolStripMenuItem.Checked = false;
                autoToolStripMenuItem.Checked = true;
                FTP_CustomPortIsNeedUpdate = false;
            }

            else
            {
                customPortToolStripMenuItem.Checked = false;
                sFTPToolStripMenuItem.Checked = false;
                sSLToolStripMenuItem.Checked = false;
                fTPToolStripMenuItem.Checked = true;
                autoToolStripMenuItem.Checked = false;
                Properties.Settings.Default.FTP_Type = 0;
                Properties.Settings.Default.Save();
            }

            if (FTP_ConnectStatusIsNeedUpdate == true)
            {
                FTP_ConnectStatusIsNeedUpdate = false;
                if (FTP_ConnectedState == 0)
                {
                    Server_1_listBox.Items.Clear();
                    FTP_ConnectStatus.Text = "Disconnected";
                    FTP_Connect_btn.Enabled = true;
                    FTP_Connect_btn.Text = "Connect";
                }
                else if (FTP_ConnectedState == 1)
                {
                    FTP_ConnectStatus.Text = "Connected";
                    FTP_Error.Text = "Connected!";
                    FTP_Connect_btn.Enabled = true;
                    FTP_Connect_btn.Text = "Disconnect";
                }
                else if (FTP_ConnectedState == 2)
                {
                    Server_1_listBox.Items.Clear();
                    FTP_ConnectStatus.Text = "Connecting...";
                    FTP_Connect_btn.Enabled = false;
                    FTP_Connect_btn.Text = "Disconnect";
                }
                else if (FTP_ConnectedState == 3)
                {
                    Server_1_listBox.Items.Clear();
                    FTP_ConnectStatus.Text = "Joining...";
                    FTP_Connect_btn.Enabled = false;
                    FTP_Connect_btn.Text = "Disconnect";
                }
                else if (FTP_ConnectedState == 4)
                {
                    Server_1_listBox.Items.Clear();
                    FTP_ConnectStatus.Text = "Closed.";
                    FTP_Connect_btn.Enabled = true;
                    FTP_Connect_btn.Text = "Connect";
                }
                else if (FTP_ConnectedState == 5)
                {

                    Server_1_listBox.Items.Clear();
                    FTP_ConnectStatus.Text = "Authenticated";
                    FTP_Error.Text = "Authorized!";
                    FTP_Connect_btn.Enabled = false;
                    FTP_Connect_btn.Text = "Disconnect";

                }
            }
            if (FTP_CustomPortIsNeedUpdate == true)
            {
                FTP_CustomPort_Box.Visible = true;
                FTP_CustomPort_Text.Visible = true;
                FTP_CustomPortIsNeedUpdate = false;
            }
            else
            {
                FTP_CustomPort_Box.Visible = false;
                FTP_CustomPort_Text.Visible = false;
            }
        }

        private void InitializeConfiguration()
        {
            FTP_IP_Box.Text = Properties.Settings.Default.FTP_IP;
            FTP_Username_Box.Text = Properties.Settings.Default.FTP_Username;
            FTP_Password_Box.Text = Properties.Settings.Default.FTP_Password;
            FTP_FTPType = Properties.Settings.Default.FTP_Type;
            FTP_CustomPort_Box.Text = Properties.Settings.Default.FTP_CustomPort.ToString();

        }

        //Disconnect by Self
        public void Disconnect()
        {
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Optimized);
            var client = new FtpClient(Properties.Settings.Default.FTP_IP, Properties.Settings.Default.FTP_Username, Properties.Settings.Default.FTP_Password);
            client.Disconnect();
            if (client.IsConnected == true || FTP_ConnectedState == 1 || client.IsAuthenticated == true)
            {
                client.Disconnect();
                FTP_ConnectedState = 0;
                FTP_Error.Text = "Disconnected by Program.";
            }
        }
        public void SetEncoding(FtpClient client)
        {
            if (Properties.Settings.Default.Encoding == 0)
            {
                client.Encoding = System.Text.Encoding.Default;
            }
            else if (Properties.Settings.Default.Encoding == 1)
            {
                client.Encoding = System.Text.Encoding.ASCII;
            }
            else if (Properties.Settings.Default.Encoding == 2)
            {
                client.Encoding = System.Text.Encoding.UTF7;
            }
            else if (Properties.Settings.Default.Encoding == 3)
            {
                client.Encoding = System.Text.Encoding.UTF8;
            }

            else
            {
                FTP_Error.Text = "Encoding setted to default value.";
                Properties.Settings.Default.Encoding = 0;
                client.Encoding = System.Text.Encoding.Default;
            }
        }
        public void Connect()
        {
            if (FTP_IP_Box.Text.Length < 7 || FTP_IP_Box.Text == "" || FTP_IP_Box.Text == "127.0.0.1") {
                FTP_Error.Text = "Please, input correct IP Address. ";
                FTP_ConnectedState = 4;
                goto FTP_SkipConnect;
            }

            var client = new FtpClient(Properties.Settings.Default.FTP_IP, Properties.Settings.Default.FTP_Username, Properties.Settings.Default.FTP_Password);
            //Disconnect by User
            if (client.IsConnected == true || FTP_ConnectedState == 1 || client.IsAuthenticated == true)
            {
                ConnectedBefore = false;
                client.Disconnect();
                FTP_ConnectedState = 0;
                FTP_Error.Text = "Connection closed by User.";
                goto FTP_SkipConnect;

            }
            FTP_ConnectedState = 2;
            FTP_ConnectStatusIsNeedUpdate = true;
            UpdateVar();

            if (client.IsConnected == false && FTP_ConnectedState == 0 || client.IsDisposed == true || client.IsAuthenticated == false)
            {
                // FTP Auto
                if (FTP_FTPType == 5)
                {
                    try
                    {
                        client.AutoConnect();
                    }
                    catch (System.AggregateException)
                    {
                        FTP_ConnectedState = 4;
                        FTP_Error.Text = "IP supports only IPv6 or IPv4. Check IP Address.";
                        goto FTP_SkipConnect;

                    }
                    catch (TimeoutException)
                    {
                        FTP_ConnectedState = 0;
                        FTP_Error.Text = "Server is unavailable. Connection has been closed.";
                        goto FTP_SkipConnect;

                    }
                    catch (FtpAuthenticationException)
                    {
                        FTP_ConnectedState = 4;
                        FTP_Error.Text = "Connection refused. Check your Username or Password.";
                        goto FTP_SkipConnect;
                    }
                    catch (Exception e)
                    {
                        FTP_Error.Text = e.Message;
                        goto FTP_SkipConnect;
                    }
                }
                //FTP CustomPort
                else if (FTP_FTPType == 4)
                {
                    try
                    {
                        client.Port = Properties.Settings.Default.FTP_CustomPort;
                        try
                        {
                            client.Connect();
                        }
                        catch (FtpAuthenticationException)
                        {
                            FTP_ConnectedState = 4;
                            FTP_Error.Text = "Connection refused. Check your Username or Password.";
                            goto FTP_SkipConnect;
                        }
                        catch (System.Net.Sockets.SocketException)
                        {
                            FTP_Error.Text = "Connection refused.";
                            FTP_ConnectStatus.Text = "Closed.";

                        }
                        catch (System.AggregateException)
                        {
                            FTP_ConnectedState = 4;
                            FTP_Error.Text = "IP supports only IPv6 or IPv4. Check IP Address.";
                            goto FTP_SkipConnect;

                        }
                        catch (TimeoutException)
                        {
                            FTP_ConnectedState = 0;
                            FTP_Error.Text = "Server is unavailable. Connection has been closed.";
                            goto FTP_SkipConnect;

                        }
                        catch (Exception err)
                        {
                            FTP_Error.Text = err.Message;
                            FTP_ConnectStatus.Text = "Closed.";
                        }

                    }
                    catch (System.FormatException)
                    {
                        FTP_Error.Text = "Error by Port. Connection has been closed.";
                        client.Disconnect();
                    }
                }
                // FTP by types 1-4 
                else
                {
                    client.Port = FTP_PortFromType;
                    try
                    {
                        client.Connect();
                    }
                    catch (TimeoutException)
                    {
                        FTP_ConnectedState = 0;
                        FTP_Error.Text = "Server is unavailable. Connection has been closed.";
                        goto FTP_SkipConnect;

                    }
                    catch (FtpAuthenticationException)
                    {
                        FTP_ConnectedState = 4;
                        FTP_Error.Text = "Connection refused. Check your Username or Password.";
                        goto FTP_SkipConnect;
                    }
                    catch (System.AggregateException)
                    {
                        FTP_ConnectedState = 4;
                        FTP_Error.Text = "IP supports only IPv6 or IPv4. Check IP Address.";
                        goto FTP_SkipConnect;

                    }
                    catch (System.Net.Sockets.SocketException)
                    {
                        FTP_Error.Text = "Connection refused.";
                        FTP_ConnectStatus.Text = "Closed.";

                    }
                    catch (Exception err)
                    {
                        FTP_Error.Text = err.Message;
                        FTP_ConnectStatus.Text = "Closed.";
                    }
                }
                if (client.IsConnected == true)
                {
                    FTP_ConnectedState = 1;
                }
                else if (client.IsDisposed == true)
                {
                    FTP_ConnectedState = 4;
                    FTP_Error.Text = "Connection refused. Check your Username or Password.";
                }
                else if (client.IsAuthenticated == true)
                {
                    FTP_ConnectedState = 5;
                }
                else if (FTP_ConnectedState == 2)
                {
                    FTP_ConnectedState = 0;
                }
            }
            SetEncoding(client);
            try
            {
                if (client.IsConnected == true)
                {
                    Server_1_listBox.Items.Insert(0, "..");
                    foreach (FtpListItem item in client.GetListing(WorkingDirectory_1))
                    {
                        if (item.Type == FtpObjectType.Directory)
                        {
                            Server_1_listBox.Items.Add(item.Name.ToString());
                        }
                    }
                    foreach (FtpListItem item in client.GetListing(WorkingDirectory_1))
                    {
                        if (item.Type == FtpObjectType.File)
                        {
                            Server_1_listBox.Items.Add(item.Name.ToString());
                        }
                    }
                }
            }
            catch (System.IO.IOException)
            {
                client.Disconnect();
                FTP_ConnectedState = 0;
                FTP_Error.Text = "Connection timeout. Check your settings or your internet connection.";
            }
            catch (Exception err)
            {
                client.Disconnect();
                FTP_ConnectedState = 0;
                FTP_Error.Text = err.Message;
            }
            ConnectedBefore = true;
        FTP_SkipConnect:
            FTP_ConnectStatusIsNeedUpdate = true;
            UpdateVar();
        }

        private void FTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTP_FTPType = 0;
            Properties.Settings.Default.FTP_Type = 0;
            Properties.Settings.Default.Save();
            UpdateVar();
        }

        private void SFTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTP_FTPType = 1;
            Properties.Settings.Default.FTP_Type = 1;
            Properties.Settings.Default.Save();
            UpdateVar();
        }

        private void SSLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTP_FTPType = 2;
            Properties.Settings.Default.FTP_Type = 2;
            Properties.Settings.Default.Save();
            UpdateVar();
        }

        private void TLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTP_FTPType = 3;
            Properties.Settings.Default.FTP_Type = 3;
            Properties.Settings.Default.Save();
            UpdateVar();
        }

        private void CustomPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTP_FTPType = 4;
            Properties.Settings.Default.FTP_Type = 4;
            Properties.Settings.Default.Save();
            UpdateVar();
        }

        private void AutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTP_FTPType = 5;
            Properties.Settings.Default.FTP_Type = 5;
            Properties.Settings.Default.Save();
            UpdateVar();
        }

        private void FTP_IP_Box_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FTP_IP = FTP_IP_Box.Text;
            Properties.Settings.Default.Save();
        }

        private void FTP_Username_Box_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FTP_Username = FTP_Username_Box.Text;
            Properties.Settings.Default.Save();
        }

        private void FTP_Password_Box_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FTP_Password = FTP_Password_Box.Text;
            Properties.Settings.Default.Save();
        }

        private void FTP_CustomPort_Box_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.FTP_CustomPort = Convert.ToUInt16(FTP_CustomPort_Box.Text);
                FTP_Error.Text = "Custom port is saved!";
            }
            catch (System.OverflowException)
            {
                FTP_Error.Text = "Port is incorrect!";
                FTP_CustomPort_Box.Text = "";
            }
            catch (System.FormatException)
            {
                FTP_CustomPort_Box.Text = "";
                FTP_Error.Text = "Write port from 0 to 65535, don't write words or same!";
            }
            catch (Exception err)
            {
                FTP_Error.Text = err.Message;
                FTP_CustomPort_Box.Text = "";
            }
            finally
            {
                Properties.Settings.Default.Save();
            }
        }

        private void FTP_Connect_btn_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void DeleteFile()
        {
            if (FTP_ConnectedState == 1)
            {
                var client = new FtpClient(Properties.Settings.Default.FTP_IP, Properties.Settings.Default.FTP_Username, Properties.Settings.Default.FTP_Password);
                if (client.IsConnected == false)
                {
                    client.AutoConnect();
                }
                SetEncoding(client);

                try
                {
                    Deletecount_1 = 0;
                    foreach (int index in Server_1_listBox.SelectedIndices)
                    {
                        DeleteItemName_1[Deletecount_1] = Server_1_listBox.Items[index].ToString();
                        DeleteTarget_1[Deletecount_1] = WorkingDirectory_1 + "/" + DeleteItemName_1[Deletecount_1];
                        Deletecount_1++;
                    }

                    for (int i = 0; i < Deletecount_1; i++)
                    {
                        if (DeleteItemName_1[i] != "..")
                        {
                            FtpObjectType? tmp = client.GetFilePermissions(DeleteTarget_1[i]).Type;
                            if (tmp == null)
                            {
                                FTP_Error.Text = "This is file or directory can't be deleted.";
                            }
                            string ItemType = tmp.ToString();
                            if (ItemType == "Directory")
                            {
                                client.DeleteDirectory(DeleteTarget_1[i]);
                            }
                            else if (ItemType == "File")
                            {
                                client.DeleteFile(DeleteTarget_1[i]);
                            }
                        }
                        else
                        {
                            FTP_Error.Text = "This is file or directory can't be deleted.(named as \"..\" or same exception)";
                        }
                    }
                    Refresh_FileList_1();
                }
                catch (FluentFTP.FtpCommandException)
                {
                    FTP_Error.Text = "Unexcepted error.";
                }
                catch (Exception e)
                {
                    FTP_Error.Text = e.Message;
                }
            }
        }
        private FtpClient getClient()
        {
            var client = new FtpClient(Properties.Settings.Default.FTP_IP, Properties.Settings.Default.FTP_Username, Properties.Settings.Default.FTP_Password);
            if (client.IsConnected == false)
            {
                client.AutoConnect();
            }
            return client;
        }

        private void Refresh_FileList_1()
        {
            try {
                if (FTP_ConnectedState == 1)
                {
                    Server_1_listBox.Items.Clear();
                    var client = getClient();
                    Server_1_listBox.Items.Insert(0, "..");
                    SetEncoding(client);

                    foreach (FtpListItem item in client.GetListing(WorkingDirectory_1))
                    {
                        if (item.Type == FtpObjectType.Directory)
                        {
                            Server_1_listBox.Items.Add(item.Name.ToString());
                        }
                    }

                    foreach (FtpListItem item in client.GetListing(WorkingDirectory_1))
                    {
                        if (item.Type == FtpObjectType.File)
                        {
                            Server_1_listBox.Items.Add(item.Name.ToString());
                        }
                    }
                }
                else
                {
                    FTP_Error.Text = FTP_Error.Text + " Client isn't connected to server. Refreshing is unavalable.";
                }
            }
            catch (System.ArgumentException)
            {
                FTP_Error.Text = "Refreshing is unavailable.";
            }
            catch (Exception e)
            {
                FTP_Error.Text = e.Message;
            }
        }
        private void AdvancedSettings_btn_Click(object sender, EventArgs e)
        {
            CopyMoveMode_0 = false;
            CopyMoveMode_1 = false;
            Disconnect();
            Form ext_settings = new ExtraSettings();
            ext_settings.ShowDialog();
            if (ConnectedBefore == true)
            {
                Connect();
            }
        }

        private void Server_1_listBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (FTP_ConnectedState == 1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (CopyMoveMode_1 == false)
                    {
                        MoveinConMenu_1.Text = "Move";
                        if (Server_1_listBox.SelectedItem != null)
                        {
                            OpeninConMenu_1.Visible = true;
                            DownloadinConMenu_1.Visible = true;
                            MoveinConMenu_1.Visible = true;
                            RenameinConMenu_1.Visible = true;
                            CreateinConMenu_1.Visible = true;
                            DeleteinConMenu_1.Visible = true;
                            PropertiesinConMenu_1.Visible = true;
                        }
                        else
                        {
                            OpeninConMenu_1.Visible = false;
                            DownloadinConMenu_1.Visible = false;
                            MoveinConMenu_1.Visible = false;
                            RenameinConMenu_1.Visible = false;
                            CreateinConMenu_1.Visible = true;
                            DeleteinConMenu_1.Visible = false;
                            PropertiesinConMenu_1.Visible = true;
                        }
                    }
                    else if (CopyMoveMode_1 == true)
                    {
                        MoveinConMenu_1.Text = "Move there";
                        if (Server_1_listBox.SelectedItem != null)
                        {
                            OpeninConMenu_1.Visible = true;
                            DownloadinConMenu_1.Visible = true;
                            MoveinConMenu_1.Visible = true;
                            RenameinConMenu_1.Visible = false;
                            CreateinConMenu_1.Visible = true;
                            DeleteinConMenu_1.Visible = false;
                            PropertiesinConMenu_1.Visible = true;
                        }
                        else
                        {
                            OpeninConMenu_1.Visible = true;
                            DownloadinConMenu_1.Visible = false;
                            MoveinConMenu_1.Visible = true;
                            RenameinConMenu_1.Visible = false;
                            CreateinConMenu_1.Visible = true;
                            DeleteinConMenu_1.Visible = false;
                            PropertiesinConMenu_1.Visible = true;
                        }

                    }
                    RightClickMenu_1.Show(Server_1_listBox, e.Location);
                }
            }
        }

        private void DeleteinConMenu_Click(object sender, EventArgs e)
        {
            DeleteFile();
        }

        private void OpeninConMenu_Click(object sender, EventArgs e)
        {
            Open_1();

        }

        private void Server_1_EnterButton_Click(object sender, EventArgs e)
        {
            var client = getClient();
            SetEncoding(client);
            if (FTP_ConnectedState == 1)
            {
                try
                {

                    client.SetWorkingDirectory(Server_1_Textbox.Text);
                    WorkingDirectory_1 = Server_1_Textbox.Text;
                    Refresh_FileList_1();
                }
                catch (FluentFTP.FtpCommandException)
                {
                    FTP_Error.Text = "Unexcepted error. Setting folder to default.";
                    Server_1_Textbox.Text = "/";

                }
                catch (Exception err)
                {
                    FTP_Error.Text = err.Message;
                }
            }
            else
            {
                FTP_Error.Text = "Directory changing is unavailable now.";
            }
        }

        private void Open_1()
        {
            if (FTP_ConnectedState == 1)
            {
                if (Server_1_listBox.SelectedItem != null)
                {
                    var client = getClient();
                    SetEncoding(client);
                    try
                    {
                        string ItemType = null;
                        if (Server_1_listBox.SelectedItem.ToString() == "..")
                        {
                            client.SetWorkingDirectory(WorkingDirectory_1 + "/" + Server_1_listBox.SelectedItem.ToString());
                            Server_1_Textbox.Text = client.GetWorkingDirectory();
                            WorkingDirectory_1 = client.GetWorkingDirectory();
                            Refresh_FileList_1();
                        }
                        else
                        {
                            FtpObjectType? tmp = null;
                            if (client.GetFilePermissions(WorkingDirectory_1 + "/" + Server_1_listBox.SelectedItem) != null)
                            {
                                tmp = client.GetFilePermissions(WorkingDirectory_1 + "/" + Server_1_listBox.SelectedItem).Type;
                            }

                            if (tmp == null)
                            {
                                FTP_Error.Text = "This is file can't be opened.";
                            }
                            ItemType = tmp.ToString();
                        }

                        if (ItemType == "File")
                        {
                            FTP_Error.Text = "File is can't be open now!";
                        }
                        else if (ItemType == "Directory")
                        {
                            client.SetWorkingDirectory(WorkingDirectory_1 + "/" + Server_1_listBox.SelectedItem.ToString());
                            Server_1_Textbox.Text = client.GetWorkingDirectory();
                            WorkingDirectory_1 = client.GetWorkingDirectory();
                            Refresh_FileList_1();
                        }
                    }
                    catch (System.NullReferenceException)
                    {
                        FTP_Error.Text = "Folder error.";
                    }
                    catch (FluentFTP.FtpCommandException)
                    {
                        FTP_Error.Text = "Opening file is unavailable now.";
                    }
                    catch (ArgumentNullException)
                    {
                        FTP_Error.Text = "Too fast!";
                    }
                    catch (Exception err)
                    {
                        FTP_Error.Text = err.Message;
                    }
                }
            }
        }

        private void Server_1_listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Open_1();
        }

        private void PropertiesinConMenu_Click(object sender, EventArgs e)
        {
            string InfFile;

            if (Server_1_listBox.SelectedItem != null)
            {
                InfFile = WorkingDirectory_1 + "/" + Server_1_listBox.SelectedItem;
            }
            else
            {
                InfFile = WorkingDirectory_1;
            }
            Form properties = new PropertiesForm(InfFile, true);
            properties.ShowDialog();
        }

        private void CreateFolder()
        {
            if (FTP_ConnectedState == 1)
            {
                var client = getClient();
                SetEncoding(client);
                string[] TextLabels = new string[3];
                TextLabels[0] = "Input name of your New folder";
                TextLabels[1] = "New Folder";
                TextLabels[2] = "Create!";

                Form IBform = new InputBoxForm(TextLabels);

                IBform.ShowDialog();
                string Out = InputBoxForm.Output();
                client.CreateDirectory(WorkingDirectory_1 + "/" + Out);
            }
            Refresh_FileList_1();

        }

        private void CreateFolderinConMenu_Click(object sender, EventArgs e)
        {
            CreateFolder();
        }

        private void Refresh_list_1_Click(object sender, EventArgs e)
        {
            Refresh_FileList_0();
            Refresh_FileList_1();
        }

        private void MoveinConMenu_Click(object sender, EventArgs e)
        {
            if (CopyMoveMode_1 == false)
            {
                    Copycount_1 = 0;
                    foreach (int index in Server_1_listBox.SelectedIndices)
                    {
                        MoveItemName_1[Copycount_1] = Server_1_listBox.Items[index].ToString();
                        CopyMoveTarget_1[Copycount_1] = WorkingDirectory_1 + "/" + MoveItemName_1[Copycount_1];
                        CopyMoveMode_1 = true;
                        Copycount_1++;
                    }
            }
            else
            {
                if (FTP_ConnectedState == 1)
                {
                    var client = getClient();
                    SetEncoding(client);
                    try
                    {
                        for (int i = 0; i < Copycount_1; i++)
                        {
                            if (MoveItemName_1[i] != "..")
                            {
                                FtpObjectType? tmp = null;
                                if (client.GetFilePermissions(CopyMoveTarget_1[i]) != null)
                                {
                                    tmp = client.GetFilePermissions(CopyMoveTarget_1[i]).Type;
                                }

                                if (tmp == null)
                                {
                                    FTP_Error.Text = "This is file can't be moved.";
                                }
                                string ItemType = tmp.ToString();
                                if (ItemType == "Directory")
                                {
                                    client.MoveDirectory(CopyMoveTarget_1[i], WorkingDirectory_1 + "/" + MoveItemName_1[i], FtpRemoteExists.Skip);
                                }
                                else if (ItemType == "File")
                                {
                                    client.MoveFile(CopyMoveTarget_1[i], WorkingDirectory_1 + "/" + MoveItemName_1[i], FtpRemoteExists.Skip);
                                }
                            }
                            else
                            {
                                FTP_Error.Text = "This file/directory can't be copied/moved(named as \"..\" or same exception).";
                            }
                        }
                        Refresh_FileList_1();
                        FTP_Error.Text = client.GetWorkingDirectory();
                    }

                    catch (System.NullReferenceException)
                    {
                        FTP_Error.Text = "error.";
                    }
                    catch (FluentFTP.FtpCommandException)
                    {
                        FTP_Error.Text = "Moving error.";
                    }
                    catch (ArgumentNullException)
                    {
                        FTP_Error.Text = "Too fast!";
                    }
                    catch (Exception err)
                    {
                        FTP_Error.Text = err.Message;
                    }
                    finally
                    {
                        CopyMoveMode_1 = false;
                    }
                }
            }
        }

        private void RenameinConMenu_1_Click(object sender, EventArgs e)
        {
            if (Server_1_listBox.SelectedItem.ToString() == "..")
            {
                FTP_Error.Text = "This folder can't be renamed.";
            }
            else
            {
                var client = getClient();
                SetEncoding(client);
                string File;
                File = Server_1_listBox.SelectedItem.ToString();
                string[] TextLabels = new string[3];
                TextLabels[0] = "Input new name of this file/folder:";
                TextLabels[1] = "example.png";
                TextLabels[2] = "Rename it!";
                Form IBform = new InputBoxForm(TextLabels);

                try
                {
                    IBform.ShowDialog();
                    string Out = InputBoxForm.Output();
                    client.Rename(WorkingDirectory_1 + "/" + File, WorkingDirectory_1 + "/" + Out);
                    Refresh_FileList_1();
                }
                catch (FluentFTP.FtpCommandException err)
                {
                    FTP_Error.Text = err.Message.ToString();
                }
                catch (Exception err)
                {
                    FTP_Error.Text = err.Message;
                }
            }
        }
        private void DownloadinConMenu_1_Click(object sender, EventArgs e)
        {
            var client = getClient();
            SetEncoding(client);

            Downloadcount = 0;
            foreach (int index in Server_1_listBox.SelectedIndices)
            {
                DownloadItemName[Downloadcount] = Server_1_listBox.Items[index].ToString();
                DownloadTarget[Downloadcount] = WorkingDirectory_1 + "/" + DownloadItemName[Downloadcount];
                Downloadcount++;
            }
            try
            {
                for (int i = 0; i < Downloadcount; i++)
                {
                    if (DownloadItemName[i] != "..") { 
                    FtpObjectType? tmp = client.GetFilePermissions(DownloadTarget[i]).Type;
                    if (tmp == null)
                    {
                        FTP_Error.Text = "This is file can't be downloaded.";
                    }
                    string ItemType = tmp.ToString();
                    if (ItemType == "Directory")
                    {
                        client.DownloadDirectory(WorkingDirectory_0 + "/" + DownloadItemName[i], DownloadTarget[i], FtpFolderSyncMode.Update, FtpLocalExists.Skip, FtpVerify.OnlyChecksum);
                    }
                    else if (ItemType == "File")
                    {
                        client.DownloadFile(WorkingDirectory_0 + "/" + DownloadItemName[i], DownloadTarget[i], FtpLocalExists.Skip, FtpVerify.OnlyChecksum);
                    }
                }
                    else
                    {
                        FTP_Error.Text = "One or more files or directories can't be downloaded.(named as \"..\" or same exception)";
                    }
                }
            }
            catch (NullReferenceException)
            {
                FTP_Error.Text = "error.";
            }
            catch (FtpCommandException)
            {
                FTP_Error.Text = "Moving error.";
            }
            catch (ArgumentNullException)
            {
                FTP_Error.Text = "Too fast!";
            }
            catch (ArgumentException)
            {
                FTP_Error.Text = "Select disk or folder to download files/folders!";
            }
            catch (Exception err)
            {
                FTP_Error.Text = err.Message;
            }
            Refresh_FileList_0();
            Refresh_FileList_1();
        }

        private void GotoRoot_1_Click(object sender, EventArgs e)
        {
            var client = getClient();
            SetEncoding(client);
            client.SetWorkingDirectory("/");
            WorkingDirectory_1 = client.GetWorkingDirectory().ToString();
            Server_1_Textbox.Text = "/";
            Refresh_FileList_1();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///SERVER_1 WAS ENDED
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///SERVER_0 BEGINING
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Disk_list()
        {
            Disk_block = true;
            WorkingDirectory_0 = "";
            Server_0_listBox.Items.Clear();
            string[] Disks = Directory.GetLogicalDrives();

            foreach (string Disk in Disks)
            {
                Server_0_listBox.Items.Add(Disk);
            }
        }
        private void Refresh_FileList_0()
        {
            FTP_Error.Text = "";
            if (WorkingDirectory_0 != "")
            {
                Server_0_listBox.Items.Clear();
                Server_0_listBox.Items.Insert(0, "..");
                string[] FolderDirectories = Directory.GetDirectories(WorkingDirectory_0);
                foreach (string Folder in FolderDirectories)
                {
                    FileInfo infFolder = new FileInfo(Folder);
                    Server_0_listBox.Items.Add(infFolder.Name);
                }

                string[] Files = Directory.GetFiles(WorkingDirectory_0);
                foreach (string F in Files)
                {
                    FileAttributes attr = File.GetAttributes(F);
                    if (!attr.HasFlag(FileAttributes.Hidden))
                    {
                        if (!attr.HasFlag(FileAttributes.System))
                        {
                            FileInfo inf = new FileInfo(F);
                            Server_0_listBox.Items.Add(inf.Name);
                        }
                    }
                }

                WorkingDirectory_0 = Directory.GetCurrentDirectory();
            }
            else
            {
                FTP_Error.Text = FTP_Error.Text + " Please, select disk.";
            }
        }

        private void InitializeServer_0_ListBox()
        {
            try
            {
                WorkingDirectory_0 = Properties.Settings.Default.LastDirectory;
                Directory.SetCurrentDirectory(WorkingDirectory_0);
                Server_0_Textbox.Text = WorkingDirectory_0;
                Refresh_FileList_0();
            }
            catch (System.ArgumentException)
            {
                Disk_list();
                FTP_Error.Text = "Detected empty default folder... Redirecting to disk list.";

            }
            catch (System.IO.IOException)
            {
                Server_0_Textbox.Text = "";
                WorkingDirectory_0 = "";
                Disk_list();
            }
            catch (Exception err)
            {
                FTP_Error.Text = err.Message;
            }
        }

        private void Server_0_EnterButton_Click(object sender, EventArgs e)
        {
            try
            {
                Directory.SetCurrentDirectory(Server_0_Textbox.Text);
                WorkingDirectory_0 = Server_0_Textbox.Text;
                Refresh_FileList_0();
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                FTP_Error.Text = "This directory is not found.";
            }
            catch (System.IO.IOException)
            {
                FTP_Error.Text = "Bad address. Write address same: \"C:/Users/Admin/Desktop\"";
            }
            catch (System.ArgumentException)
            {
                Disk_list();
            }
            catch (Exception err)
            {
                FTP_Error.Text = err.Message;
            }
        }

        private void MFTP_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.LastDirectory = WorkingDirectory_0;
            Properties.Settings.Default.Save();
        }

        private void Server_0_listBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (FTP_ConnectedState == 1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (Disk_block == false)
                    {
                        if (CopyMoveMode_0 == false)
                        {
                            MoveinConMenu_0.Text = "Move";
                            if (Server_0_listBox.SelectedItem != null)
                            {
                                OpeninConMenu_0.Visible = true;
                                UploadinConMenu_0.Visible = true;
                                MoveinConMenu_0.Visible = true;
                                RenameinConMenu_0.Visible = true;
                                CreateinConMenu_0.Visible = true;
                                DeleteinConMenu_0.Visible = true;
                                PropertiesinConMenu_0.Visible = true;
                            }
                            else
                            {
                                OpeninConMenu_0.Visible = false;
                                UploadinConMenu_0.Visible = false;
                                MoveinConMenu_0.Visible = false;
                                RenameinConMenu_0.Visible = false;
                                CreateinConMenu_0.Visible = true;
                                DeleteinConMenu_0.Visible = false;
                                PropertiesinConMenu_0.Visible = true;
                            }
                        }
                        else if (CopyMoveMode_0 == true)
                        {
                            MoveinConMenu_0.Text = "Move there";
                            if (Server_0_listBox.SelectedItem != null)
                            {
                                OpeninConMenu_0.Visible = true;
                                UploadinConMenu_0.Visible = true;
                                MoveinConMenu_0.Visible = true;
                                RenameinConMenu_0.Visible = true;
                                CreateinConMenu_0.Visible = true;
                                DeleteinConMenu_0.Visible = false;
                                PropertiesinConMenu_0.Visible = true;
                            }
                            else
                            {
                                OpeninConMenu_0.Visible = false;
                                UploadinConMenu_0.Visible = false;
                                MoveinConMenu_0.Visible = true;
                                RenameinConMenu_0.Visible = false;
                                CreateinConMenu_0.Visible = true;
                                DeleteinConMenu_0.Visible = false;
                                PropertiesinConMenu_0.Visible = true;
                            }
                        }
                    }
                    else if (Disk_block == true)
                    {
                        if (Server_0_listBox.SelectedItem != null)
                        {
                            OpeninConMenu_0.Visible = true;
                            UploadinConMenu_0.Visible = false;
                            MoveinConMenu_0.Visible = false;
                            RenameinConMenu_0.Visible = false;
                            CreateinConMenu_0.Visible = false;
                            DeleteinConMenu_0.Visible = false;
                            PropertiesinConMenu_0.Visible = false;
                        }
                        else
                        {
                            OpeninConMenu_0.Visible = false;
                            UploadinConMenu_0.Visible = false;
                            MoveinConMenu_0.Visible = false;
                            RenameinConMenu_0.Visible = false;
                            CreateinConMenu_0.Visible = false;
                            DeleteinConMenu_0.Visible = false;
                            PropertiesinConMenu_0.Visible = false;
                        }
                    }
                    RightClickMenu_0.Show(Server_0_listBox, e.Location);
                }
            }
            else
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (Disk_block == false)
                    {
                        if (CopyMoveMode_0 == false)
                        {
                            MoveinConMenu_0.Text = "Move";
                            if (Server_0_listBox.SelectedItem != null)
                            {
                                OpeninConMenu_0.Visible = true;
                                UploadinConMenu_0.Visible = false;
                                MoveinConMenu_0.Visible = true;
                                RenameinConMenu_0.Visible = true;
                                CreateinConMenu_0.Visible = true;
                                DeleteinConMenu_0.Visible = true;
                                PropertiesinConMenu_0.Visible = true;
                            }
                            else
                            {
                                OpeninConMenu_0.Visible = false;
                                UploadinConMenu_0.Visible = false;
                                MoveinConMenu_0.Visible = false;
                                RenameinConMenu_0.Visible = false;
                                CreateinConMenu_0.Visible = true;
                                DeleteinConMenu_0.Visible = false;
                                PropertiesinConMenu_0.Visible = true;
                            }
                        }
                        else if (CopyMoveMode_0 == true)
                        {
                            MoveinConMenu_0.Text = "Move there";
                            if (Server_0_listBox.SelectedItem != null)
                            {
                                OpeninConMenu_0.Visible = true;
                                UploadinConMenu_0.Visible = false;
                                MoveinConMenu_0.Visible = true;
                                RenameinConMenu_0.Visible = true;
                                CreateinConMenu_0.Visible = true;
                                DeleteinConMenu_0.Visible = true;
                                PropertiesinConMenu_0.Visible = true;
                            }
                            else
                            {
                                OpeninConMenu_0.Visible = false;
                                UploadinConMenu_0.Visible = false;
                                MoveinConMenu_0.Visible = true;
                                RenameinConMenu_0.Visible = false;
                                CreateinConMenu_0.Visible = true;
                                DeleteinConMenu_0.Visible = false;
                                PropertiesinConMenu_0.Visible = true;
                            }
                        }
                    }
                    else if (Disk_block == true)
                    {
                        if (Server_0_listBox.SelectedItem != null)
                        {
                            OpeninConMenu_0.Visible = true;
                            UploadinConMenu_0.Visible = false;
                            MoveinConMenu_0.Visible = false;
                            RenameinConMenu_0.Visible = false;
                            CreateinConMenu_0.Visible = false;
                            DeleteinConMenu_0.Visible = false;
                            PropertiesinConMenu_0.Visible = false;
                        }
                        else
                        {
                            OpeninConMenu_0.Visible = false;
                            UploadinConMenu_0.Visible = false;
                            MoveinConMenu_0.Visible = false;
                            RenameinConMenu_0.Visible = false;
                            CreateinConMenu_0.Visible = false;
                            DeleteinConMenu_0.Visible = false;
                            PropertiesinConMenu_0.Visible = false;
                        }
                    }
                    RightClickMenu_0.Show(Server_0_listBox, e.Location);
                }
            }
        }

        private void OpeninConMenu_0_Click(object sender, EventArgs e)
        {
            Open_0();
        }


        private void Server_0_listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Open_0();
        }

        private void Open_0()
        {
            Disk_block = false;
            if (Server_0_listBox.SelectedItem != null)
            {
                if (WorkingDirectory_0 == "")
                {
                    WorkingDirectory_0 = Server_0_listBox.SelectedItem.ToString();
                    Directory.SetCurrentDirectory(WorkingDirectory_0);
                    Server_0_Textbox.Text = Directory.GetCurrentDirectory();
                    Refresh_FileList_0();
                }
                else
                {
                    try
                    {
                        FileAttributes attr = File.GetAttributes(WorkingDirectory_0 + "/" + Server_0_listBox.SelectedItem.ToString());
                        if (attr.HasFlag(FileAttributes.Directory))
                        {
                            WorkingDirectory_0 = Directory.GetCurrentDirectory() + "/" + Server_0_listBox.SelectedItem.ToString();
                            Directory.SetCurrentDirectory(WorkingDirectory_0);
                            Server_0_Textbox.Text = Directory.GetCurrentDirectory();
                        }
                        else
                        {
                            FTP_Error.Text = "Files is can't be open.";
                        }
                        Refresh_FileList_0();
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        FTP_Error.Text = "Folder/File not found.";
                    }
                    catch (System.UnauthorizedAccessException)
                    {
                        FTP_Error.Text = "Access denied!";
                    }
                    catch (Exception err)
                    {
                        FTP_Error.Text = err.Message;
                    }
                }
            }
        }

        private void UploadinConMenu_0_Click(object sender, EventArgs e)
        {
            var client = getClient();
            SetEncoding(client);

            Uploadcount = 0;
            foreach (int index in Server_0_listBox.SelectedIndices)
            {
                UploadItemName[Uploadcount] = Server_0_listBox.Items[index].ToString();
                UploadTarget[Uploadcount] = WorkingDirectory_1 + "/" + UploadItemName[Uploadcount];
                Uploadcount++;
            }
            try
            {
                for (int i = 0; i < Uploadcount; i++)
                {
                    if (UploadItemName[i] != "..")
                    {
                        FileAttributes attr = File.GetAttributes(WorkingDirectory_0 + "/" + UploadItemName[i]);
                        if (attr.HasFlag(FileAttributes.Directory))
                        {
                            client.UploadDirectory(WorkingDirectory_0 + "/" + UploadItemName[i], UploadTarget[i], FtpFolderSyncMode.Update, FtpRemoteExists.Skip);
                        }
                        else
                        {
                            client.UploadFile(WorkingDirectory_0 + "/" + UploadItemName[i], UploadTarget[i], FtpRemoteExists.Skip, true);
                        }
                    }
                    else
                    {
                        FTP_Error.Text = "One or more files or directories can't be uploaded.(named as \"..\" or same exception)";
                    }
                }
            }
            catch (System.NullReferenceException)
            {
                FTP_Error.Text = "Error.";
            }
            catch (FluentFTP.FtpCommandException err)
            {
                FTP_Error.Text = "Moving error. Full inf. : " + err.Message;
            }
            catch (ArgumentNullException)
            {
                FTP_Error.Text = "Too fast!";
            }
            catch (FluentFTP.FtpException err)
            {
                FTP_Error.Text = err.Message.ToString();
            }
            catch (Exception err)
            {
                FTP_Error.Text = err.Message;
            }
            Refresh_FileList_0();
            Refresh_FileList_1();
        }
    

        private void CreateFolderinConMenu_0_Click(object sender, EventArgs e)
        {
            string[] TextLabels = new string[3];
            TextLabels[0] = "Input name of your New folder";
            TextLabels[1] = "New Folder";
            TextLabels[2] = "Create!";
            Form IBform = new InputBoxForm(TextLabels);
            IBform.ShowDialog();
            string Out = InputBoxForm.Output();
            try
            {
                Directory.CreateDirectory(WorkingDirectory_0 + "/" + Out);
                Refresh_FileList_0();
            }
            catch (System.IO.IOException err)
            {
                FTP_Error.Text = err.Message;
            }
            catch (Exception err)
            {
                FTP_Error.Text = err.Message;
            }
        }

        private void PropertiesinConMenu_0_Click(object sender, EventArgs e)
        {
            string InfFile;
            if (Server_0_listBox.SelectedItem != null)
            {
                InfFile = WorkingDirectory_0 + "/" + Server_0_listBox.SelectedItem;
            }
            else
            {
                InfFile = WorkingDirectory_0;
            }
            Form properties = new PropertiesForm(InfFile, false);
            properties.ShowDialog();
        }

        private void DeleteinConMenu_0_Click(object sender, EventArgs e)
        {
            Deletecount_0 = 0;
            foreach (int index in Server_0_listBox.SelectedIndices)
            {
                DeleteItemName_0[Deletecount_0] = Server_0_listBox.Items[index].ToString();
                DeleteTarget_0[Deletecount_0] = WorkingDirectory_0 + "/" + DeleteItemName_0[Deletecount_0];
                Deletecount_0++;
            }
            try
            {

                for (int i = 0; i < Deletecount_0; i++)
                {
                    if (MoveItemName_0[i] != "..")
                    {
                        FileAttributes attr = File.GetAttributes(DeleteTarget_0[i]);
                        if (attr.HasFlag(FileAttributes.Directory))
                        {
                            if (Directory.GetDirectories(DeleteTarget_0[i]).Length + Directory.GetFiles(DeleteTarget_0[i]).Length > 0)
                            {
                                DirectoryInfo DInf = new DirectoryInfo(DeleteTarget_0[i]);
                                RecursiveDelete(DInf, false);
                            }
                            else
                            {
                                Directory.Delete(DeleteTarget_0[i]);
                            }
                        }
                        else
                        {
                            File.Delete(DeleteTarget_0[i]);
                        }
                    }
                    else
                    {
                        FTP_Error.Text = "One or more items can't be deleted.(named \"..\" or same exception.)";
                    }
                }
            }
            catch (System.IO.IOException err)
            {
                FTP_Error.Text = err.Message;
            }
            catch (Exception err)
            {
                FTP_Error.Text = err.Message;
            }
            Refresh_FileList_0();
        }
    

        ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////
        public static void RecursiveDelete(DirectoryInfo baseDir, bool isRootDir)
        {
            if (!baseDir.Exists)
                return;
            foreach (var dir in baseDir.EnumerateDirectories())
            {
                RecursiveDelete(dir, false);
            }
            foreach (var file in baseDir.GetFiles())
            {
                file.IsReadOnly = false;
                file.Delete();
            }
            if (!isRootDir) baseDir.Delete();
        }
        ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////

        private void GotoDisks_0_Click(object sender, EventArgs e)
        {
            Server_0_Textbox.Text = "";
            Disk_list();
        }

        private void MoveinConMenu_0_Click(object sender, EventArgs e)
        {
            try
            {
                if (CopyMoveMode_0 == false)
                {
                    Copycount_0 = 0;
                    foreach (int index in Server_0_listBox.SelectedIndices)
                    {
                        MoveItemName_0[Copycount_0] = Server_0_listBox.Items[index].ToString();
                        CopyMoveTarget_0[Copycount_0] = WorkingDirectory_0 + "/" + MoveItemName_0[Copycount_0];
                        CopyMoveMode_0 = true;
                        Copycount_0++;
                    }
                }
            
                else
                {
                    for (int i = 0; i < Copycount_0; i++)
                    {
                        if (MoveItemName_0[i] != "..")
                        {
                            FileAttributes attr = File.GetAttributes(CopyMoveTarget_0[i]);
                            if (attr.HasFlag(FileAttributes.Directory))
                            {
                                Directory.Move(CopyMoveTarget_0[i], WorkingDirectory_0 + "/" + MoveItemName_0[i]);
                            }
                            else
                            {
                                File.Move(CopyMoveTarget_0[i], WorkingDirectory_0 + "/" + MoveItemName_0[i]);
                            }
                        }
                        else
                        {
                            FTP_Error.Text = "This is file/directory can't be moved/copied (named as \"..\" or same exception).";
                        }
                    }
                    Refresh_FileList_0();
                    CopyMoveMode_0 = false;
                }
            }
            catch (System.IO.IOException err)
            {
                FTP_Error.Text = err.Message;
                CopyMoveMode_0 = false;
            }
            catch (Exception err)
            {
                FTP_Error.Text = err.Message;
                CopyMoveMode_0 = false;
            }
        }


        private void RenameInConMenu_0_Click(object sender, EventArgs e)
        {
            if (Server_0_listBox.SelectedItem.ToString() == "..")
            {
                FTP_Error.Text = "This folder is can't be renamed.";
            }
            else
            {
                string[] TextLabels = new string[3];
                TextLabels[0] = "Input new name of this file/folder:";
                TextLabels[1] = "example.png";
                TextLabels[2] = "Rename it!";
                Form IBform = new InputBoxForm(TextLabels);
                IBform.ShowDialog();
                string Out = InputBoxForm.Output();

                try
                {
                    CopyMoveTarget_0[0] = WorkingDirectory_0 + "/" + Server_0_listBox.SelectedItem.ToString();

                    FileAttributes attr = File.GetAttributes(CopyMoveTarget_0[0]);
                    if (attr.HasFlag(FileAttributes.Directory))
                    {
                        Directory.Move(CopyMoveTarget_0[0], WorkingDirectory_0 + "/" + Out);
                    }
                    else
                    {
                        File.Move(CopyMoveTarget_0[0], WorkingDirectory_0 + "/" + Out);
                    }
                    Refresh_FileList_0();
                }
                catch (Exception err)
                {
                    FTP_Error.Text = err.Message;
                }
            }
        }
    }
}