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

        public static UserInfo GetUserInfoByTemplate(long templateId, out Exception exception)
        {
            return GetItemInfo("TemplateId", templateId, out exception);
        }

        public static int DeleteAll(out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            criterionList.Add(Restrictions.Not(Restrictions.Eq("IsProtected", 1)));
            return DeleteItem(criterionList, out exception);
        }

        public static UserInfo Login(string userName, string userPwd, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("UserName", userName),
                Restrictions.Eq("Password", userPwd)
            };
            UserInfo userInfo = GetItemInfo<UserInfo>(critList, out exception);
            return userInfo;
        }

        public static UserInfo GetUserInfoByCardNum(string cardNum, out Exception exception)
        {
            return GetItemInfo("CardNum", cardNum, out exception);
        }
    }
}
