﻿using CabinetMgr.DAL;
using Domain.Main.Domain;
using Domain.Main.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Encryption;

namespace CabinetMgr.BLL
{
    public class BllUserInfo
    {
        public static IList<UserInfo> SearchUserInfo(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            return DalUserInfo.SearchUserInfo(dataStart, dataCount, orderList, out exception);
        }

        public static int GetUserInfoCount(out Exception exception)
        {
            return DalUserInfo.GetUserInfoCount(out exception);
        }

        public static UserInfo GetUserInfo(string iD, out Exception exception)
        {
            return DalUserInfo.GetUserInfo(iD, out exception);
        }

        public static UserInfo GetUserInfo(string entityName, object entityValue, out Exception exception)
        {
            return DalUserInfo.GetUserInfo(entityName, entityValue, out exception);
        }

        public static int SaveUserInfo(UserInfo userInfo, out Exception exception)
        {
            return DalUserInfo.SaveUserInfo(userInfo, out exception);
        }

        public static int UpdateUserInfo(UserInfo userInfo, out Exception exception)
        {
            return DalUserInfo.UpdateUserInfo(userInfo, out exception);
        }

        public static int DeleteUserInfo(string iD, out Exception exception)
        {
            return DalUserInfo.DeleteUserInfo(iD, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return DalUserInfo.ExecSqlQuery(queryCmd, paraList, out exception);
        }

        public static UserInfo GetUserInfoByUserName(string userName, out Exception exception)
        {
            return DalUserInfo.GetUserInfoByUserName(userName, out exception);
        }

        public static UserInfo GetUserInfoByTemplate(long templateId, out Exception exception)
        {
            return DalUserInfo.GetUserInfoByTemplate(templateId, out exception);
        }

        public static int DeleteAll(out Exception exception)
        {
            return DalUserInfo.DeleteAll(out exception);
        }

        public static UserInfo Login(string userName, string userPwd, out Exception exception)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userPwd))
            {
                exception = null;
                return null;
            }
            string pwdHash = Md5Encode.Encode(userPwd, false);
            return DalUserInfo.Login(userName, pwdHash, out exception);
        }
    }
}
