using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using WebConsole.DAL;

namespace WebConsole.BLL
{
    public class BllDepartSettings
    {
        public static IList<DepartSettings> SearchDepartSettings(out Exception exception)
        {
            return DalDepartSettings.SearchDepartSettings(out exception);
        }

        public static IList<DepartSettings> SearchDepartSettings(List<string> departList, out Exception exception)
        {
            return DalDepartSettings.SearchDepartSettings(departList, out exception);
        }

        public static DepartSettings GetDepartSettings(string id, out Exception exception)
        {
            return DalDepartSettings.GetDepartSettings(id, out exception);
        }

        public static IList<DepartSettings> GetUserDepartSettings(string userId, out Exception exception)
        {
            if (string.IsNullOrEmpty(userId))
            {
                exception = null;
                return null;
            }
            return DalDepartSettings.GetUserDepartSettings(userId, out exception);
        }

        public static DepartSettings GetTargetSetting(string userId, string departId, out Exception exception)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(departId))
            {
                exception = null;
                return null;
            }
            return DalDepartSettings.GetTargetSetting(userId, departId, out exception);
        }

        public static int AppendDepart(string userId, string departId, out Exception exception)
        {
            return DalDepartSettings.AppendDepart(userId, departId, out exception);
        }

        public static int SetUserDepart(string userId, string departId, UserInfo adminInfo)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return -100;
            }
            departId = (departId ?? "").Replace(" ", "").TrimEnd(',');
            string[] departList = departId.Split(',');
            return DalDepartSettings.SetUserDepart(userId, departList, adminInfo);
        }

        public static int DeleteDepartSettings(string infoId, UserInfo adminInfo, out Exception exception)
        {
            if (string.IsNullOrEmpty(infoId))
            {
                exception = null;
                return -100;
            }
            return DalDepartSettings.DeleteDepartSettings(infoId, adminInfo, out exception);
        }

        public static int DeleteUserDepartSettings(string userId, out Exception exception)
        {
            if (string.IsNullOrEmpty(userId))
            {
                exception = null;
                return -100;
            }
            return DalDepartSettings.DeleteUserDepartSettings(userId, out exception);
        }
    }
}
