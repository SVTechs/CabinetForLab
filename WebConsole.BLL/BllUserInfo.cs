using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Server.Domain;
using Domain.Server.Types;
using Utilities.Data;
using Utilities.DbHelper;
using Utilities.Encryption;
using WebConsole.DAL;
using WebConsole.DAL.NhUtils;

namespace WebConsole.BLL
{
    public class BllUserInfo
    {
        public static Hashtable GetPermissions(string userId)
        {
            List<string> roleList = new List<string>();
            IList<RoleSettings> roleData = BllRoleSettings.GetUserRoleSettings(userId, out _);
            if (SqlDataHelper.IsDataValid(roleData))
            {
                for (int i = 0; i < roleData.Count; i++)
                {
                    roleList.Add(roleData[i].RoleId);
                }
            }
            IList<PermissionSettings> permList = BllPermissionSettings.GetFullPermissionSettings(userId, roleList, out _);
            if (!SqlDataHelper.IsDataValid(permList))
            {
                return null;
            }
            Hashtable ht = new Hashtable();
            for (int i = 0; i < permList.Count; i++)
            {
                ht[permList[i].AccessId] = 1;
            }
            return ht;
        }

        public static IList<UserInfo> SearchUserInfo(out Exception exception)
        {
            return DalUserInfo.SearchUserInfo(out exception);
        }

        public static IList<UserInfo> SearchUserInfoLite(out Exception exception)
        {
            return DalUserInfo.SearchUserInfoLite(out exception);
        }

        public static IList<UserInfo> SearchUserInfoWithFp(out Exception exception)
        {
            return DalUserInfo.SearchUserInfoWithFp(out exception);
        }

        public static IList<UserInfo> SearchUserInfo(List<string> id, out Exception exception)
        {
            return DalUserInfo.SearchUser(id, out exception);
        }

        public static IList<UserInfo> SearchUserByDepart(string departId, out Exception exception)
        {
            return DalUserInfo.SearchUserByDepart(departId, out exception);
        }

        public static int GetUserCount(string userName, string realName, string departId, string excludeDepartId,
            string roleId, string excludeRoleId, string dutyId, string excludeDutyId, out Exception exception)
        {
            return DalUserInfo.GetUserCount(userName, realName, departId, excludeDepartId, roleId, excludeRoleId, 
                dutyId, excludeDutyId, out exception);
        }

        public static IList<UserInfo> SearchUser(string userName, string realName, string departId, string excludeDepartId,
            string roleId, string excludeRoleId, string dutyId, string excludeDutyId,
            int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            return DalUserInfo.SearchUser(userName, realName, departId, excludeDepartId, roleId, excludeRoleId, dutyId, excludeDutyId,
                dataStart, dataCount, orderList, out exception);
        }

        public static IList<UserInfo> SearchSubordinate(string funcGroup, UserInfo userInfo, out Exception exception)
        {
            IList<DepartSettings> departSettings = BllDepartSettings.GetUserDepartSettings(userInfo.Id, out exception);
            if (!SqlDataHelper.IsDataValid(departSettings))
            {
                return null;
            }
            IList<PageFunctions> funcList = BllPageFunctions.SearchGroupFunctions(funcGroup, out exception);
            if (!SqlDataHelper.IsDataValid(funcList))
            {
                return null;
            }
            Hashtable groupPermission = new Hashtable();
            for (int i = 0; i < funcList.Count; i++)
            {
                groupPermission[funcList[i].Id] = 1;
            }
            List<string> roleList = new List<string>();
            IList<RoleSettings> roleData = BllRoleSettings.GetUserRoleSettings(userInfo.Id, out exception);
            if (SqlDataHelper.IsDataValid(roleData))
            {
                for (int i = 0; i < roleData.Count; i++)
                {
                    roleList.Add(roleData[i].RoleId);
                }
            }
            IList<PermissionSettings> permList = BllPermissionSettings.GetFullPermissionSettings(userInfo.Id, roleList, out exception);
            if (!SqlDataHelper.IsDataValid(permList))
            {
                return null;
            }
            string userPermission = "";
            for (int i = 0; i < permList.Count; i++)
            {
                if (groupPermission[permList[i].AccessId] != null)
                {
                    userPermission = permList[i].AccessId;
                    break;
                }
            }
            if (string.IsNullOrEmpty(userPermission))
            {
                return null;
            }
            return PermissionControl.SearchSubordinate(funcGroup, userPermission, userInfo, departSettings);
        }

        public static IList<UserInfo> SearchUser(IList<DepartSettings> settingList, out Exception exception)
        {
            List<string> userIds = null;
            if (settingList != null)
            {
                userIds = new List<string>();
                for (int i = 0; i < settingList.Count; i++)
                {
                    userIds.Add(settingList[i].UserId);
                }
            }
            return DalUserInfo.SearchUser(userIds, out exception);
        }

        public static IList<UserInfo> SearchUserWithRole(string roleId, out Exception exception)
        {
            IList<RoleSettings> settingList = BllRoleSettings.SearchRoleSettings(roleId, out exception);
            List<string> userIds = null;
            if (settingList != null)
            {
                userIds = new List<string>();
                for (int i = 0; i < settingList.Count; i++)
                {
                    userIds.Add(settingList[i].UserId);
                }
            }
            return DalUserInfo.SearchUser(userIds, out exception);
        }

        public static IList<UserInfo> SearchUserWithPermission(string permissionId, out Exception exception)
        {
            IList<PermissionSettings> settingList = BllPermissionSettings.SearchPermissionSettings(permissionId, out exception);
            List<string> userIds = new List<string>(), roleIds = new List<string>();
            if (settingList != null)
            {
                for (int i = 0; i < settingList.Count; i++)
                {
                    if (settingList[i].OwnerType == "User")
                    {
                        userIds.Add(settingList[i].OwnerId);
                    }
                    else
                    {
                        roleIds.Add(settingList[i].OwnerId);
                    }
                }
            }
            IList<UserInfo> outputList = new List<UserInfo>();
            IList<UserInfo> basicList = DalUserInfo.SearchUser(userIds, out exception);
            if (SqlDataHelper.IsDataValid(basicList))
            {
                outputList = CopyHelper.MergeList(outputList, basicList);
            }
            for (int i = 0; i < roleIds.Count; i++)
            {
                IList<UserInfo> extList = SearchUserWithRole(roleIds[i], out exception);
                if (SqlDataHelper.IsDataValid(extList))
                {
                    outputList = CopyHelper.MergeList(outputList, extList);
                }
            }
            return outputList;
        }

        public static IList<UserInfo> SearchUserByDepart(List<string> departIds, out Exception exception)
        {
            IList<DepartSettings> departList = BllDepartSettings.SearchDepartSettings(departIds, out exception);
            if (SqlDataHelper.IsDataValid(departList))
            {
                return SearchUser(departList, out exception);
            }
            return null;
        }

        public static UserInfo GetUserInfo(string userId, out Exception exception)
        {
            if (string.IsNullOrEmpty(userId))
            {
                exception = null;
                return null;
            }
            return DalUserInfo.GetUserInfo(userId, out exception);
        }

        public static UserInfo GetUserInfoByUserName(string userName, out Exception exception)
        {
            if (string.IsNullOrEmpty(userName))
            {
                exception = null;
                return null;
            }
            return DalUserInfo.GetUserInfoByUserName(userName, out exception);
        }

        public static UserInfo GetUserInfo(string userName, string userPwd, out Exception exception)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userPwd))
            {
                exception = null;
                return null;
            }
            string pwdHash = Md5Encode.Encode(userPwd, false);
            return DalUserInfo.GetUserInfo(userName, pwdHash, out exception);
        }

        public static UserInfo GetUserInfo(int pagingId, out Exception exception)
        {
            return DalUserInfo.GetUserInfo(pagingId, out exception);
        }

        public static string AddUserInfo(string userName, string password, string realName,
            string userTel, string userSex, DateTime birthDate, DateTime retireDate, string workCardCode,
            string identCardCode, string address, string comment, UserInfo adminInfo, out Exception exception)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                exception = null;
                return null;
            }
            password = Md5Encode.Encode(password, false);
            return DalUserInfo.AddUserInfo(userName, password, realName, userTel, userSex, birthDate, retireDate,
                workCardCode, identCardCode, address, comment, adminInfo, out exception);
        }

        public static int ModifyUserInfo(string userId, string userName, string password, string realName, 
            string userTel, string userSex, DateTime birthDate, DateTime retireDate, string workCardCode,
            string identCardCode, string address, string comment, UserInfo adminInfo, out Exception exception)
        {
            if (string.IsNullOrEmpty(userName))
            {
                exception = null;
                return -100;
            }
            if (!string.IsNullOrEmpty(password)) password = Md5Encode.Encode(password, false);
            return DalUserInfo.ModifyUserInfo(userId, userName, password, realName, userTel,
                userSex, birthDate, retireDate,
                workCardCode, identCardCode, address, comment, adminInfo, out exception);
        }

        public static int ModifyUserInfo(string userId, string userPwd, string userTel,
            string operateUser, string operateUserName, out Exception exception)
        {
            if (!string.IsNullOrEmpty(userPwd))
            {
                userPwd = Md5Encode.Encode(userPwd, false);
            }
            return DalUserInfo.ModifyUserInfo(userId, userPwd, userTel, operateUser, operateUserName, out exception);
        }

        public static int UpdateUserInfo(UserInfo userInfo, out Exception exception)
        {
            return DalUserInfo.UpdateUserInfo(userInfo, out exception);
        }

        public static int DeleteUserInfo(string userId, string operateUser, string operateUserName, out Exception exception)
        {
            if (string.IsNullOrEmpty(userId))
            {
                exception = null;
                return -100;
            }
            //清除用户角色配置(非重要)
            DalRoleSettings.DeleteUserRoleSettings(userId, out exception);
            //清除用户权限配置(非重要)
            DalPermissionSettings.DeleteOwnerPermissionSettings(userId, out exception);
            //清除用户部门配置(非重要)
            DalDepartSettings.DeleteUserDepartSettings(userId, out exception);
            //删除用户
            return DalUserInfo.DeleteUserInfo(userId, operateUser, operateUserName, out exception);
        }
    }
}
