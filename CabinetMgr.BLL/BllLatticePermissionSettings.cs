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
    public class BllLatticePermissionSettings
    {
        public static IList<LatticePermissionSettings> SearchLatticePermissionSettings(string ownerId, string ownerType, int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            return DalLatticePermissionSettings.SearchLatticePermissionSettings(ownerId, ownerType, dataStart, dataCount, orderList, out exception);
        }

        public static int GetLatticePermissionSettingsCount(out Exception exception)
        {
            return DalLatticePermissionSettings.GetLatticePermissionSettingsCount(out exception);
        }

        public static LatticePermissionSettings GetLatticePermissionSettings(string id, out Exception exception)
        {
            return DalLatticePermissionSettings.GetLatticePermissionSettings(id, out exception);
        }

        public static LatticePermissionSettings GetLatticePermissionSettings(string entityName, object entityValue, out Exception exception)
        {
            return DalLatticePermissionSettings.GetLatticePermissionSettings(entityName, entityValue, out exception);
        }

        public static int SaveLatticePermissionSettings(LatticePermissionSettings latticePermissionSettings, out Exception exception)
        {
            return DalLatticePermissionSettings.SaveLatticePermissionSettings(latticePermissionSettings, out exception);
        }

        public static int UpdateLatticePermissionSettings(LatticePermissionSettings latticePermissionSettings, out Exception exception)
        {
            return DalLatticePermissionSettings.UpdateLatticePermissionSettings(latticePermissionSettings, out exception);
        }

        public static int DeleteLatticePermissionSettings(string id, out Exception exception)
        {
            return DalLatticePermissionSettings.DeleteLatticePermissionSettings(id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return DalLatticePermissionSettings.ExecSqlQuery(queryCmd, paraList, out exception);
        }

        public static long[] GetLatticePermissionList(string userId, string[] roleAry, out Exception exception)
        {
            return DalLatticePermissionSettings.GetLatticePermissionList(userId, roleAry, out exception);
        }

        public static int BatchSaveLatticePermissionSettings(string ownerId, string ownerType, IList<LatticePermissionSettings> list, out Exception exception)
        {
            return DalLatticePermissionSettings.BatchSaveLatticePermissionSettings(ownerId, ownerType, list, out exception);
        }

        public static int DeleteAll(out Exception exception)
        {
            return DalLatticePermissionSettings.DeleteAll(out exception);
        }
    }
}
