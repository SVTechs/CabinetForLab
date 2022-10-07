using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using WebConsole.DAL;

namespace WebConsole.BLL
{
    public class BllRoleInfo
    {
        public static int GetRoleCount(string roleName, out Exception exception)
        {
            return DalRoleInfo.GetRoleCount(roleName, out exception);
        }

        public static IList<RoleInfo> SearchRoleInfo(string roleName, int dataStart, int dataCount, out Exception exception)
        {
            return DalRoleInfo.SearchRoleInfo(roleName, dataStart, dataCount, out exception);
        }

        public static RoleInfo GetRoleInfo(string roleId, out Exception exception)
        {
            if (string.IsNullOrEmpty(roleId))
            {
                exception = null;
                return null;
            }
            return DalRoleInfo.GetRoleInfo(roleId, out exception);
        }

        public static int AddRoleInfo(string roleName, int roleLevel, string roleParent, int roleOrder, string roleDesp, int isEnabled,
            UserInfo userInfo, out Exception exception)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                exception = null;
                return -100;
            }
            return DalRoleInfo.AddRoleInfo(roleName, roleLevel, roleParent, roleOrder, roleDesp, isEnabled,
                userInfo, out exception);
        }

        public static int ModifyRoleInfo(string roleId, string roleName, int roleOrder, string roleDesp, int isEnabled,
            UserInfo userInfo, out Exception exception)
        {
            if (string.IsNullOrEmpty(roleId) || string.IsNullOrEmpty(roleName))
            {
                exception = null;
                return -100;
            }
            return DalRoleInfo.ModifyRoleInfo(roleId, roleName, roleOrder, roleDesp, isEnabled,
                userInfo, out exception);
        }

        public static int DeleteRoleInfo(string roleId, string operateUser, string operateUserName, out Exception exception)
        {
            if (string.IsNullOrEmpty(roleId))
            {
                exception = null;
                return -100;
            }
            //清除角色权限配置(非重要)
            DalPermissionSettings.DeleteOwnerPermissionSettings(roleId, out exception);
            //删除角色
            return DalRoleInfo.DeleteRoleInfo(roleId, operateUser, operateUserName, out exception);
        }
    }
}
