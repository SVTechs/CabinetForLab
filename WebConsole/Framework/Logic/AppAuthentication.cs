using System;
using System.Text;
using System.Web;
using Domain.Server.Domain;
using WebConsole.BLL;
using WebConsole.Config;

namespace WebConsole.Framework.Logic
{
    /// <summary>
    /// AuthenticationModule 的摘要说明
    /// </summary>
    public class AppAuthentication : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += context_AcquireRequestState;
        }

        void context_AcquireRequestState(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;

            //生成当前路径
            string relPath = context.Request.ApplicationPath;
            if (string.IsNullOrEmpty(relPath) || relPath.Equals("/"))
            {
                Env.AppRoot = "/";
            }
            else
            {
                Env.AppRoot = context.Request.ApplicationPath + "/";
                if (!Env.AppRoot.StartsWith("/")) Env.AppRoot = "/" + Env.AppRoot;
            }

            //基本Session验证
            string requestUrl = application.Request.Url.ToString();
            //if (requestUrl.Contains("AuthExclude")) return;

            string requestPage = requestUrl.Substring(requestUrl.LastIndexOf('/') + 1).ToUpper();
            if (requestPage.Contains("?")) requestPage = requestPage.Substring(0, requestPage.IndexOf("?", StringComparison.Ordinal));
            if (requestPage.Contains(".ASPX"))
            {
                //未登录仅能访问登录页面
                if (requestPage.Equals("LOGIN.ASPX")) return;
                if (!SessionManager.IsLogin())
                {
                    //未登录则跳转至登录页面
                    context.Response.ContentType = "text/html";
                    string script = "<html><head><script type='text/javascript'>{0}</script></head><body>跳转中</body></html>";
                    script = string.Format(script,
                        "window.top.location.href='" + Env.AppRoot + "Login.aspx" + "';");
                    context.Response.Clear();
                    context.Response.Write(script);
                    context.Response.End();
                    return;
                }
                //权限检测
                string checkPath = application.Request.AppRelativeCurrentExecutionFilePath?.Substring(2);
                if (!string.IsNullOrEmpty(checkPath))
                {
                    var menuInfo = BllPageMenus.GetPageMenuByUrl(checkPath, out var ex);
                    if (ex != null)
                    {
                        context.Response.Clear();
                        context.Response.Write(GenerateInfoPage("页面显示异常，请尝试刷新"));
                        context.Response.End();
                        return;
                    }
                    if (menuInfo == null) return;
                    bool isPermitted = SessionManager.CheckPermission(menuInfo.Id);
                    if (!isPermitted)
                    {
                        SysDataHistory sd = new SysDataHistory();
                        sd.OperateType = "非法访问";
                        sd.DataType = "非法访问";
                        sd.OperateDesp = $"未授权访问页面 [{checkPath}]";
                        if (SessionManager.IsLogin())
                        {
                            UserInfo ui = SessionManager.GetUserInfo();
                            sd.OperateUser = ui.Id;
                            sd.OperateUserName = ui.UserName;
                        }
                        sd.OperateTime = DateTime.Now;
                        BllSysDataHistory.SaveSysDataHistory(sd, out _);

                        context.Response.Clear();
                        context.Response.Write(GenerateInfoPage("非法访问，您的IP及登录信息已被记录"));
                        context.Response.End();
                        return;
                    }
                }
            }
        }

        private string GenerateInfoPage(string msg)
        {
            return $@"<html>
<head>
<meta charset=""UTF-8"" />
<title>警告</title>
</head>
<body>
{msg}
</body>
</html>";
        }

        public void Dispose()
        {

        }
    }
}