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
    public class BllToolSettings
    {
        public static IList<ToolSettings> SearchToolSettings(string toolId, int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            return DalToolSettings.SearchToolSettings(toolId, dataStart, dataCount, orderList, out exception);
        }

        public static int GetToolSettingsCount(out Exception exception)
        {
            return DalToolSettings.GetToolSettingsCount(out exception);
        }

        public static ToolSettings GetToolSettings(string id, out Exception exception)
        {
            return DalToolSettings.GetToolSettings(id, out exception);
        }

        public static ToolSettings GetToolSettings(string entityName, object entityValue, out Exception exception)
        {
            return DalToolSettings.GetToolSettings(entityName, entityValue, out exception);
        }

        public static int AddToolSettings(string ownerType, string ownerId, string toolId, DateTime addTime, out Exception exception)
        {
            return DalToolSettings.AddToolSettings(ownerType, ownerId, toolId, addTime, out exception);
        }

        public static int ModifyToolSettings(string id, string ownerType, string ownerId, string toolId, DateTime addTime, out Exception exception)
        {
            return DalToolSettings.ModifyToolSettings(id, ownerType, ownerId, toolId, addTime, out exception);
        }

        public static int SaveToolSettings(ToolSettings toolSettings, out Exception exception)
        {
            return DalToolSettings.SaveToolSettings(toolSettings, out exception);
        }

        public static int UpdateToolSettings(ToolSettings toolSettings, out Exception exception)
        {
            return DalToolSettings.UpdateToolSettings(toolSettings, out exception);
        }

        public static int DeleteToolSettings(string id, out Exception exception)
        {
            return DalToolSettings.DeleteToolSettings(id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return DalToolSettings.ExecSqlQuery(queryCmd, paraList, out exception);
        }

        public static int BatchSaveToolSettings(string toolId, IList<ToolSettings> list, out Exception exception)
        {
            return DalToolSettings.BatchSaveToolSettings(toolId, list, out exception);
        }

        public static IList<ToolSettings> GetToolSettings(string[] roleAry, out Exception exception)
        {
            return DalToolSettings.GetToolSettings(roleAry, out exception);
        }
    }
}