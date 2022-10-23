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
    public class BllReturnRecord
    {
        public static IList<ReturnRecord> SearchReturnRecord(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            return DalReturnRecord.SearchReturnRecord(dataStart, dataCount, orderList, out exception);
        }

        public static int GetReturnRecordCount(out Exception exception)
        {
            return DalReturnRecord.GetReturnRecordCount(out exception);
        }

        public static ReturnRecord GetReturnRecord(string id, out Exception exception)
        {
            return DalReturnRecord.GetReturnRecord(id, out exception);
        }

        public static ReturnRecord GetReturnRecord(string entityName, object entityValue, out Exception exception)
        {
            return DalReturnRecord.GetReturnRecord(entityName, entityValue, out exception);
        }

        public static int AddReturnRecord(string borrowRecord, string workerId, string workerName, DateTime eventTime, out Exception exception)
        {
            return DalReturnRecord.AddReturnRecord(borrowRecord, workerId, workerName, eventTime, out exception);
        }

        public static int ModifyReturnRecord(string id, string borrowRecord, string workerId, string workerName, DateTime eventTime, out Exception exception)
        {
            return DalReturnRecord.ModifyReturnRecord(id, borrowRecord, workerId, workerName, eventTime, out exception);
        }

        public static int SaveReturnRecord(ReturnRecord returnRecord, out Exception exception)
        {
            return DalReturnRecord.SaveReturnRecord(returnRecord, out exception);
        }

        public static int UpdateReturnRecord(ReturnRecord returnRecord, out Exception exception)
        {
            return DalReturnRecord.UpdateReturnRecord(returnRecord, out exception);
        }

        public static int DeleteReturnRecord(string id, out Exception exception)
        {
            return DalReturnRecord.DeleteReturnRecord(id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return DalReturnRecord.ExecSqlQuery(queryCmd, paraList, out exception);
        }

        public static int DeleteAll(out Exception exception)
        {
            return DalReturnRecord.DeleteAll(out exception);
        }

        public static int AddReturnRecord(ToolInfo toolInfo, UserInfo ui, out Exception exception)
        {
            return DalReturnRecord.AddReturnRecord(toolInfo, ui, out exception);
        }
    }
}
