using CabinetMgr.Config;
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
    public class DalBorrowRecord : FlexNhBase<BorrowRecord>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<BorrowRecord> SearchBorrowRecord(DateTime startDate, DateTime endDate,  int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            criterionList.Add(Restrictions.Ge("EventTime", startDate));
            criterionList.Add(Restrictions.Le("EventTime", endDate));
            //Criterion Processing
            List<Order> requestedOrder;
            if(orderList == null)
            {
                requestedOrder = new List<Order>() { new Order("EventTime", false) };
            }
            else
            {
                requestedOrder = DbOrder.ToOrderList(orderList); ;
            }
            
            return SearchItem(criterionList, requestedOrder, dataStart, dataCount, out exception);
        }

        public static int GetBorrowRecordCount(out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            return GetItemCount(criterionList, out exception);
        }

        public static BorrowRecord GetBorrowRecord(string id, out Exception exception)
        {
            return GetItemInfo("Id", id, out exception);
        }

        public static BorrowRecord GetBorrowRecord(string entityName, object entityValue, out Exception exception)
        {
            return GetItemInfo(entityName, entityValue, out exception);
        }

        public static int AddBorrowRecord(string toolId, string toolName, string toolPosition, string workerId, string workerName, DateTime eventTime, int status, DateTime returnTime, out Exception exception)
        {
            BorrowRecord itemRecord = new BorrowRecord
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                ToolId = toolId,
                ToolName = toolName,
                ToolPosition = toolPosition,
                WorkerId = workerId,
                WorkerName = workerName,
                EventTime = eventTime,
                Status = status,
                ReturnTime = returnTime,
            };
            return SaveItem(itemRecord, out exception);
        }

        public static int ModifyBorrowRecord(string id, string toolId, string toolName, string toolPosition, string workerId, string workerName, DateTime eventTime, int status, DateTime returnTime, out Exception exception)
        {
            BorrowRecord itemRecord = GetBorrowRecord(id, out exception);
            if (itemRecord == null) return 0;
            itemRecord.ToolId = toolId;
            itemRecord.ToolName = toolName;
            itemRecord.ToolPosition = toolPosition;
            itemRecord.WorkerId = workerId;
            itemRecord.WorkerName = workerName;
            itemRecord.EventTime = eventTime;
            itemRecord.Status = status;
            itemRecord.ReturnTime = returnTime;
            return UpdateItem(itemRecord, out exception);
        }

        public static int SaveBorrowRecord(BorrowRecord borrowRecord, out Exception exception)
        {
            return SaveItem(borrowRecord, out exception);
        }

        public static int UpdateBorrowRecord(BorrowRecord borrowRecord, out Exception exception)
        {
            return UpdateItem(borrowRecord, out exception);
        }

        public static int DeleteBorrowRecord(string id, out Exception exception)
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

        public static int AddBorrowRecord(ToolInfo toolInfo, UserInfo ui, out Exception exception)
        {
            IList<TaskInfo> taskList = new List<TaskInfo>();

            BorrowRecord itemRecord = new BorrowRecord
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                ToolId = toolInfo.Id,
                ToolName = toolInfo.ToolName,
                ToolPosition = toolInfo.LatticePosition,
                WorkerId = ui.ID,
                WorkerName = ui.FullName,
                EventTime = DateTime.Now,
                Status = 0,
                ReturnTime = Env.MinTime,
            };
            taskList.Add(new TaskInfo(OperationType.Add, itemRecord));
            toolInfo.CurrentCount -= 1;
            taskList.Add(new TaskInfo(OperationType.Update, toolInfo));
            return ExecBatchTask(taskList, out exception);
        }


    }
}