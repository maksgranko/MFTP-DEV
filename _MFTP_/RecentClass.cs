namespace _MFTP_
{
    internal class RecentClass
    {
        public static void InitConfig()
        {
            if (Properties.Recent.Default.Recent_IP is null || Properties.Recent.Default.Recent_Login is null || Properties.Recent.Default.Recent_Pass is null || Properties.Recent.Default.Recent_Port is null)
            {
                Properties.Recent.Default.Recent_IP = new System.Collections.Specialized.StringCollection();
                Properties.Recent.Default.Recent_Login = new System.Collections.Specialized.StringCollection();
                Properties.Recent.Default.Recent_Pass = new System.Collections.Specialized.StringCollection();
                Properties.Recent.Default.Recent_Port = new System.Collections.Specialized.StringCollection();
            }
        }

        public static bool Add(string IP, string Username, string Password, string Port)
        {
            bool HasChanges = false;
            if (Properties.Recent.Default.Recent_IP.Contains(IP))
            {
                ushort index = (ushort)Properties.Recent.Default.Recent_IP.IndexOf(IP);
                if (Properties.Recent.Default.Recent_Login[index] != Username)
                {
                    Properties.Recent.Default.Recent_Login.RemoveAt(index);
                    Properties.Recent.Default.Recent_Login.Insert(index, Username);
                    HasChanges = true;
                }
                if (Properties.Recent.Default.Recent_Pass[index] != Password)
                {
                    Properties.Recent.Default.Recent_Pass.RemoveAt(index);
                    Properties.Recent.Default.Recent_Pass.Insert(index, Password);
                    HasChanges = true;
                }
                if (Properties.Recent.Default.Recent_Port[index] != Port)
                {
                    Properties.Recent.Default.Recent_Port.RemoveAt(index);
                    Properties.Recent.Default.Recent_Port.Insert(index, Password);
                    HasChanges = true;
                }
                if (HasChanges)
                {
                    Properties.Recent.Default.Save();
                }
                return true;
            }
            Properties.Recent.Default.Recent_IP.Add(IP);
            Properties.Recent.Default.Recent_Login.Add(Username);
            Properties.Recent.Default.Recent_Pass.Add(Password);
            Properties.Recent.Default.Recent_Port.Add(Port);
            Properties.Recent.Default.Save();
            return true;
        }

        public static bool Del(string IP)
        {
            if (Properties.Recent.Default.Recent_IP.Contains(IP))
            {
                ushort index = (ushort)Properties.Recent.Default.Recent_IP.IndexOf(IP);
                Properties.Recent.Default.Recent_IP.RemoveAt(index);
                Properties.Recent.Default.Recent_Login.RemoveAt(index);
                Properties.Recent.Default.Recent_Pass.RemoveAt(index);
                Properties.Recent.Default.Recent_Port.RemoveAt(index);
                Properties.Recent.Default.Save();
                return true;
            }
            return false;
        }
        public static string[] Get(string IP)
        {
            ushort index = (ushort)Properties.Recent.Default.Recent_IP.IndexOf(IP);
            string[] result = new string[3];
            result[0] = Properties.Recent.Default.Recent_Login[index];
            result[1] = Properties.Recent.Default.Recent_Pass[index];
            result[2] = Properties.Recent.Default.Recent_Port[index];
            return result;
        }
        public static string[] GetAll()
        {
            string[] result = new string[(ushort)Properties.Recent.Default.Recent_Login.Count];
            ushort counter = 0;
            if (Properties.Recent.Default.Recent_Login.Count > 0)
            {
                foreach (string item in Properties.Recent.Default.Recent_IP)
                {
                    result[counter] = item;
                    counter++;
                }
            }
            else
            {
                result = new string[1];
                result[0] = "empty";
            }
            return result;
        }
    }
}
