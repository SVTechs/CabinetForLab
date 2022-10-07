using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Server.Domain;
using Domain.Server.Types;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using NLog;
using Utilities.Data;
using WebConsole.Config;
using WebConsole.DAL.NhUtils;

namespace WebConsole.DAL
{
    public class DalUserInfo : FlexNhBase<UserInfo>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<UserInfo> SearchUserInfo(out Exception exception)
        {
            FetchSettings fs = new FetchSettings("DepartSetting", FetchMode.Join);
            return SearchItemEx<UserInfo>(null, null, fs, Transformers.DistinctRootEntity, 0, -1, out exception);
        }

        public static IList<UserInfo> SearchUserInfoLite(out Exception exception)
        {
            return SearchItemEx<UserInfo>(null, null, null, Transformers.DistinctRootEntity, 0, -1, out exception);
        }

        public static IList<UserInfo> SearchUserInfoWithFp(out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.IsNotNull("FingerPrint1")
            };
            return SearchItem<UserInfo>(critList, null, 0, -1, out exception);
        }

        public static IList<UserInfo> SearchUser(List<string> userList, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.In("Id", userList)
            };
            List<Order> orderList = new List<Order>
            {
                Order.Asc("PagingId")
            };
            FetchSettings fs = new FetchSettings("DepartSetting", FetchMode.Join);
            return SearchItemEx<UserInfo>(critList, orderList, fs, Transformers.DistinctRootEntity, 0, -1, out exception);
        }

        public static IList<UserInfo> SearchUserByDepart(string departId, out Exception exception)
        {
            try
            {
                using (ISession session = GetSession<UserInfo>(out exception))
                {
                    if (session == null) return null;
                    var query = session.Query<UserInfo>().Where(x => x.DepartSetting.Any(i => i.DepartId == departId));
                    var result = query.ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                exception = e;
            }
            return null;
        }

        public static int GetUserCount(string userName, string realName, string departId, string excludeDepartId,
            string roleId, string excludeRoleId, string dutyId, string excludeDutyId, out Exception exception)
        {
            using (ISession session = GetSession<UserInfo>(out exception))
            {
                if (session == null) return -200;
                var query = session.Query<UserInfo>();
                if (!string.IsNullOrEmpty(userName))
                {
                    query = query.Where(x => x.UserName.Contains(userName));
                }
                if (!string.IsNullOrEmpty(realName))
                {
                    query = query.Where(x => x.RealName.Contains(realName));
                }
                if (!string.IsNullOrEmpty(departId))
                {
                    query = query.Where(x => x.DepartSetting.Any(i => i.DepartId == departId));
                }
                if (!string.IsNullOrEmpty(excludeDepartId))
                {
                    query = query.Where(x => x.DepartSetting.All(i => i.DepartId != excludeDepartId));
                }
                if (!string.IsNullOrEmpty(roleId))
                {
                    query = query.Where(x => x.RoleSetting.Any(i => i.RoleId == roleId));
                }
                if (!string.IsNullOrEmpty(excludeRoleId))
                {
                    query = query.Where(x => x.RoleSetting.All(i => i.RoleId != excludeRoleId));
                }
                if (!string.IsNullOrEmpty(dutyId))
                {
                    query = query.Where(x => x.DutySetting.Any(i => i.DutyId == dutyId));
                }
                if (!string.IsNullOrEmpty(excludeDutyId))
                {
                    query = query.Where(x => x.DutySetting.All(i => i.DutyId != excludeDutyId));
                }
                return query.Count();
            }
        }

        public static IList<UserInfo> SearchUser(string userName, string realName, string departId, string excludeDepartId,
            string roleId, string excludeRoleId, string dutyId, string excludeDutyId,
            int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            try
            {
                using (ISession session = GetSession<UserInfo>(out exception))
                {
                    if (session == null) return null;
                    var query = session.Query<UserInfo>();
                    if (!string.IsNullOrEmpty(userName))
                    {
                        query = query.Where(x => x.UserName.Contains(userName));
                    }
                    if (!string.IsNullOrEmpty(realName))
                    {
                        query = query.Where(x => x.RealName.Contains(realName));
                    }
                    if (!string.IsNullOrEmpty(departId))
                    {
                        query = query.Where(x => x.DepartSetting.Any(i => i.DepartId == departId));
                    }
                    if (!string.IsNullOrEmpty(excludeDepartId))
                    {
                        query = query.Where(x => x.DepartSetting.All(i => i.DepartId != excludeDepartId));
                    }
                    if (!string.IsNullOrEmpty(roleId))
                    {
                        query = query.Where(x => x.RoleSetting.Any(i => i.RoleId == roleId));
                    }
                    if (!string.IsNullOrEmpty(excludeRoleId))
                    {
                        query = query.Where(x => x.RoleSetting.All(i => i.RoleId != excludeRoleId));
                    }
                    if (!string.IsNullOrEmpty(dutyId))
                    {
                        query = query.Where(x => x.DutySetting.Any(i => i.DutyId == dutyId));
                    }
                    if (!string.IsNullOrEmpty(excludeDutyId))
                    {
                        query = query.Where(x => x.DutySetting.All(i => i.DutyId != excludeDutyId));
                    }
                    if (orderList == null || orderList.Count == 0)
                    {
                        query = query.OrderBy(x => x.UserName);
                    }
                    if (dataCount > 0)
                    {
                        query = query.Skip(dataStart).Take(dataCount);
                    }
                    var result = query.ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                exception = e;
            }
            return null;
        }

        public static UserInfo GetUserInfo(string userId, out Exception exception)
        {
            return GetItemInfo<UserInfo>("Id", userId, out exception);
        }

        public static UserInfo GetUserInfoByUserName(string userName, out Exception exception)
        {
            return GetItemInfo<UserInfo>("UserName", userName, out exception);
        }

        public static UserInfo GetUserInfo(string userName, string userPwd, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("UserName", userName),
                Restrictions.Eq("UserPwd", userPwd)
            };
            UserInfo userInfo = GetItemInfo<UserInfo>(critList, out exception);
            if (userInfo == null) return null;
            DateTime lastLogin = userInfo.LastLogin ?? Env.MinTime;
            userInfo.LastLogin = DateTime.Now;
            UpdateItem(userInfo, out exception);
            SysDataHistory loginRecord = new SysDataHistory
            {
                OperateType = "用户登录",
                DataType = "用户登录",
                OperateDesp = $"用户[{userName}]登录成功，姓名[{userInfo.RealName}]",
                OperateUser = userInfo.Id,
                OperateUserName = userInfo.RealName,
                OperateTime = DateTime.Now
            };
            DalSysDataHistory.SaveItem(loginRecord, out exception);
            userInfo.LastLogin = lastLogin;
            return userInfo;
        }

        public static UserInfo GetUserInfo(int pagingId, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("PagingId", pagingId)
            };
            UserInfo userInfo = GetItemInfo<UserInfo>(critList, out exception);
            if (userInfo == null) return null;
            DateTime lastLogin = userInfo.LastLogin ?? Env.MinTime;
            userInfo.LastLogin = DateTime.Now;
            UpdateItem(userInfo, out exception);
            userInfo.LastLogin = lastLogin;
            return userInfo;
        }

        public static string AddUserInfo(string userName, string password, string realName,
            string userTel, string userSex, DateTime birthDate, DateTime retireDate, string workCardCode,
            string identCardCode, string address, string comment, UserInfo adminInfo, out Exception exception)
        {
            string userId = Guid.NewGuid().ToString().ToUpper();
            UserInfo uiRecord = new UserInfo
            {
                Id = userId,
                UserName = userName,
                UserPwd = password,
                RealName = realName,
                SpellCode = Utilities.String.StringHelper.GetSpellCode(realName),
                UserTel = userTel,
                UserSex = userSex,
                BirthDate = birthDate,
                RetireDate = retireDate,
                WorkCardCode = workCardCode,
                IdentCardCode = identCardCode,
                Address = address,
                Comment = comment,
                LastChanged = DateTime.Now
            };
            int result = SaveItem(ref uiRecord, out exception);
            if (result <= 0) return "";
            SysDataHistory historyRecord = DalSysDataHistory.GenerateAddEntity(uiRecord, 
                "人员信息", adminInfo.Id, adminInfo.RealName);
            SaveItem(historyRecord, out exception);
            return uiRecord.Id;
        }

        public static int ModifyUserInfo(string userId, string userName, string password, string realName,
            string userTel, string userSex, DateTime birthDate, DateTime retireDate, string workCardCode,
            string identCardCode, string address, string comment, UserInfo adminInfo, out Exception exception)
        {
            List<TaskInfo> taskList = new List<TaskInfo>();
            UserInfo idRecord = GetUserInfo(userId, out exception);
            if (idRecord == null) return 0;
            var originRecord = idRecord.DeepCopy();
            idRecord.UserName = userName;
            if (!string.IsNullOrEmpty(password)) idRecord.UserPwd = password;
            idRecord.RealName = realName;
            idRecord.SpellCode = Utilities.String.StringHelper.GetSpellCode(realName);
            idRecord.UserTel = userTel;
            idRecord.UserSex = userSex;
            idRecord.BirthDate = birthDate;
            idRecord.RetireDate = retireDate;
            idRecord.WorkCardCode = workCardCode;
            idRecord.IdentCardCode = identCardCode;
            idRecord.Address = address;
            idRecord.Comment = comment;
            idRecord.LastChanged = DateTime.Now;
            taskList.Add(new TaskInfo(OperationType.Update, idRecord));
            SysDataHistory historyRecord = DalSysDataHistory.GenerateEditEntity(originRecord,
                idRecord, "人员信息", adminInfo.Id, adminInfo.RealName);
            taskList.Add(new TaskInfo(OperationType.Add, historyRecord));
            return ExecBatchTask(taskList, out exception);
        }

        public static int ModifyUserInfo(string userId, string pwdHash, string userTel,
            string operateUser, string operateUserName, out Exception exception)
        {
            List<TaskInfo> taskList = new List<TaskInfo>();
            UserInfo idRecord = GetUserInfo(userId, out exception);
            if (idRecord == null) return 0;
            var originRecord = idRecord.DeepCopy();
            if (!string.IsNullOrEmpty(pwdHash)) idRecord.UserPwd = pwdHash;
            idRecord.UserTel = userTel;
            idRecord.LastChanged = DateTime.Now;
            taskList.Add(new TaskInfo(OperationType.Update, idRecord));
            SysDataHistory historyRecord = DalSysDataHistory.GenerateEditEntity(originRecord,
                idRecord, "人员信息", operateUser, operateUserName);
            taskList.Add(new TaskInfo(OperationType.Add, historyRecord));
            return ExecBatchTask(taskList, out exception);
        }

        public static int UpdateUserInfo(UserInfo userInfo, out Exception exception)
        {
            return UpdateItem(userInfo, out exception);
        }

        public static int DeleteUserInfo(string userId, string operateUser, string operateUserName, out Exception exception)
        {
            List<TaskInfo> taskList = new List<TaskInfo>();
            var itemRecord = GetItemInfo("Id", userId, out exception);
            if (exception != null) return -200;
            taskList.Add(new TaskInfo(OperationType.Delete, itemRecord));
            SysDataHistory historyRecord = DalSysDataHistory.GenerateDelEntity(itemRecord,
                "人员信息", operateUser, operateUserName);
            taskList.Add(new TaskInfo(OperationType.Add, historyRecord));
            return ExecBatchTask(taskList, out exception);
        }
    }
}
