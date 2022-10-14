using CabinetMgr.DAL;
using Domain.Main.Domain;
using Domain.Main.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
