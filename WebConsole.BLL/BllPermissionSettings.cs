using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using Utilities.DbHelper;
using WebConsole.DAL;

namespace WebConsole.BLL
{
    public class BllPermissionSettings
    {

        public static IList<PermissionSettings> SearchPermissionSettings(out Exception exception)
        {
            return DalPermissionSettings.SearchPermissionSettings(out exception);
        }

        public static IList<PermissionSettings> SearchPermissionSettings(string permissionId, out Exception exception)
        {
            return DalPermissionSettings.SearchPermissionSettings(permissionId, out exception);
        }

        public static IList<PermissionSettings> GetFullPermissionSettings(string userId, List<string>roleList, out Exception exception)
        {
            exception = null;
            IList<PermissionSettings> permList = new List<PermissionSettings>();
            if (!string.IsNullOrEmpty(userId))
            {
                IList<PermissionSettings> userPerm = DalPermissionSettings.GetOwnerPermissionSettings(userId, out exception);
                if (SqlDataHelper.IsDataValid(userPerm))
                {
                    foreach (var permObj in userPerm)
                    {
                        permList.Add(permObj);
                    }
                }
            }
            if (roleList != null && roleList.Count > 0)
            {
                for (int i = 0; i < roleList.Count; i++)
                {
                    IList<PermissionSettings> userPerm = DalPermissionSettings.GetOwnerPermissionSettings(roleList[i], out exception);
                    if (SqlDataHelper.IsDataValid(userPerm))
                    {
                        foreach (var permObj in userPerm)
                        {
                            permList.Add(permObj);
                        }
                    }
                }
            }
            return permList;
        }

        public static IList<PermissionSettings> GetOwnerPermissionSettings(string ownerId, out Exception exception)
        {
            if (string.IsNullOrEmpty(ownerId))
            {
                exception = null;
                return null;
            }
            return DalPermissionSettings.GetOwnerPermissionSettings(ownerId, out exception);
        }

        public static PermissionSettings GetPermissionSettings(string id, out Exception exception)
        {
            return DalPermissionSettings.GetPermissionSettings(id, out exception);
        }

        public static int SavePermissionSettings(PermissionSettings permissionSettings, out Exception exception)
        {
            return DalPermissionSettings.SavePermissionSettings(permissionSettings, out exception);
        }

        public static int SetOwnerPermission(string ownerType, string ownerId, string permId)
        {
            if (string.IsNullOrEmpty(ownerId)) return -100;
            permId = (permId ?? "").Replace(" ", "").TrimEnd(',');
            string[] permList = permId.Split(',');
            return DalPermissionSettings.SetOwnerPermission(ownerType, ownerId, permList);
        }

        public static int DeletePermissionSettings(string id, out Exception exception)
        {
            if (string.IsNullOrEmpty(id))
            {
                exception = null;
                return -100;
            }
            return DalPermissionSettings.DeletePermissionSettings(id, out exception);
        }
    }
}
