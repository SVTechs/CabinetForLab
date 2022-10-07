using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using WebConsole.DAL;

namespace WebConsole.BLL
{
    public class BllRoleSettings
    {

        public static IList<RoleSettings> SearchRoleSettings(out Exception exception)
        {
            return DalRoleSettings.SearchRoleSettings(out exception);
        }

        public static IList<RoleSettings> SearchRoleSettings(string roleId, out Exception exception)
        {
            return DalRoleSettings.SearchRoleSettings(roleId, out exception);
        }

        public static IList<RoleSettings> GetUserRoleSettings(string userId, out Exception exception)
        {
            return DalRoleSettings.GetUserRoleSettings(userId, out exception);
        }

        public static RoleSettings GetRoleSettings(string id, out Exception exception)
        {
            return DalRoleSettings.GetRoleSettings(id, out exception);
        }

        public static RoleSettings GetTargetSetting(string userId, string roleId, out Exception exception)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(roleId))
            {
                exception = null;
                return null;
            }
            return DalRoleSettings.GetTargetSetting(userId, roleId, out exception);
        }

        public static int AppendRole(string userId, string roleId, out Exception exception)
        {
            return DalRoleSettings.AppendRole(userId, roleId, out exception);
        }

        public static int SetUserRole(string userId, string roleId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return -100;
            }
            roleId = (roleId ?? "").Replace(" ", "").TrimEnd(',');
            string[] roleList = roleId.Split(',');
            return DalRoleSettings.SetUserRole(userId, roleList);
        }

        public static int DeleteUserSettings(string userId, out Exception ex)
        {
            if (string.IsNullOrEmpty(userId))
            {
                ex = null;
                return -100;
            }
            return DalRoleSettings.DeleteUserRoleSettings(userId, out ex);
        }

        public static int DeleteRoleSettings(string id, out Exception exception)
        {
            return DalRoleSettings.DeleteRoleSettings(id, out exception);
        }
    }
}
