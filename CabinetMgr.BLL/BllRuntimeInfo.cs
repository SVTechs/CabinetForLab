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
    public class BllRuntimeInfo
    {
        public static IList<RuntimeInfo> SearchRuntimeInfo(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            return DalRuntimeInfo.SearchRuntimeInfo(dataStart, dataCount, orderList, out exception);
        }

        public static int GetRuntimeInfoCount(out Exception exception)
        {
            return DalRuntimeInfo.GetRuntimeInfoCount(out exception);
        }

        public static RuntimeInfo GetRuntimeInfo(int id, out Exception exception)
        {
            return DalRuntimeInfo.GetRuntimeInfo(id, out exception);
        }

        public static RuntimeInfo GetRuntimeInfo(string entityName, object entityValue, out Exception exception)
        {
            return DalRuntimeInfo.GetRuntimeInfo(entityName, entityValue, out exception);
        }

        public static int AddRuntimeInfo(string keyName, string keyValue1, string keyValue2, string keyValue3, string keyValue4, out Exception exception)
        {
            return DalRuntimeInfo.AddRuntimeInfo(keyName, keyValue1, keyValue2, keyValue3, keyValue4, out exception);
        }

        public static int ModifyRuntimeInfo(int id, string keyName, string keyValue1, string keyValue2, string keyValue3, string keyValue4, out Exception exception)
        {
            return DalRuntimeInfo.ModifyRuntimeInfo(id, keyName, keyValue1, keyValue2, keyValue3, keyValue4, out exception);
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
