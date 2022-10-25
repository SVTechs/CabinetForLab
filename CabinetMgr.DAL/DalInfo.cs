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
    public class DalInfo : FlexNhBase<Info>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<Info> SearchInfo(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            List<Order> requestedOrder;
            if (orderList != null) requestedOrder = DbOrder.ToOrderList(orderList);
            else requestedOrder = new List<Order>() { new Order("IsTop", false), new Order("CreateTime", false) };
            return SearchItem(criterionList, requestedOrder, dataStart, dataCount, out exception);
        }

        public static int GetInfoCount(out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            return GetItemCount(criterionList, out exception);
        }

        public static Info GetInfo(string id, out Exception exception)
        {
            return GetItemInfo("Id", id, out exception);
        }

        public static Info GetInfo(string entityName, object entityValue, out Exception exception)
        {
            return GetItemInfo(entityName, entityValue, out exception);
        }

        public static int AddInfo(string infoContent, int infoType, int isTop, DateTime createTime, out Exception exception)
        {
            Info itemRecord = new Info
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                InfoContent = infoContent,
                InfoType = infoType,
                IsTop = isTop,
                CreateTime = createTime,
            };
            return SaveItem(itemRecord, out exception);
        }

        public static int ModifyInfo(string id, string infoContent, int infoType, int isTop, DateTime createTime, out Exception exception)
        {
            Info itemRecord = GetInfo(id, out exception);
            if (itemRecord == null) return 0;
            itemRecord.InfoContent = infoContent;
            itemRecord.InfoType = infoType;
            itemRecord.IsTop = isTop;
            itemRecord.CreateTime = createTime;
            return UpdateItem(itemRecord, out exception);
        }

        public static int SaveInfo(Info info, out Exception exception)
        {
            return SaveItem(info, out exception);
        }

        public static int UpdateInfo(Info info, out Exception exception)
        {
            return UpdateItem(info, out exception);
        }

        public static int DeleteInfo(string id, out Exception exception)
        {
            return DeleteItem("Id", id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return ExecQuery(queryCmd, paraList, out exception);
        }
    }
}
