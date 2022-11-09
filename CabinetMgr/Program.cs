using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using testface;
using Utilities.SysUtil;

namespace CabinetMgr
{
    static class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static Mutex mutex;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //InitEngine();
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SysHelper.SetProcessDPIAware();
            }

            bool createNew;
            // ReSharper disable once UnusedVariable
            mutex = new Mutex(true, Application.ProductName, out createNew);

            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ApplicationExit += ApplicationOnApplicationExit;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            try
            {
                if (createNew)
                {
                    WebRequest.DefaultWebProxy = null;
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FormMain());
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    Logger.Error(ex);
                }
                catch (Exception)
                {
                    // ignored
                }
                Environment.Exit(0);
            }
        }

        private static void ApplicationOnApplicationExit(object sender, EventArgs e)
        {
            Face.sdk_destroy();
        }

        static void InitEngine()
        {
            try
            {
                string model_path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                int n = Face.sdk_init(null);
                if (n != 0)
                {
                    MessageBox.Show($"人脸识别引擎初始化失败，原因{n}");
                    return;
                }
                FaceAbilityLoad.load_all_ability();
                bool authed = Face.is_auth();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"人脸识别引擎初始化失败，原因{ex.Message}");
            }

        }



        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs ex)
        {
            try
            {
                Logger.Error(ex);
                Logger.Error(ex.Exception.StackTrace);
            }
            catch
            {
                // ignored
            }
            //Environment.Exit(0);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs ex)
        {
            try
            {
                Logger.Error(ex);
                Logger.Error(ex.ExceptionObject);
            }
            catch
            {
                // ignored
            }
            //Environment.Exit(0);
        }
    }
}
