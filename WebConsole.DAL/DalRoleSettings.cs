using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Server.Domain;
using NHibernate;
using NHibernate.Criterion;
using NLog;
using WebConsole.DAL.NhUtils;

namespace WebConsole.DAL
{
    public class DalRoleSettings : FlexNhBase<RoleSettings>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<RoleSettings> SearchRoleSettings(out Exception exception)
        {
            return SearchItem<RoleSettings>(null, null, 0, -1, out exception);
        }

        public static IList<RoleSettings> SearchRoleSettings(string roleId, out Exception ex)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("RoleId", roleId),
                Restrictions.Eq("Status", 0)
            };
            return SearchItem<RoleSettings>(critList, null, 0, -1, out ex);
        }

        public static IList<RoleSettings> GetUserRoleSettings(string userId, out Exception ex)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("UserId", userId),
                Restrictions.Eq("Status", 0)
            };
            return SearchItem<RoleSettings>(critList, null, 0, -1, out ex);
        }

        public static RoleSettings GetRoleSettings(string id, out Exception exception)
        {
            return GetItemInfo<RoleSettings>("Id", id, out exception);
        }

        public static RoleSettings GetTargetSetting(string userId, string roleId, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("UserId", userId),
                Restrictions.Eq("RoleId", roleId)
            };
            return GetItemInfo<RoleSettings>(critList, out exception);
        }

        public static int AppendRole(string userId, string roleId, out Exception exception)
        {
            RoleSettings rs = new RoleSettings
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                UserId = userId,
                RoleId = roleId,
                LastChanged = DateTime.Now
            };
            return SaveItem(rs, out exception);
        }

        public static int SetUserRole(string userId, string[]roleId)
        {
            try
            {
                var sessionFactory = NhControl.CreateSessionFactory();
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        //清除原有权限
                        int result = session.CreateQuery("delete from RoleSettings where UserId = :userId")
                            .SetString("userId", userId)
                            .ExecuteUpdate();
                        if (result < 0)
                        {
                            return -201;
                        }
                        //加入现有权限
                        for (int i = 0; i < roleId.Length; i++)
                        {
                            if (string.IsNullOrWhiteSpace(roleId[i])) continue;
                            if (roleId[i].ToUpper().Equals("ROOT")) continue;
                            RoleSettings rs = new RoleSettings
                            {
                                Id = Guid.NewGuid().ToString().ToUpper(),
                                UserId = userId,
                                RoleId = roleId[i],
                                LastChanged = DateTime.Now
                            };
                            session.SaveOrUpdate(rs);
                        }
                        transaction.Commit();
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return -200;
        }

        public static int DeleteUserRoleSettings(string userId, out Exception ex)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>()
            {
                Restrictions.Eq("UserId", userId)
            };
            return DeleteItem<RoleSettings>(critList, out ex);
        }

        public static int DeleteRoleSettings(string id, out Exception exception)
        {
            return DeleteItem<RoleSettings>("Id", id, out exception);
        }
    }
}
