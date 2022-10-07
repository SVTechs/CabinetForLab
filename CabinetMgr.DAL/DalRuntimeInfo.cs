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
    public class DalRuntimeInfo : FlexNhBase<RuntimeInfo>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<RuntimeInfo> SearchRuntimeInfo(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            List<Order> requestedOrder = DbOrder.ToOrderList(orderList);
            return SearchItem(criterionList, requestedOrder, dataStart, dataCount, out exception);
        }

        public static int GetRuntimeInfoCount(out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            return GetItemCount(criterionList, out exception);
        }

        public static RuntimeInfo GetRuntimeInfo(int id, out Exception exception)
        {
            return GetItemInfo("Id", id, out exception);
        }

        public static RuntimeInfo GetRuntimeInfo(string entityName, object entityValue, out Exception exception)
        {
            return GetItemInfo(entityName, entityValue, out exception);
        }

        public static int AddRuntimeInfo(string keyName, string keyValue1, string keyValue2, string keyValue3, string keyValue4, out Exception exception)
        {
            RuntimeInfo itemRecord = new RuntimeInfo
            {
                KeyName = keyName,
                KeyValue1 = keyValue1,
                KeyValue2 = keyValue2,
                KeyValue3 = keyValue3,
                KeyValue4 = keyValue4,
            };
            return SaveItem(itemRecord, out exception);
        }

        public static int ModifyRuntimeInfo(int id, string keyName, string keyValue1, string keyValue2, string keyValue3, string keyValue4, out Exception exception)
        {
            RuntimeInfo itemRecord = GetRuntimeInfo(id, out exception);
            if (itemRecord == null) return 0;
            itemRecord.KeyName = keyName;
            itemRecord.KeyValue1 = keyValue1;
            itemRecord.KeyValue2 = keyValue2;
            itemRecord.KeyValue3 = keyValue3;
            itemRecord.KeyValue4 = keyValue4;
            return UpdateItem(itemRecord, out exception);
        }

        public static int SaveRuntimeInfo(RuntimeInfo runtimeInfo, out Exception exception)
        {
            return SaveItem(runtimeInfo, out exception);
        }

        public static int UpdateRuntimeInfo(RuntimeInfo runtimeInfo, out Exception exception)
        {
            return UpdateItem(runtimeInfo, out exception);
        }

        public static int DeleteRuntimeInfo(int id, out Exception exception)
        {
            return DeleteItem("Id", id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return ExecQuery(queryCmd, paraList, out exception);
        }
    }
}
