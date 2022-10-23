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
    public class DalReturnRecord : FlexNhBase<ReturnRecord>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<ReturnRecord> SearchReturnRecord(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            List<Order> requestedOrder = DbOrder.ToOrderList(orderList);
            return SearchItem(criterionList, requestedOrder, dataStart, dataCount, out exception);
        }

        public static int GetReturnRecordCount(out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            return GetItemCount(criterionList, out exception);
        }

        public static ReturnRecord GetReturnRecord(string id, out Exception exception)
        {
            return GetItemInfo("Id", id, out exception);
        }

        public static ReturnRecord GetReturnRecord(string entityName, object entityValue, out Exception exception)
        {
            return GetItemInfo(entityName, entityValue, out exception);
        }

        public static int AddReturnRecord(string borrowRecord, string workerId, string workerName, DateTime eventTime, out Exception exception)
        {
            ReturnRecord itemRecord = new ReturnRecord
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                BorrowRecord = borrowRecord,
                WorkerId = workerId,
                WorkerName = workerName,
                EventTime = eventTime,
            };
            return SaveItem(itemRecord, out exception);
        }

        public static int ModifyReturnRecord(string id, string borrowRecord, string workerId, string workerName, DateTime eventTime, out Exception exception)
        {
            ReturnRecord itemRecord = GetReturnRecord(id, out exception);
            if (itemRecord == null) return 0;
            itemRecord.BorrowRecord = borrowRecord;
            itemRecord.WorkerId = workerId;
            itemRecord.WorkerName = workerName;
            itemRecord.EventTime = eventTime;
            return UpdateItem(itemRecord, out exception);
        }

        public static int SaveReturnRecord(ReturnRecord returnRecord, out Exception exception)
        {
            return SaveItem(returnRecord, out exception);
        }

        public static int UpdateReturnRecord(ReturnRecord returnRecord, out Exception exception)
        {
            return UpdateItem(returnRecord, out exception);
        }

        public static int DeleteReturnRecord(string id, out Exception exception)
        {
            return DeleteItem("Id", id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return ExecQuery(queryCmd, paraList, out exception);
        }

        public static int DeleteAll(out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            criterionList.Add(Restrictions.Not(Restrictions.Eq("Id", null)));
            return DeleteItem(criterionList, out exception);
        }

        public static int AddReturnRecord(ToolInfo toolInfo, UserInfo ui, out Exception exception)
        {
            IList<TaskInfo> taskList = new List<TaskInfo>();
            BorrowRecord borrowRecord = DalBorrowRecord.GetBorrowRecord("ToolId", toolInfo.Id, out exception);
            if (borrowRecord == null) return -1;
            ReturnRecord itemRecord = new ReturnRecord
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                BorrowRecord = borrowRecord.Id,
                WorkerId = ui.ID,
                WorkerName = ui.FullName,
                EventTime = DateTime.Now
            };
            taskList.Add(new TaskInfo(OperationType.Add, itemRecord));
            borrowRecord.ReturnTime = DateTime.Now;
            borrowRecord.Status = 10;
            taskList.Add(new TaskInfo(OperationType.Update, borrowRecord));
            toolInfo.CurrentCount += 1;
            taskList.Add(new TaskInfo(OperationType.Update, toolInfo));
            return ExecBatchTask(taskList, out exception);
        }
    }
}
