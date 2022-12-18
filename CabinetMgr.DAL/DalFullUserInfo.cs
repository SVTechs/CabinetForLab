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
    public class DalFullUserInfo : FlexNhBase<FullUserInfo>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<FullUserInfo> SearchFullUserInfo(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            List<Order> requestedOrder = DbOrder.ToOrderList(orderList);
            return SearchItem(criterionList, requestedOrder, dataStart, dataCount, out exception);
        }

        public static int SaveFullUserInfo(FullUserInfo userInfo, out Exception exception)
        {
            return SaveItem(userInfo, out exception);
        }

        public static int UpdateFullUserInfo(FullUserInfo userInfo, out Exception exception)
        {
            return UpdateItem(userInfo, out exception);
        }

        public static int DeleteUserInfo(string iD, out Exception exception)
        {
            return DeleteItem("ID", iD, out exception);
        }

        public static FullUserInfo GetFullUserInfoByUserName(string userName, out Exception exception)
        {
            return GetItemInfo("UserName", userName, out exception);
        }

        public static FullUserInfo GetFullUserInfo(string iD, out Exception exception)
        {
            return GetItemInfo("ID", iD, out exception);
        }

    }
}
