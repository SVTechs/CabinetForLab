using System;
using System.Text;
using System.Web;
using System.Web.UI;
using FineUIPro;
using Newtonsoft.Json.Linq;

namespace WebConsole.Framework.Logic
{
    public class PageBase : Page
    {
        private JObject _ctrlJson;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // 设置主题
            if (PageManager.Instance != null)
            {
                PageManager.Instance.Theme = FineUIPro.Theme.Metro_Dark_Blue;
            }

            // 向页面提交控件ID
            _ctrlJson = new JObject();
            GetClientId(Controls);
            string ctrlInfo = $"window.BasePath='{GetRootPath()}'; window.Ctrl={_ctrlJson.ToString(Newtonsoft.Json.Formatting.None)}; ";
            PageContext.RegisterStartupScript(ctrlInfo);
        }

        public void GetClientId(ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {
                if (ctrl is TabStrip)
                {
                    _ctrlJson.Add(((ControlBase)ctrl).ID, ((ControlBase)ctrl).ClientID);
                    continue;
                }
                if (ctrl is Grid)
                {
                    _ctrlJson.Add(((ControlBase)ctrl).ID, ((ControlBase)ctrl).ClientID);
                }
                if (ctrl is Window)
                {
                    _ctrlJson.Add(((ControlBase)ctrl).ID, ((ControlBase)ctrl).ClientID);
                }
                if (ctrl is Panel)
                {
                    _ctrlJson.Add(((ControlBase)ctrl).ID, ((ControlBase)ctrl).ClientID);
                }
                if (ctrl is SimpleForm)
                {
                    try
                    {
                        _ctrlJson.Add(((ControlBase)ctrl).ID, ((ControlBase)ctrl).ClientID);
                    }
                    catch (Exception)
                    {
                        // ignore dup item
                    }
                }
                if (ctrl.Controls.Count > 0)
                {
                    GetClientId(ctrl.Controls);
                }
                else if (ctrl is ControlBase)
                {
                    try
                    {
                        _ctrlJson.Add(((ControlBase)ctrl).ID, ((ControlBase)ctrl).ClientID);
                    }
                    catch (Exception)
                    {
                        // ignore dup item
                    }
                }
            }
        }

        public string GetRootPath()
        {
            string absolutePath = HttpContext.Current.Request.Url.AbsoluteUri;
            string hostNameAndPort = HttpContext.Current.Request.Url.Authority;
            string applicationDir = HttpContext.Current.Request.ApplicationPath;
            StringBuilder sbRequestUrl = new StringBuilder();
            sbRequestUrl.Append(absolutePath.Substring(0, absolutePath.IndexOf(hostNameAndPort)));
            sbRequestUrl.Append(hostNameAndPort);
            sbRequestUrl.Append(applicationDir);
            return sbRequestUrl.ToString();
        }

        /// <summary>
        /// 获取回发的参数
        /// </summary>
        /// <returns></returns>
        public string GetRequestEventArgument()
        {
            return Request.Form["__EVENTARGUMENT"];
        }

        public static string Version
        {
            get
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                DateTime buildDate = new DateTime(2000, 1, 1)
                    .AddDays(version.Build).AddSeconds(version.Revision * 2);
                return $"{version} ({buildDate:yyMMdd})";
            }
        }
    }
}