using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WebConsole.DAL;
using Domain.Server.Domain;

namespace WebConsole.BLL
{
    public class BllRuntimeInfo
    {
        public static int SetRuntimeInfo(string key, string value, out Exception exception)
        {
            var existInfo = GetRuntimeInfo(key, out exception);
            if (exception != null) return -100;
            if (existInfo != null)
            {
                existInfo.KeyValue1 = value;
                return UpdateRuntimeInfo(existInfo, out exception);
            }
            else
            {
                existInfo = new RuntimeInfo();
                existInfo.KeyName = key;
                existInfo.KeyValue1 = value;
                return SaveRuntimeInfo(existInfo, out exception);
            }
        }

        public static IList<RuntimeInfo> SearchRuntimeInfo(int dataStart, int dataCount, out Exception exception)
        {
            return DalRuntimeInfo.SearchRuntimeInfo(dataStart, dataCount, out exception);
        }

        public static int GetRuntimeInfoCount(out Exception exception)
        {
            return DalRuntimeInfo.GetRuntimeInfoCount(out exception);
        }

        public static RuntimeInfo GetRuntimeInfo(int id, out Exception exception)
        {
            return DalRuntimeInfo.GetRuntimeInfo(id, out exception);
        }

        public static RuntimeInfo GetRuntimeInfo(string keyName, out Exception exception)
        {
            return DalRuntimeInfo.GetRuntimeInfo(keyName, out exception);
        }

        public static int AddRuntimeInfo(string keyName, string keyValue1, string keyValue2, out Exception exception)
        {
            return DalRuntimeInfo.AddRuntimeInfo(keyName, keyValue1, keyValue2, out exception);
        }

        public static int ModifyRuntimeInfo(string keyName, string keyValue1, string keyValue2, out Exception exception)
        {
            return DalRuntimeInfo.ModifyRuntimeInfo(keyName, keyValue1, keyValue2, out exception);
        }

        public static int SaveRuntimeInfo(RuntimeInfo runtimeInfo, out Exception exception)
        {
            return DalRuntimeInfo.SaveRuntimeInfo(runtimeInfo, out exception);
        }

        public static int UpdateRuntimeInfo(RuntimeInfo runtimeInfo, out Exception exception)
        {
            return DalRuntimeInfo.UpdateRuntimeInfo(runtimeInfo, out exception);
        }

        public static int DeleteRuntimeInfo(int id, out Exception exception)
        {
            return DalRuntimeInfo.DeleteRuntimeInfo(id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return DalRuntimeInfo.ExecSqlQuery(queryCmd, paraList, out exception);
        }
    }
}
