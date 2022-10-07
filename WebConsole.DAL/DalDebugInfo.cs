using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Domain.Server.Domain;
using NLog;
using WebConsole.DAL.NhUtils;

namespace WebConsole.DAL
{
    public class DalDebugInfo : FlexNhBase<DebugInfo>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<DebugInfo> SearchDebugInfo(int dataStart, int dataCount, out Exception exception)
        {
            return SearchItem(null, null, dataStart, dataCount, out exception);
        }

        public static int GetDebugInfoCount(out Exception exception)
        {
            return GetItemCount(null, out exception);
        }

        public static DebugInfo GetDebugInfo(string id, out Exception exception)
        {
            return GetItemInfo("Id", id, out exception);
        }

        public static DebugInfo GetDebugInfo(string entityName, object entityValue, out Exception exception)
        {
            return GetItemInfo(entityName, entityValue, out exception);
        }

        public static int AddDebugInfo(int test1, string test2, DateTime test3, string z1, string z2, string z3, string z4, string z5, string z6, string z7, string z8, string z9, out Exception exception)
        {
            DebugInfo itemRecord = new DebugInfo {
                Id = Guid.NewGuid().ToString().ToUpper(),
                Test1 = test1,
                Test2 = test2,
                Test3 = test3,
                Z1 = z1,
                Z2 = z2,
                Z3 = z3,
                Z4 = z4,
                Z5 = z5,
                Z6 = z6,
                Z7 = z7,
                Z8 = z8,
                Z9 = z9,
            };
            return SaveItem(itemRecord, out exception);
        }

        public static int ModifyDebugInfo(string id, int test1, string test2, DateTime test3, string z1, string z2, string z3, string z4, string z5, string z6, string z7, string z8, string z9, out Exception exception)
        {
            DebugInfo itemRecord = GetDebugInfo(id, out exception);
            if (itemRecord == null) return 0;
            itemRecord.Test1 = test1;
            itemRecord.Test2 = test2;
            itemRecord.Test3 = test3;
            itemRecord.Z1 = z1;
            itemRecord.Z2 = z2;
            itemRecord.Z3 = z3;
            itemRecord.Z4 = z4;
            itemRecord.Z5 = z5;
            itemRecord.Z6 = z6;
            itemRecord.Z7 = z7;
            itemRecord.Z8 = z8;
            itemRecord.Z9 = z9;
            return UpdateItem(itemRecord, out exception);
        }

        public static int SaveDebugInfo(DebugInfo debugInfo, out Exception exception)
        {
            return SaveItem(debugInfo, out exception);
        }

        public static int UpdateDebugInfo(DebugInfo debugInfo, out Exception exception)
        {
            return UpdateItem(debugInfo, out exception);
        }

        public static int DeleteDebugInfo(string id, out Exception exception)
        {
            return DeleteItem("Id", id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return ExecQuery(queryCmd, paraList, out exception);
        }
    }
}
