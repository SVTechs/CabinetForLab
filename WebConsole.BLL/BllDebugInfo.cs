using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Domain.Server.Domain;
using WebConsole.DAL;

namespace WebConsole.BLL
{
    public class BllDebugInfo
    {
        public static IList<DebugInfo> SearchDebugInfo(int dataStart, int dataCount, out Exception exception)
        {
            return DalDebugInfo.SearchDebugInfo(dataStart, dataCount, out exception);
        }

        public static int GetDebugInfoCount(out Exception exception)
        {
            return DalDebugInfo.GetDebugInfoCount(out exception);
        }

        public static DebugInfo GetDebugInfo(string id, out Exception exception)
        {
            return DalDebugInfo.GetDebugInfo(id, out exception);
        }

        public static DebugInfo GetDebugInfo(string entityName, object entityValue, out Exception exception)
        {
            return DalDebugInfo.GetDebugInfo(entityName, entityValue, out exception);
        }

        public static int AddDebugInfo(int test1, string test2, DateTime test3, string z1, string z2, string z3, string z4, string z5, string z6, string z7, string z8, string z9, out Exception exception)
        {
            return DalDebugInfo.AddDebugInfo(test1, test2, test3, z1, z2, z3, z4, z5, z6, z7, z8, z9, out exception);
        }

        public static int ModifyDebugInfo(string id, int test1, string test2, DateTime test3, string z1, string z2, string z3, string z4, string z5, string z6, string z7, string z8, string z9, out Exception exception)
        {
            return DalDebugInfo.ModifyDebugInfo(id, test1, test2, test3, z1, z2, z3, z4, z5, z6, z7, z8, z9, out exception);
        }

        public static int SaveDebugInfo(DebugInfo debugInfo, out Exception exception)
        {
            return DalDebugInfo.SaveDebugInfo(debugInfo, out exception);
        }

        public static int UpdateDebugInfo(DebugInfo debugInfo, out Exception exception)
        {
            return DalDebugInfo.UpdateDebugInfo(debugInfo, out exception);
        }

        public static int DeleteDebugInfo(string id, out Exception exception)
        {
            return DalDebugInfo.DeleteDebugInfo(id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return DalDebugInfo.ExecSqlQuery(queryCmd, paraList, out exception);
        }
    }
}
