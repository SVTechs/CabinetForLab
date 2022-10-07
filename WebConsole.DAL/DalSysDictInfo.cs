using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using NHibernate.Criterion;
using WebConsole.DAL.NhUtils;
using Domain.Server.Domain;
using NLog;
using Utilities.Data;

namespace WebConsole.DAL
{
    public class DalSysDictInfo : FlexNhBase<SysDictInfo>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<SysDictInfo> SearchSysDictInfo(string dataGroup, int dataStart, int dataCount, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>();
            if (!string.IsNullOrEmpty(dataGroup))
            {
                critList.Add(Restrictions.Eq("DataGroup", dataGroup));
            }
            List<Order> orderList = new List<Order>
            {
                Order.Asc("DataKey"),
                Order.Asc("DataSubKey"),
                Order.Asc("DataOrder")
            };
            return SearchItem(critList, orderList, dataStart, dataCount, out exception);
        }

        public static IList<SysDictInfo> SearchSysDictInfoByKey(string dataGroup, string dataKey, string dataSubKey, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("DataGroup", dataGroup)
            };
            if (!string.IsNullOrEmpty(dataKey))
            {
                critList.Add(Restrictions.Eq("DataKey", dataKey));
            }
            if (!string.IsNullOrEmpty(dataSubKey))
            {
                critList.Add(Restrictions.Eq("DataSubKey", dataSubKey));
            }
            List<Order> orderList = new List<Order>
            {
                Order.Asc("DataOrder")
            };
            return SearchItem(critList, orderList, 0, -1, out exception);
        }

        public static int GetSysDictInfoCount(string dataGroup, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>();
            if (!string.IsNullOrEmpty(dataGroup))
            {
                critList.Add(Restrictions.Eq("DataGroup", dataGroup));
            }
            return GetItemCount(critList, out exception);
        }

        public static SysDictInfo GetSysDictInfo(long id, out Exception exception)
        {
            return GetItemInfo("Id", id, out exception);
        }

        public static SysDictInfo GetSysDictInfo(string entityName, object entityValue, out Exception exception)
        {
            return GetItemInfo(entityName, entityValue, out exception);
        }

        public static int AddSysDictInfo(string dataGroup, string dataKey, string dataSubKey, string dataId,
            int dataOrder, string dataValue1, string dataValue2, string dataValue3, string dataValue4, string dataValue5, string dataValue6,
            string comment, UserInfo adminInfo, out Exception exception)
        {
            List<TaskInfo> taskList = new List<TaskInfo>();
            if (string.IsNullOrEmpty(dataId)) dataId = Guid.NewGuid().ToString().ToUpper();
            SysDictInfo itemRecord = new SysDictInfo
            {
                DataGroup = dataGroup,
                DataKey = dataKey,
                DataSubKey = dataSubKey,
                DataId = dataId,
                DataOrder = dataOrder,
                DataValue1 = dataValue1,
                DataValue2 = dataValue2,
                DataValue3 = dataValue3,
                DataValue4 = dataValue4,
                DataValue5 = dataValue5,
                DataValue6 = dataValue6,
                Comment = comment,
            };
            taskList.Add(new TaskInfo(OperationType.Add, itemRecord));
            if (adminInfo != null)
            {
                SysDataHistory historyRecord = DalSysDataHistory.GenerateAddEntity(itemRecord,
                    "系统字典", adminInfo.Id, adminInfo.RealName);
                taskList.Add(new TaskInfo(OperationType.Add, historyRecord));
            }
            return ExecBatchTask(taskList, out exception);
        }

        public static int ModifySysDictInfo(long id, string dataKey, string dataSubKey, string dataId, int dataOrder,
            string dataValue1, string dataValue2, string dataValue3, string dataValue4, string dataValue5, string dataValue6,
            string comment, UserInfo adminInfo, out Exception exception)
        {
            List<TaskInfo> taskList = new List<TaskInfo>();
            SysDictInfo itemRecord = GetSysDictInfo(id, out exception);
            if (itemRecord == null) return 0;
            var originRecord = itemRecord.DeepClone();
            itemRecord.DataKey = dataKey;
            itemRecord.DataSubKey = dataSubKey;
            if (!string.IsNullOrEmpty(dataId)) itemRecord.DataId = dataId;
            itemRecord.DataOrder = dataOrder;
            itemRecord.DataValue1 = dataValue1;
            itemRecord.DataValue2 = dataValue2;
            itemRecord.DataValue3 = dataValue3;
            itemRecord.DataValue4 = dataValue4;
            itemRecord.DataValue5 = dataValue5;
            itemRecord.DataValue6 = dataValue6;
            itemRecord.Comment = comment;
            taskList.Add(new TaskInfo(OperationType.Update, itemRecord));
            if (adminInfo != null)
            {
                SysDataHistory historyRecord = DalSysDataHistory.GenerateEditEntity(originRecord,
                itemRecord, "系统字典", adminInfo.Id, adminInfo.RealName);
                taskList.Add(new TaskInfo(OperationType.Add, historyRecord));
            }
            return ExecBatchTask(taskList, out exception);
        }

        public static int SaveSysDictInfo(SysDictInfo sysDictInfo, out Exception exception)
        {
            return SaveItem(sysDictInfo, out exception);
        }

        public static int UpdateSysDictInfo(SysDictInfo sysDictInfo, out Exception exception)
        {
            return UpdateItem(sysDictInfo, out exception);
        }

        public static int DeleteSysDictInfo(long id, UserInfo adminInfo, out Exception exception)
        {
            List<TaskInfo> taskList = new List<TaskInfo>();
            SysDictInfo itemRecord = GetSysDictInfo(id, out exception);
            taskList.Add(new TaskInfo(OperationType.Delete, itemRecord));
            if (adminInfo != null)
            {
                SysDataHistory historyRecord = DalSysDataHistory.GenerateDelEntity(itemRecord,
                    "系统字典", adminInfo.Id, adminInfo.RealName);
                taskList.Add(new TaskInfo(OperationType.Add, historyRecord));
            }
            return ExecBatchTask(taskList, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return ExecQuery(queryCmd, paraList, out exception);
        }
    }
}
