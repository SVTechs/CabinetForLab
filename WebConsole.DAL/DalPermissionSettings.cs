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
    public class DalPermissionSettings : FlexNhBase<PermissionSettings>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<PermissionSettings> SearchPermissionSettings(out Exception exception)
        {
            return SearchItem<PermissionSettings>(null, null, 0, -1, out exception);
        }

        public static IList<PermissionSettings> SearchPermissionSettings(string permissionId, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("AccessType", "Func"),
                Restrictions.Eq("AccessId", permissionId),
                Restrictions.Eq("Status", 0)
            };
            return SearchItem<PermissionSettings>(critList, null, 0, -1, out exception);
        }

        public static IList<PermissionSettings> GetOwnerPermissionSettings(string ownerId, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("OwnerId", ownerId),
                Restrictions.Eq("Status", 0)
            };
            return SearchItem<PermissionSettings>(critList, null, 0, -1, out exception);
        }

        public static PermissionSettings GetPermissionSettings(string id, out Exception exception)
        {
            return GetItemInfo("Id", id, out exception);
        }

        public static int SavePermissionSettings(PermissionSettings permissionSettings, out Exception exception)
        {
            return SaveItem(permissionSettings, out exception);
        }

        public static int SetOwnerPermission(string ownerType, string ownerId, string[] permId)
        {
            try
            {
                var sessionFactory = NhControl.CreateSessionFactory();
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        List<string> permFilter = new List<string>();
                        for (int i = 0; i < permId.Length; i++)
                        {
                            if (permId[i].Length > 10) permFilter.Add(permId[i].Substring(1));
                        }
                        //清空权限
                        int result = session.CreateQuery(" delete from PermissionSettings where OwnerId = :ownerId")
                            .SetString("ownerId", ownerId)
                            .ExecuteUpdate();
                        if (result < 0)
                        {
                            return -201;
                        }
                        //加入权限
                        for (int i = 0; i < permId.Length; i++)
                        {
                            if (string.IsNullOrWhiteSpace(permId[i])) continue;
                            string accessType = "Func";
                            if (permId[i].StartsWith("W") || permId[i].StartsWith("P"))
                            {
                                accessType = "Menu";
                            }
                            PermissionSettings rs = new PermissionSettings
                            {
                                Id = Guid.NewGuid().ToString().ToUpper(),
                                OwnerType = ownerType,
                                OwnerId = ownerId,
                                AccessType = accessType,
                                AccessId = permId[i].Substring(1),
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

        public static int DeleteOwnerPermissionSettings(string ownerId, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>()
            {
                Restrictions.Eq("OwnerId", ownerId)
            };
            return DeleteItem<PermissionSettings>(critList, out exception);
        }

        public static int DeletePermissionSettings(string id, out Exception exception)
        {
            return DeleteItem<PermissionSettings>("Id", id, out exception);
        }
    }
}
