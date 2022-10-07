using System;
using System.Web.Script.Services;
using System.Web.Services;
using Domain.Server.Domain;
using FineUIPro;
using Utilities.Net;
using WebConsole.Config;
using WebConsole.Framework.Logic;

namespace WebConsole
{
    public partial class Default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = Env.AppName;

            UserInfo userInfo = SessionManager.GetUserInfo();

            tbUserName.Text = $"欢迎回来: {userInfo.RealName} [{NetOperation.GetClientIPv4Address()}]";
            tbOnlineUserCount.Text = "在线用户数: " + Application["user_sessions"];

            TreeNode pNode = TreeManager.GetMenuTree();
            if (pNode.Nodes.Count > 0)
            {
                treeMenu.Nodes.Clear();
                for (int i = 0; i < pNode.Nodes.Count; i++)
                {
                    treeMenu.Nodes.Add(pNode.Nodes[i]);
                }
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static int LogOut()
        {
            SessionManager.ClearUserInfo();
            return 1;
        }
    }
}