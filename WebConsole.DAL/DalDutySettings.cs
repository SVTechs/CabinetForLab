using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using NHibernate.Criterion;
using NLog;
using WebConsole.DAL.NhUtils;

namespace WebConsole.DAL
{
    public class DalDutySettings : FlexNhBase<DutySettings>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<DutySettings> SearchDutySettings(out Exception exception)
        {
            return SearchItem<DutySettings>(null, null, 0, -1, out exception);
        }

        public static IList<DutySettings> SearchDutySettings(List<string> dutyList, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.In("DutyId", dutyList)
            };
            return SearchItem<DutySettings>(critList, null, 0, -1, out exception);
        }

        public static DutySettings GetDutySettings(string id, out Exception exception)
        {
            return GetItemInfo<DutySettings>("Id", id, out exception);
        }

        public static IList<DutySettings> GetUserDutySettings(string userId, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("UserId", userId)
            };
            return SearchItem<DutySettings>(critList, null, 0, -1, out exception);
        }

        public static DutySettings GetTargetSetting(string userId, string dutyId, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("UserId", userId),
                Restrictions.Eq("DutyId", dutyId)
            };
            return GetItemInfo<DutySettings>(critList, out exception);
        }

        public static int DeleteDutySettings(string infoId, out Exception exception)
        {
            return DeleteItem("Id", infoId, out exception);
        }

        public static int AppendDuty(string userId, string dutyId, out Exception exception)
        {
            DutySettings rs = new DutySettings
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                UserId = userId,
                DutyId = dutyId,
                LastChanged = DateTime.Now
            };
            return SaveItem(rs, out exception);
        }

        public static int SetUserDuty(string userId, string[] dutyId)
        {
            try
            {
                var sessionFactory = NhControl.CreateSessionFactory();
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        //清除原有权限
                        int result = session.CreateQuery(" delete from DutySettings where UserId = :userId")
                            .SetString("userId", userId)
                            .ExecuteUpdate();
                        if (result < 0)
                        {
                            return -201;
                        }
                        //加入现有权限
                        for (int i = 0; i < dutyId.Length; i++)
                        {
                            if (string.IsNullOrWhiteSpace(dutyId[i])) continue;
                            if (dutyId[i].ToUpper().Equals("ROOT")) continue;
                            DutySettings rs = new DutySettings
                            {
                                Id = Guid.NewGuid().ToString().ToUpper(),
                                UserId = userId,
                                DutyId = dutyId[i],
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

        public static int DeleteUserDutySettings(string userId)
        {
            try
            {
                var sessionFactory = NhControl.CreateSessionFactory();
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        //清除用户部门
                        int result = session.CreateQuery(" delete from DutySettings where UserId = :userId")
                            .SetString("userId", userId)
                            .ExecuteUpdate();
                        if (result < 0)
                        {
                            return -201;
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
    }
}
