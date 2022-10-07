using System.Collections;
using System.Web;
using Domain.Server.Domain;
using FineUIPro;

namespace WebConsole.Framework.Logic
{
    public class SessionManager
    {
        public static bool IsLogin()
        {
            if (HttpContext.Current.Session == null) return true;
            if (HttpContext.Current.Session["LoginState"] == null ||
                (bool) HttpContext.Current.Session["LoginState"] == false)
            {
                return false;
            }
            return true;
        }

        private static bool CheckSessionState()
        {
            if (HttpContext.Current.Session == null || HttpContext.Current.Session["LoginState"] == null ||
                (bool) HttpContext.Current.Session["LoginState"] == false)
            {
                return false;
            }
            return true;
        }

        public static void SetUserInfo(UserInfo ui)
        {
            HttpContext.Current.Session["UserInfo"] = ui;
            HttpContext.Current.Session["LoginState"] = true;
        }

        public static void SetPermission(Hashtable ht)
        {
            HttpContext.Current.Session["UserPerm"] = ht;
        }

        public static void ClearUserInfo()
        {
            HttpContext.Current.Session["UserInfo"] = null;
            HttpContext.Current.Session["LoginState"] = false;
            HttpContext.Current.Session["UserPerm"] = null;
        }

        public static Hashtable GetPermission()
        {
            if (HttpContext.Current.Session["UserPerm"] == null) return null;
            return (Hashtable)HttpContext.Current.Session["UserPerm"];
        }

        public static string GetUserId()
        {
            if (HttpContext.Current.Session["UserInfo"] == null) return null;
            UserInfo ui = (UserInfo)HttpContext.Current.Session["UserInfo"];
            return ui.Id;
        }

        public static UserInfo GetUserInfo()
        {
            if (HttpContext.Current.Session["UserInfo"] == null) return null;
            return (UserInfo)HttpContext.Current.Session["UserInfo"];
        }

        public static string GetRealName()
        {
            if (HttpContext.Current.Session["UserInfo"] == null) return null;
            UserInfo ui = (UserInfo)HttpContext.Current.Session["UserInfo"];
            return ui.RealName;
        }

        public static bool CheckPermission(string funcCode)
        {
            if (HttpContext.Current.Session["UserPerm"] == null)
            {
                Alert.Show("提示", "用户信息异常，请重新登录");
                return false;
            }
            Hashtable permHt = (Hashtable)HttpContext.Current.Session["UserPerm"];
            if (permHt[funcCode] == null)
            {
                return false;
            }
            return true;
        }
    }
}