using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Server.Domain;
using FineUIPro;
using Utilities.DbHelper;
using WebConsole.BLL;
using WebConsole.Config;
using WebConsole.Framework.Logic;

namespace WebConsole
{
    public partial class Login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            windowLogin.Title = $"{Env.AppName} V{Version}";
            if (!IsPostBack)
            {
#if DEBUG
                tbUserName.Text = "admin";
                tbPassword.Text = "123456";
#endif
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text.Trim();
            string password = tbPassword.Text;
            if (string.IsNullOrEmpty(tbUserName.Text) || string.IsNullOrEmpty(tbPassword.Text))
            {
                Alert.Show("请输入用户名及密码");
                return;
            }
            UserInfo ui = BllUserInfo.GetUserInfo(userName, password, out _);
            if (ui == null)
            {
                Alert.Show("用户名或密码错误");
                return;
            }
            SessionManager.SetUserInfo(ui);
            List<string> roleList = new List<string>();
            IList<RoleSettings> roleData = BllRoleSettings.GetUserRoleSettings(ui.Id, out _);
            if (SqlDataHelper.IsDataValid(roleData))
            {
                for (int i = 0; i < roleData.Count; i++)
                {
                    roleList.Add(roleData[i].RoleId);
                }
            }
            IList<PermissionSettings> permList = BllPermissionSettings.GetFullPermissionSettings(ui.Id, roleList, out _);
            if (SqlDataHelper.IsDataValid(permList))
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < permList.Count; i++)
                {
                    ht[permList[i].AccessId] = 1;
                }
                SessionManager.SetPermission(ht);
            }
            Response.Redirect("Default.aspx");
        }
    }
}