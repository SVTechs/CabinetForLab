using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using NHibernate;
using NHibernate.Criterion;
using WebConsole.DAL.NhUtils;
using Domain.Server.Domain;
using Utilities.DbHelper;
using NLog;

namespace WebConsole.DAL
{
    public class DalRuntimeInfo : FlexNhBase<RuntimeInfo>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<RuntimeInfo> SearchRuntimeInfo(int dataStart, int dataCount, out Exception exception)
        {
            return SearchItem(null, null, dataStart, dataCount, out exception);
        }

        public static int GetRuntimeInfoCount(out Exception exception)
        {
            return GetItemCount(null, out exception);
        }

        public static RuntimeInfo GetRuntimeInfo(int id, out Exception exception)
        {
            return GetItemInfo("Id", id, out exception);
        }

        public static RuntimeInfo GetRuntimeInfo(string keyName, out Exception exception)
        {
            return GetItemInfo("KeyName", keyName, out exception);
        }

        public static int AddRuntimeInfo(string keyName, string keyValue1, string keyValue2, out Exception exception)
        {
            RuntimeInfo itemRecord = new RuntimeInfo {
                KeyName = keyName,
                KeyValue1 = keyValue1,
                KeyValue2 = keyValue2,
            };
            return SaveItem(itemRecord, out exception);
        }

        public static int ModifyRuntimeInfo(string keyName, string keyValue1, string keyValue2, out Exception exception)
        {
            RuntimeInfo itemRecord = GetRuntimeInfo(keyName, out exception);
            if (itemRecord == null) return 0;
            itemRecord.KeyName = keyName;
            itemRecord.KeyValue1 = keyValue1;
            itemRecord.KeyValue2 = keyValue2;
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
