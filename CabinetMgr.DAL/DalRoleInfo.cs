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
    public class DalRoleInfo : FlexNhBase<RoleInfo>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<RoleInfo> SearchRoleInfo(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            List<Order> requestedOrder;// = DbOrder.ToOrderList(orderList);
            if (orderList == null) requestedOrder = new List<Order>() { new Order("TreeLevel", true), new Order("RoleOrder", true) };
            else requestedOrder = DbOrder.ToOrderList(orderList);
            return SearchItem(criterionList, requestedOrder, dataStart, dataCount, out exception);
        }

        public static int GetRoleInfoCount(out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            return GetItemCount(criterionList, out exception);
        }

        public static RoleInfo GetRoleInfo(string id, out Exception exception)
        {
            return GetItemInfo("Id", id, out exception);
        }

        public static RoleInfo GetRoleInfo(string entityName, object entityValue, out Exception exception)
        {
            return GetItemInfo(entityName, entityValue, out exception);
        }

        public static int AddRoleInfo(string roleName, int treeLevel, string treeParent, int roleOrder, string roleDesp, DateTime lastChanged, out Exception exception)
        {
            RoleInfo itemRecord = new RoleInfo
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                RoleName = roleName,
                TreeLevel = treeLevel,
                TreeParent = treeParent,
                RoleOrder = roleOrder,
                RoleDesp = roleDesp,
                LastChanged = lastChanged,
            };
            return SaveItem(itemRecord, out exception);
        }

        public static int ModifyRoleInfo(string id, string roleName, int treeLevel, string treeParent, int roleOrder, string roleDesp, DateTime lastChanged, out Exception exception)
        {
            RoleInfo itemRecord = GetRoleInfo(id, out exception);
            if (itemRecord == null) return 0;
            itemRecord.RoleName = roleName;
            itemRecord.TreeLevel = treeLevel;
            itemRecord.TreeParent = treeParent;
            itemRecord.RoleOrder = roleOrder;
            itemRecord.RoleDesp = roleDesp;
            itemRecord.LastChanged = lastChanged;
            return UpdateItem(itemRecord, out exception);
        }

        public static int SaveRoleInfo(RoleInfo roleInfo, out Exception exception)
        {
            return SaveItem(roleInfo, out exception);
        }

        public static int UpdateRoleInfo(RoleInfo roleInfo, out Exception exception)
        {
            return UpdateItem(roleInfo, out exception);
        }

        public static int DeleteRoleInfo(string id, out Exception exception)
        {
            return DeleteItem("Id", id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return ExecQuery(queryCmd, paraList, out exception);
        }

        public static int DeleteAll(out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            criterionList.Add(Restrictions.Not(Restrictions.Eq("IsProtected", 1)));
            return DeleteItem(criterionList, out exception);
        }
    }
}