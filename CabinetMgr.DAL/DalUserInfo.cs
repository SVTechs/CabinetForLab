using CabinetMgr.DAL.NhUtils;
using Domain.Main.Domain;
using Domain.Main.Types;
using NHibernate.Criterion;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetMgr.DAL
{
    public class DalUserInfo : FlexNhBase<UserInfo>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<UserInfo> SearchUserInfo(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            List<Order> requestedOrder = DbOrder.ToOrderList(orderList);
            return SearchItem(criterionList, requestedOrder, dataStart, dataCount, out exception);
        }

        public static int GetUserInfoCount(out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            return GetItemCount(criterionList, out exception);
        }

        public static UserInfo GetUserInfo(string iD, out Exception exception)
        {
            return GetItemInfo("ID", iD, out exception);
        }

        public static UserInfo GetUserInfo(string entityName, object entityValue, out Exception exception)
        {
            return GetItemInfo(entityName, entityValue, out exception);
        }

        public static int SaveUserInfo(UserInfo userInfo, out Exception exception)
        {
            return SaveItem(userInfo, out exception);
        }

        public static int UpdateUserInfo(UserInfo userInfo, out Exception exception)
        {
            return UpdateItem(userInfo, out exception);
        }

        public static int DeleteUserInfo(string iD, out Exception exception)
        {
            return DeleteItem("ID", iD, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return ExecQuery(queryCmd, paraList, out exception);
        }

        public static UserInfo GetUserInfoByUserName(string userName, out Exception exception)
        {
            return GetItemInfo("UserName", userName, out exception);
        }
    }
}
