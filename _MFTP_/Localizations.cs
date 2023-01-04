using _MFTP_.Resources.Localizations;
using System.Globalization;
using System.IO;
using System.Resources;

namespace _MFTP_
{
    internal class Localizations
    {
        private static string Defaultlocale = "INHERITED_en_US";
        private static ResourceManager rm = INHERITED_en_US.ResourceManager;
        private static CultureInfo cult = CultureInfo.CreateSpecificCulture("en_US");
        private static ResourceSet rs = rm.GetResourceSet(cult, true, true);
        private bool Autolocale;
        private static bool safeMode = false;

        public bool SafeMode()
        {
            return safeMode;
        }

        public ResourceSet Setlocale()
        {
            Autolocale = Properties.Settings.Default.Autolocale;
            if (Autolocale == true)
            {
                Defaultlocale = CultureInfo.CurrentUICulture.ToString().Replace("-", "_");
            }
            else
            {
                Defaultlocale = Properties.Settings.Default.SelectedLocale;
            }
            if (File.Exists("Resources\\Localizations\\" + Defaultlocale + ".resx"))
            {
                if (Defaultlocale == "ru_RU")
                {
                    rm = ru_RU.ResourceManager;
                    cult = CultureInfo.CreateSpecificCulture("ru_RU");
                    rs = rm.GetResourceSet(cult, true, true);
                }
            }
            else {
                safeMode = true;
            }
            return rs;
        }
    }
}
