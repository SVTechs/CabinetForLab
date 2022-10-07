using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WebConsole.DAL;
using Domain.Server.Domain;

namespace WebConsole.BLL
{
    public class BllSysDataHistory
    {
        public static IList<SysDataHistory> SearchSysDataHistory(string userName, int dataStart, int dataCount, out Exception exception)
        {
            return DalSysDataHistory.SearchSysDataHistory(userName, dataStart, dataCount, out exception);
        }

        public static int GetSysDataHistoryCount(string userName, out Exception exception)
        {
            return DalSysDataHistory.GetSysDataHistoryCount(userName, out exception);
        }

        public static SysDataHistory GetSysDataHistory(long id, out Exception exception)
        {
            return DalSysDataHistory.GetSysDataHistory(id, out exception);
        }

        public static SysDataHistory GetSysDataHistory(string entityName, object entityValue, out Exception exception)
        {
            return DalSysDataHistory.GetSysDataHistory(entityName, entityValue, out exception);
        }

        public static int SaveSysDataHistory(SysDataHistory sysDataHistory, out Exception exception)
        {
            return DalSysDataHistory.SaveSysDataHistory(sysDataHistory, out exception);
        }

        public static int UpdateSysDataHistory(SysDataHistory sysDataHistory, out Exception exception)
        {
            return DalSysDataHistory.UpdateSysDataHistory(sysDataHistory, out exception);
        }

        public static int DeleteSysDataHistory(long id, out Exception exception)
        {
            return DalSysDataHistory.DeleteSysDataHistory(id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return DalSysDataHistory.ExecSqlQuery(queryCmd, paraList, out exception);
        }
    }
}
