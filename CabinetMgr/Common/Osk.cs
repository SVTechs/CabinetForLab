using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetMgr.Common
{
    public static class Osk
    {

        private static Process kbpr;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public static void ShowInputPanel()
        {
            try
            {
                if (kbpr == null || kbpr.HasExited)
                {
                    string path64 =
                        Path.Combine(
                            Directory.GetDirectories(
                                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "winsxs"),
                                "amd64_microsoft-windows-osk_*")[0], "osk.exe");
                    string path32 = @"C:\windows\system32\osk.exe";
                    kbpr = System.Diagnostics.Process.Start((Environment.Is64BitOperatingSystem) ? path64 : path32);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public static void HideInputPanel()
        {
            if (kbpr != null && !kbpr.HasExited)
            {
                kbpr.Kill();
            }
        }

    }
}
