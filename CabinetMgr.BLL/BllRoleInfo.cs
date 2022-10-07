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
    public class BllRoleInfo
    {
        public static IList<RoleInfo> SearchRoleInfo(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            return DalRoleInfo.SearchRoleInfo(dataStart, dataCount, orderList, out exception);
        }

        public static int GetRoleInfoCount(out Exception exception)
        {
            return DalRoleInfo.GetRoleInfoCount(out exception);
        }

        public static RoleInfo GetRoleInfo(string id, out Exception exception)
        {
            return DalRoleInfo.GetRoleInfo(id, out exception);
        }

        public static RoleInfo GetRoleInfo(string entityName, object entityValue, out Exception exception)
        {
            return DalRoleInfo.GetRoleInfo(entityName, entityValue, out exception);
        }

        public static int AddRoleInfo(string roleName, int treeLevel, string treeParent, int roleOrder, string roleDesp, DateTime lastChanged, out Exception exception)
        {
            return DalRoleInfo.AddRoleInfo(roleName, treeLevel, treeParent, roleOrder, roleDesp, lastChanged, out exception);
        }

        public static int ModifyRoleInfo(string id, string roleName, int treeLevel, string treeParent, int roleOrder, string roleDesp, DateTime lastChanged, out Exception exception)
        {
            return DalRoleInfo.ModifyRoleInfo(id, roleName, treeLevel, treeParent, roleOrder, roleDesp, lastChanged, out exception);
        }

        public static int SaveRoleInfo(RoleInfo roleInfo, out Exception exception)
        {
            return DalRoleInfo.SaveRoleInfo(roleInfo, out exception);
        }

        public static int UpdateRoleInfo(RoleInfo roleInfo, out Exception exception)
        {
            return DalRoleInfo.UpdateRoleInfo(roleInfo, out exception);
        }

        public static int DeleteRoleInfo(string id, out Exception exception)
        {
            return DalRoleInfo.DeleteRoleInfo(id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return DalRoleInfo.ExecSqlQuery(queryCmd, paraList, out exception);
        }
    }
}
