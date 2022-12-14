using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Utilities.SysUtil
{
    public class SysHelper
    {
        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();

        public static string GetCurrentDirectory()
        {
            string exePath = Assembly.GetExecutingAssembly().Location;
            if (exePath != null) return exePath.Substring(0, exePath.LastIndexOf('\\') + 1);
            return "";
        }

        public static bool IsAutoRun(string appName, string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    return false;
                }
                var reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (reg == null)
                    reg = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                if (reg == null)
                    return false;
                if (reg.GetValue(appName).ToString() == fileName)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public static bool SetAutoRun(string appName, string fileName, bool isAutoRun)
        {
            try
            {
                if (!File.Exists(fileName))
                    throw new Exception("该文件不存在!");
                var reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (reg == null)
                    reg = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                if (reg == null)
                    return false;
                if (isAutoRun)
                {
                    reg.SetValue(appName, fileName);
                }
                else
                {
                    if (appName != null) reg.DeleteValue(appName);
                }
                string reCheck = reg.GetValue(appName).ToString();
                if (string.IsNullOrEmpty(reCheck))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public class WindowWrapper : IWin32Window
        {
            private global::System.IntPtr _hwnd;
            public WindowWrapper(global::System.IntPtr handle)
            {
                _hwnd = handle;
            }
            public global::System.IntPtr Handle
            {
                get { return _hwnd; }
            }
        }

        public static DialogResult MessageBoxFG(string message, string title)
        {
            IntPtr IntPart = GetForegroundWindow();
            WindowWrapper ParentFrm = new WindowWrapper(IntPart);
            return MessageBox.Show(ParentFrm, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult MessageBoxFG_OkCancel(string message, string title)
        {
            IntPtr IntPart = GetForegroundWindow();
            WindowWrapper ParentFrm = new WindowWrapper(IntPart);
            return MessageBox.Show(ParentFrm, message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        [DllImport("user32")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("Kernel32.dll")]
        private static extern void GetLocalTime(SystemTime st);
        [DllImport("Kernel32.dll")]
        private static extern void SetLocalTime(SystemTime st);

        [StructLayout(LayoutKind.Sequential)]
        private class SystemTime
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort Whour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;

        }

        public static void SetSystemTime(string TimeStr)
        {
            DateTime DTime = DateTime.Parse(TimeStr);
            SystemTime st = new SystemTime();
            st.wYear = (ushort)DTime.Year;
            st.wMonth = (ushort)DTime.Month;
            st.wDay = (ushort)DTime.Day;
            st.Whour = (ushort)DTime.Hour;
            st.wMinute = (ushort)DTime.Minute;
            st.wSecond = (ushort)DTime.Second;
            SetLocalTime(st);
        }
    }
}
