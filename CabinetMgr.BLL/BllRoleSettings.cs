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
    public class BllRoleSettings
    {
        public static IList<RoleSettings> SearchRoleSettings(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            return DalRoleSettings.SearchRoleSettings(dataStart, dataCount, orderList, out exception);
        }

        public static int GetRoleSettingsCount(out Exception exception)
        {
            return DalRoleSettings.GetRoleSettingsCount(out exception);
        }

        public static RoleSettings GetRoleSettings(string id, out Exception exception)
        {
            return DalRoleSettings.GetRoleSettings(id, out exception);
        }

        public static RoleSettings GetRoleSettings(string entityName, object entityValue, out Exception exception)
        {
            return DalRoleSettings.GetRoleSettings(entityName, entityValue, out exception);
        }

        public static int AddRoleSettings(string userId, string roleId, DateTime addTime, out Exception exception)
        {
            return DalRoleSettings.AddRoleSettings(userId, roleId, addTime, out exception);
        }

        public static int ModifyRoleSettings(string id, string userId, string roleId, DateTime addTime, out Exception exception)
        {
            return DalRoleSettings.ModifyRoleSettings(id, userId, roleId, addTime, out exception);
        }

        public static int SaveRoleSettings(RoleSettings roleSettings, out Exception exception)
        {
            return DalRoleSettings.SaveRoleSettings(roleSettings, out exception);
        }

        public static int UpdateRoleSettings(RoleSettings roleSettings, out Exception exception)
        {
            return DalRoleSettings.UpdateRoleSettings(roleSettings, out exception);
        }

        public static int DeleteRoleSettings(string id, out Exception exception)
        {
            return DalRoleSettings.DeleteRoleSettings(id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return DalRoleSettings.ExecSqlQuery(queryCmd, paraList, out exception);
        }

        public static IList<RoleSettings> GetUserRoleSettings(string userId, out Exception exception)
        {
            return DalRoleSettings.GetUserRoleSettings(userId, out exception);
        }
    }
}
