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
    public class DalToolInfo : FlexNhBase<ToolInfo>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<ToolInfo> SearchToolInfo(string toolName, int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            criterionList.Add(Restrictions.Like("ToolName", toolName, MatchMode.Anywhere));
            //Criterion Processing
            List<Order> requestedOrder = DbOrder.ToOrderList(orderList);
            return SearchItem(criterionList, requestedOrder, dataStart, dataCount, out exception);
        }

        public static int GetToolInfoCount(out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            return GetItemCount(criterionList, out exception);
        }

        public static ToolInfo GetToolInfo(string id, out Exception exception)
        {
            return GetItemInfo("Id", id, out exception);
        }

        public static ToolInfo GetToolInfo(string entityName, object entityValue, out Exception exception)
        {
            return GetItemInfo(entityName, entityValue, out exception);
        }

        public static int SaveToolInfo(ToolInfo toolInfo, out Exception exception)
        {
            return SaveItem(toolInfo, out exception);
        }

        public static int UpdateToolInfo(ToolInfo toolInfo, out Exception exception)
        {
            return UpdateItem(toolInfo, out exception);
        }

        public static int DeleteToolInfo(string id, out Exception exception)
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
            criterionList.Add(Restrictions.Not(Restrictions.Eq("Id", null)));
            return DeleteItem(criterionList, out exception);
        }

        public static ToolInfo GetToolInfo(long latticeId, string toolCode, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            criterionList.Add(Restrictions.Eq("LatticeId", latticeId));
            criterionList.Add(Restrictions.Eq("ToolCode", toolCode));
            return GetItemInfo(criterionList, out exception);
        }
    }
}
