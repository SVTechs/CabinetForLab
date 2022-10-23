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
    public class BllToolInfo
    {
        public static IList<ToolInfo> SearchToolInfo(string toolName, int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            return DalToolInfo.SearchToolInfo(toolName, dataStart, dataCount, orderList, out exception);
        }

        public static int GetToolInfoCount(out Exception exception)
        {
            return DalToolInfo.GetToolInfoCount(out exception);
        }

        public static ToolInfo GetToolInfo(string id, out Exception exception)
        {
            return DalToolInfo.GetToolInfo(id, out exception);
        }

        public static ToolInfo GetToolInfo(long latticeId, string toolCode, out Exception exception)
        {
            return DalToolInfo.GetToolInfo(latticeId, toolCode, out exception);
        }

        public static ToolInfo GetToolInfo(string entityName, object entityValue, out Exception exception)
        {
            return DalToolInfo.GetToolInfo(entityName, entityValue, out exception);
        }

        public static int SaveToolInfo(ToolInfo toolInfo, out Exception exception)
        {
            return DalToolInfo.SaveToolInfo(toolInfo, out exception);
        }

        public static int UpdateToolInfo(ToolInfo toolInfo, out Exception exception)
        {
            return DalToolInfo.UpdateToolInfo(toolInfo, out exception);
        }

        public static int DeleteToolInfo(string id, out Exception exception)
        {
            return DalToolInfo.DeleteToolInfo(id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return DalToolInfo.ExecSqlQuery(queryCmd, paraList, out exception);
        }

        public static int DeleteAll(out Exception exception)
        {
            return DalToolInfo.DeleteAll(out exception);
        }
    }
}
