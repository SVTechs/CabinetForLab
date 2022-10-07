using System;
using System.Web;

namespace WebConsole.Master
{
    public partial class Main : System.Web.UI.MasterPage
    {
        public string RelPath, AppPath;

        protected void Page_Load(object sender, EventArgs e)
        {
            AppPath = HttpContext.Current.Request.ApplicationPath ?? "";
            if (AppPath == "/")
            {
                AppPath = "";
            }
            else
            {
                AppPath = AppPath.Substring(1);
            }
            string filePath = HttpContext.Current.Request.CurrentExecutionFilePath.Substring(AppPath.Length);

            int depth = 0;
            for (int i = 0; i < filePath.Length; i++)
            {
                if (filePath[i] == '/')
                {
                    depth++;
                }
            }
            for (int i = 0; i < depth - 1; i++)
            {
                RelPath += "../";
            }
        }
    }
}