using System;
using System.IO;
using System.Text;
using WebConsole.BLL;
using WebConsole.Config;

namespace WebConsole
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["user_sessions"] = 0;

            #region Aspose License
            MemoryStream ms = new MemoryStream();
            byte[] licenseBytes = Encoding.Default.GetBytes(Env.AsposeLicense);
            ms.Write(licenseBytes, 0, licenseBytes.Length);
            ms.Flush();

            ms.Seek(0, SeekOrigin.Begin);
            Aspose.Words.License docLicense = new Aspose.Words.License();
            docLicense.SetLicense(ms);

            ms.Seek(0, SeekOrigin.Begin);
            Aspose.Cells.License xlsLicense = new Aspose.Cells.License();
            xlsLicense.SetLicense(ms);

            ms.Seek(0, SeekOrigin.Begin);
            Aspose.BarCode.License barLicense = new Aspose.BarCode.License();
            barLicense.SetLicense(ms);

            ms.Seek(0, SeekOrigin.Begin);
            Aspose.Pdf.License pdfLicense = new Aspose.Pdf.License();
            pdfLicense.SetLicense(ms);

            ms.Close();
            #endregion

            BllSysManager.ExecConnect(out _);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["user_sessions"] = (int)Application["user_sessions"] + 1;
            Application.UnLock();
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["user_sessions"] = (int)Application["user_sessions"] - 1;
            Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}