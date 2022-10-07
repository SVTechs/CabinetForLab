using CabinetMgr.DAL.NhUtils;
using Domain.Main.Domain;
using Domain.Main.Types;
using NHibernate.Criterion;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetMgr.DAL
{
    public class DalLatticePermissionSettings : FlexNhBase<LatticePermissionSettings>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<LatticePermissionSettings> SearchLatticePermissionSettings(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            List<Order> requestedOrder = DbOrder.ToOrderList(orderList);
            return SearchItem(criterionList, requestedOrder, dataStart, dataCount, out exception);
        }

        public static int GetLatticePermissionSettingsCount(out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            return GetItemCount(criterionList, out exception);
        }

        public static LatticePermissionSettings GetLatticePermissionSettings(string id, out Exception exception)
        {
            return GetItemInfo("Id", id, out exception);
        }

        public static LatticePermissionSettings GetLatticePermissionSettings(string entityName, object entityValue, out Exception exception)
        {
            return GetItemInfo(entityName, entityValue, out exception);
        }

        public static int SaveLatticePermissionSettings(LatticePermissionSettings latticePermissionSettings, out Exception exception)
        {
            return SaveItem(latticePermissionSettings, out exception);
        }

        public static int UpdateLatticePermissionSettings(LatticePermissionSettings latticePermissionSettings, out Exception exception)
        {
            return UpdateItem(latticePermissionSettings, out exception);
        }

        public static int DeleteLatticePermissionSettings(string id, out Exception exception)
        {
            return DeleteItem("Id", id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return ExecQuery(queryCmd, paraList, out exception);
        }

        public static long[] GetLatticePermissionList(string userId, string[] roleAry, out Exception exception)
        {
            List<AbstractCriterion> roleCriterionList = new List<AbstractCriterion>();
            List<AbstractCriterion> userCriterionList = new List<AbstractCriterion>();
            //Criterion Processing
            roleCriterionList.Add(Restrictions.In("OwnerId", roleAry));
            roleCriterionList.Add(Restrictions.Eq("OwnerType", "Role"));
            userCriterionList.Add(Restrictions.Eq("OwnerId", userId));
            userCriterionList.Add(Restrictions.Eq("OwnerType", "User"));

            IList<LatticePermissionSettings> roleList = SearchItem(roleCriterionList, null, 0, -1, out exception);
            IList<LatticePermissionSettings> userList = SearchItem(userCriterionList, null, 0, -1, out exception);
            return roleList.Concat(userList).Select(x => x.LatticeId).Distinct().ToArray();

        }
    }
}
