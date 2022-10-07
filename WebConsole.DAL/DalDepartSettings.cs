using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using NHibernate.Criterion;
using NLog;
using Utilities.String;
using WebConsole.DAL.NhUtils;

namespace WebConsole.DAL
{
    public class DalDepartSettings : FlexNhBase<DepartSettings>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<DepartSettings> SearchDepartSettings(out Exception exception)
        {
            return SearchItem<DepartSettings>(null, null, 0, -1, out exception);
        }

        public static IList<DepartSettings> SearchDepartSettings(List<string> departList, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.In("DepartId", departList)
            };
            return SearchItem<DepartSettings>(critList, null, 0, -1, out exception);
        }

        public static DepartSettings GetDepartSettings(string id, out Exception exception)
        {
            return GetItemInfo<DepartSettings>("Id", id, out exception);
        }

        public static IList<DepartSettings> GetUserDepartSettings(string userId, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("UserId", userId)
            };
            return SearchItem<DepartSettings>(critList, null, 0, -1, out exception);
        }

        public static DepartSettings GetTargetSetting(string userId, string departId, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("UserId", userId),
                Restrictions.Eq("DepartId", departId)
            };
            return GetItemInfo<DepartSettings>(critList, out exception);
        }

        public static int DeleteDepartSettings(string infoId, UserInfo adminInfo, out Exception exception)
        {
            return DeleteItem("Id", infoId, out exception);
        }

        public static int AppendDepart(string userId, string departId, out Exception exception)
        {
            DepartSettings rs = new DepartSettings
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                UserId = userId,
                DepartId = departId,
                LastChanged = DateTime.Now
            };
            return SaveItem(rs, out exception);
        }

        public static int SetUserDepart(string userId, string[] departId, UserInfo adminInfo)
        {
            try
            {
                var sessionFactory = NhControl.CreateSessionFactory();
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        //清除原有权限
                        int result = session.CreateQuery(" delete from DepartSettings where UserId = :userId")
                            .SetString("userId", userId)
                            .ExecuteUpdate();
                        if (result < 0)
                        {
                            return -201;
                        }
                        //加入现有权限
                        for (int i = 0; i < departId.Length; i++)
                        {
                            if (string.IsNullOrWhiteSpace(departId[i])) continue;
                            if (departId[i].ToUpper().Equals("ROOT")) continue;
                            DepartSettings rs = new DepartSettings
                            {
                                Id = Guid.NewGuid().ToString().ToUpper(),
                                UserId = userId,
                                DepartId = departId[i],
                                LastChanged = DateTime.Now
                            };
                            session.SaveOrUpdate(rs);
                        }
                        //保存日志
                        SysDataHistory sd = new SysDataHistory
                        {
                            OperateType = "更改用户部门",
                            DataType = "用户信息",
                            OperateDesp = "新部门信息: " + departId.ArrayJoin(","),
                            OperateUser = adminInfo.Id,
                            OperateUserName = adminInfo.RealName,
                            OperateTime = DateTime.Now
                        };
                        session.Save(sd);
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

        public static int DeleteUserDepartSettings(string userId, out Exception exception)
        {
            exception = null;
            try
            {
                var sessionFactory = NhControl.CreateSessionFactory();
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        //清除用户部门
                        int result = session.CreateQuery(" delete from DepartSettings where UserId = :userId")
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
                exception = ex;
                logger.Error(ex);
            }
            return -200;
        }
    }
}
