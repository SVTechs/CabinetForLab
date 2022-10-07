using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Server.Domain;

namespace WebConsole.BLL
{
    public class PermissionControl
    {
        public static IList<UserInfo> SearchSubordinate(string funcGroup, string userPermission, UserInfo userinfo, IList<DepartSettings> departSettings)
        {
            switch (funcGroup)
            {
                case "":
                    //Func1
                    return null;
            }
            return null;
        }

        private static List<string> MergeDepartSettings(IList<DepartInfo>[] departList)
        {
            List<string> departIds = new List<string>();
            Hashtable existTable = new Hashtable();
            for (int i = 0; i < departList.Length; i++)
            {
                for (int j = 0; j < departList[i].Count; j++)
                {
                    if (existTable[departList[i][j].Id] == null)
                    {
                        departIds.Add(departList[i][j].Id);
                        existTable[departList[i][j].Id] = 1;
                    }
                }
            }
            return departIds;
        }

        private static List<string> GetDepartIds(IList<DepartSettings> departSettings)
        {
            List<string> deptIds = new List<string>();
            for (int i = 0; i < departSettings.Count; i++)
            {
                deptIds.Add(departSettings[i].DepartId);
            }
            return deptIds;
        }

        private static List<string> GetUserIds(IList<DepartSettings> departSettings)
        {
            List<string> userIds = new List<string>();
            for (int i = 0; i < departSettings.Count; i++)
            {
                userIds.Add(departSettings[i].UserId);
            }
            return userIds;
        }
    }
}