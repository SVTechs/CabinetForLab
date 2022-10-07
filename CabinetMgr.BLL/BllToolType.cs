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
    public class BllToolType
    {
        public static IList<ToolType> SearchToolType(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            return DalToolType.SearchToolType(dataStart, dataCount, orderList, out exception);
        }

        public static int GetToolTypeCount(out Exception exception)
        {
            return DalToolType.GetToolTypeCount(out exception);
        }

        public static ToolType GetToolType(long id, out Exception exception)
        {
            return DalToolType.GetToolType(id, out exception);
        }

        public static ToolType GetToolType(string entityName, object entityValue, out Exception exception)
        {
            return DalToolType.GetToolType(entityName, entityValue, out exception);
        }

        public static int AddToolType(string typeName, DateTime createTime, out Exception exception)
        {
            return DalToolType.AddToolType(typeName, createTime, out exception);
        }

        public static int ModifyToolType(long id, string typeName, DateTime createTime, out Exception exception)
        {
            return DalToolType.ModifyToolType(id, typeName, createTime, out exception);
        }

        public static int SaveToolType(ToolType toolType, out Exception exception)
        {
            return DalToolType.SaveToolType(toolType, out exception);
        }

        public static int UpdateToolType(ToolType toolType, out Exception exception)
        {
            return DalToolType.UpdateToolType(toolType, out exception);
        }

        public static int DeleteToolType(long id, out Exception exception)
        {
            return DalToolType.DeleteToolType(id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return DalToolType.ExecSqlQuery(queryCmd, paraList, out exception);
        }
    }
}
