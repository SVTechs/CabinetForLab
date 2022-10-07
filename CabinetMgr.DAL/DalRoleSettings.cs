using CabinetMgr.DAL.NhUtils;
using Domain.Main.Domain;
using Domain.Main.Types;
using NHibernate;
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
    public class DalRoleSettings : FlexNhBase<RoleSettings>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<RoleSettings> SearchRoleSettings(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            List<Order> requestedOrder = DbOrder.ToOrderList(orderList);
            return SearchItem(criterionList, requestedOrder, dataStart, dataCount, out exception);
        }

        public static int GetRoleSettingsCount(out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            return GetItemCount(criterionList, out exception);
        }

        public static RoleSettings GetRoleSettings(string id, out Exception exception)
        {
            return GetItemInfo("Id", id, out exception);
        }

        public static RoleSettings GetRoleSettings(string entityName, object entityValue, out Exception exception)
        {
            return GetItemInfo(entityName, entityValue, out exception);
        }

        public static int AddRoleSettings(string userId, string roleId, DateTime addTime, out Exception exception)
        {
            RoleSettings itemRecord = new RoleSettings
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                UserId = userId,
                RoleId = roleId,
                AddTime = addTime,
            };
            return SaveItem(itemRecord, out exception);
        }

        public static int ModifyRoleSettings(string id, string userId, string roleId, DateTime addTime, out Exception exception)
        {
            RoleSettings itemRecord = GetRoleSettings(id, out exception);
            if (itemRecord == null) return 0;
            itemRecord.UserId = userId;
            itemRecord.RoleId = roleId;
            itemRecord.AddTime = addTime;
            return UpdateItem(itemRecord, out exception);
        }

        public static int SaveRoleSettings(RoleSettings roleSettings, out Exception exception)
        {
            return SaveItem(roleSettings, out exception);
        }

        public static int UpdateRoleSettings(RoleSettings roleSettings, out Exception exception)
        {
            return UpdateItem(roleSettings, out exception);
        }

        public static int DeleteRoleSettings(string id, out Exception exception)
        {
            return DeleteItem("Id", id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return ExecQuery(queryCmd, paraList, out exception);
        }

        public static IList<RoleSettings> GetUserRoleSettings(string userId, out Exception exception)
        {
            try
            {
                var sessionFactory = NhControl.CreateSessionFactory();
                exception = null;
                using (var session = sessionFactory.OpenSession())
                {
                    ICriteria pQuery = session.CreateCriteria(typeof(RoleSettings))
                        .Add(Restrictions.Eq("UserId", userId));
                    return pQuery.List<RoleSettings>();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                exception = ex;
            }
            return null;
        }
    }
}
