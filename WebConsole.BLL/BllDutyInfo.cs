using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using WebConsole.DAL;

namespace WebConsole.BLL
{
    public class BllDutyInfo
    {
        public static int GetDutyCount(out Exception exception)
        {
            return DalDutyInfo.GetDutyCount(out exception);
        }

        public static IList<DutyInfo> SearchDutyInfo(out Exception exception)
        {
            return DalDutyInfo.SearchDutyInfo(out exception);
        }

        public static IList<DutyInfo> SearchDutyInfoForComp(string []departIds, out Exception exception)
        {
            return DalDutyInfo.SearchDutyInfoForComp(departIds, out exception);
        }

        public static IList<DutyInfo> SearchChildDutyEx(string departId)
        {
            return DalDutyInfo.SearchChildDutyEx(departId);
        }

        public static DutyInfo GetDutyInfo(string id, out Exception exception)
        {
            return DalDutyInfo.GetDutyInfo(id, out exception);
        }

        public static int AddDutyInfo(string departName, int departLevel, string departParent,
            int departOrder, string dutyDesp, int isEnabled, UserInfo adminInfo, out Exception exception)
        {
            return DalDutyInfo.AddDutyInfo(departName, departLevel, departParent, departOrder,  
                dutyDesp, isEnabled, adminInfo, out exception);
        }

        public static int ModifyDutyInfo(string departId, string departName, int departOrder,
            string dutyDesp, int isEnabled, UserInfo adminInfo, out Exception exception)
        {
            if (string.IsNullOrEmpty(departId) || string.IsNullOrEmpty(departName))
            {
                exception = null;
                return -100;
            }
            return DalDutyInfo.ModifyDutyInfo(departId, departName, departOrder,  
                dutyDesp, isEnabled, adminInfo, out exception);
        }

        public static int DeleteDutyInfo(string id, string operateUser, string operateUserName, out Exception exception)
        { 
            return DalDutyInfo.DeleteDutyInfo(id, operateUser, operateUserName, out exception);
        }
    }
}
