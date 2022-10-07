using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using WebConsole.DAL;

namespace WebConsole.BLL
{
    public class BllDepartInfo
    {
        public static int GetDepartCount(out Exception exception)
        {
            return DalDepartInfo.GetDepartCount(out exception);
        }

        public static IList<DepartInfo> SearchDepartInfo(out Exception exception)
        {
            return DalDepartInfo.SearchDepartInfo(out exception);
        }

        public static IList<DepartInfo> SearchDepartInfoForComp(string[] departIds, out Exception exception)
        {
            return DalDepartInfo.SearchDepartInfoForComp(departIds, out exception);
        }

        public static IList<DepartInfo> SearchChildDepartEx(string departId)
        {
            return DalDepartInfo.SearchChildDepartEx(departId);
        }

        public static DepartInfo GetDepartInfo(string id, out Exception exception)
        {
            return DalDepartInfo.GetDepartInfo(id, out exception);
        }

        public static int AddDepartInfo(string departName, int departLevel, string departParent,
            int departOrder, int isEnabled, string departDesp, UserInfo adminInfo, out Exception exception)
        {
            return DalDepartInfo.AddDepartInfo(departName, departLevel, departParent, departOrder, isEnabled, departDesp,
                adminInfo, out exception);
        }

        public static int ModifyDepartInfo(string departId, string departName, int departOrder, int isEnabled, string departDesp,
            UserInfo adminInfo, out Exception exception)
        {
            if (string.IsNullOrEmpty(departId) || string.IsNullOrEmpty(departName))
            {
                exception = null;
                return -100;
            }
            return DalDepartInfo.ModifyDepartInfo(departId, departName, departOrder, isEnabled, departDesp,
                adminInfo, out exception);
        }

        public static int DeleteDepartInfo(string id, UserInfo adminInfo, out Exception exception)
        {
            return DalDepartInfo.DeleteDepartInfo(id, adminInfo, out exception);
        }
    }
}
