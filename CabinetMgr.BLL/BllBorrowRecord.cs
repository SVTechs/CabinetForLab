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
    public class BllBorrowRecord
    {
        public static IList<BorrowRecord> SearchBorrowRecord(DateTime startDate, DateTime endDate, string toolName, int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            return DalBorrowRecord.SearchBorrowRecord(startDate, endDate, toolName, dataStart, dataCount, orderList, out exception);
        }

        public static int GetBorrowRecordCount(out Exception exception)
        {
            return DalBorrowRecord.GetBorrowRecordCount(out exception);
        }

        public static BorrowRecord GetBorrowRecord(string id, out Exception exception)
        {
            return DalBorrowRecord.GetBorrowRecord(id, out exception);
        }

        public static BorrowRecord GetBorrowRecord(string entityName, object entityValue, out Exception exception)
        {
            return DalBorrowRecord.GetBorrowRecord(entityName, entityValue, out exception);
        }

        public static int AddBorrowRecord(string toolId, string toolName, string toolPosition, string workerId, string workerName, DateTime eventTime, int status, DateTime returnTime, out Exception exception)
        {
            return DalBorrowRecord.AddBorrowRecord(toolId, toolName, toolPosition, workerId, workerName, eventTime, status, returnTime, out exception);
        }

        public static int ModifyBorrowRecord(string id, string toolId, string toolName, string toolPosition, string workerId, string workerName, DateTime eventTime, int status, DateTime returnTime, out Exception exception)
        {
            return DalBorrowRecord.ModifyBorrowRecord(id, toolId, toolName, toolPosition, workerId, workerName, eventTime, status, returnTime, out exception);
        }

        public static int SaveBorrowRecord(BorrowRecord borrowRecord, out Exception exception)
        {
            return DalBorrowRecord.SaveBorrowRecord(borrowRecord, out exception);
        }

        public static int UpdateBorrowRecord(BorrowRecord borrowRecord, out Exception exception)
        {
            return DalBorrowRecord.UpdateBorrowRecord(borrowRecord, out exception);
        }

        public static int DeleteBorrowRecord(string id, out Exception exception)
        {
            return DalBorrowRecord.DeleteBorrowRecord(id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return DalBorrowRecord.ExecSqlQuery(queryCmd, paraList, out exception);
        }

        public static int DeleteAll(out Exception exception)
        {
            return DalBorrowRecord.DeleteAll(out exception);
        }

        public static int AddBorrowRecord(ToolInfo toolInfo, UserInfo ui, out Exception exception, int status = 0, int toolCount = 0)
        {
            return DalBorrowRecord.AddBorrowRecord(toolInfo, ui, status, toolCount, out exception);
        }
    }
}
