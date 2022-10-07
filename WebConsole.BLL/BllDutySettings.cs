using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using WebConsole.DAL;

namespace WebConsole.BLL
{
    public class BllDutySettings
    {
        public static IList<DutySettings> SearchDutySettings(out Exception exception)
        {
            return DalDutySettings.SearchDutySettings(out exception);
        }

        public static IList<DutySettings> SearchDutySettings(List<string> dutyList, out Exception exception)
        {
            return DalDutySettings.SearchDutySettings(dutyList, out exception);
        }

        public static DutySettings GetDutySettings(string id, out Exception exception)
        {
            return DalDutySettings.GetDutySettings(id, out exception);
        }

        public static IList<DutySettings> GetUserDutySettings(string userId, out Exception exception)
        {
            if (string.IsNullOrEmpty(userId))
            {
                exception = null;
                return null;
            }
            return DalDutySettings.GetUserDutySettings(userId, out exception);
        }

        public static DutySettings GetTargetSetting(string userId, string dutyId, out Exception exception)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(dutyId))
            {
                exception = null;
                return null;
            }
            return DalDutySettings.GetTargetSetting(userId, dutyId, out exception);
        }

        public static int AppendDuty(string userId, string dutyId, out Exception exception)
        {
            return DalDutySettings.AppendDuty(userId, dutyId, out exception);
        }

        public static int SetUserDuty(string userId, string departId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return -100;
            }
            departId = (departId ?? "").Replace(" ", "").TrimEnd(',');
            string[] departList = departId.Split(',');
            return DalDutySettings.SetUserDuty(userId, departList);
        }

        public static int DeleteDutySettings(string infoId, out Exception exception)
        {
            if (string.IsNullOrEmpty(infoId))
            {
                exception = null;
                return -100;
            }
            return DalDutySettings.DeleteDutySettings(infoId, out exception);
        }

        public static int DeleteUserDutySettings(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return -100;
            return DalDutySettings.DeleteUserDutySettings(userId);
        }
    }
}
