using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Domain.Main.Types;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using NLog;
using Utilities.DbHelper;

namespace CabinetMgr.DAL.NhUtils
{
    public class FlexNhBase<TG>
    {
        private static readonly Logger CsLogger = LogManager.GetCurrentClassLogger();

        //如需指定Domain的对应数据库，将下面注释的代码插入对应Domain文件中，并修改NhControl.cs文件
        //private readonly NhTypes.DbTarget DbTarget = NhTypes.DbTarget.YourTarget;
        private static int GetDbTarget(Type tableType, out NhTypes.DbTarget dbTarget)
        {
            dbTarget = 0;
            object instance = Activator.CreateInstance(tableType);
            FieldInfo pi = tableType.GetField("DbTarget", BindingFlags.NonPublic | BindingFlags.Instance);
            if (pi == null)
            {
                return -1;
            }
            dbTarget = (NhTypes.DbTarget)pi.GetValue(instance);
            return 1;
        }

        /// <summary>
        /// 查询信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criterionList"></param>
        /// <param name="orderList"></param>
        /// <param name="dataStart"></param>
        /// <param name="dataCount"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static IList<T> SearchItem<T>(IList<AbstractCriterion> criterionList, List<Order> orderList,
            int dataStart, int dataCount, out Exception exception)
        {
            return SearchItemEx<T>(criterionList, orderList, null, null, dataStart, dataCount, out exception);
        }

        /// <summary>
        /// 查询信息
        /// </summary>
        /// <param name="criterionList"></param>
        /// <param name="orderList"></param>
        /// <param name="dataStart"></param>
        /// <param name="dataCount"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static IList<TG> SearchItem(IList<AbstractCriterion> criterionList, List<Order> orderList,
            int dataStart, int dataCount, out Exception exception)
        {
            return SearchItemEx<TG>(criterionList, orderList, null, null, dataStart, dataCount, out exception);
        }

        /// <summary>
        /// 查询信息，额外支持FetchSettings/ResultTransformer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criterionList"></param>
        /// <param name="orderList"></param>
        /// <param name="fetchMode"></param>
        /// <param name="resultTransformer"></param>
        /// <param name="dataStart"></param>
        /// <param name="dataCount"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static IList<T> SearchItemEx<T>(IList<AbstractCriterion> criterionList, List<Order> orderList,
            FetchSettings fetchMode, IResultTransformer resultTransformer,
            int dataStart, int dataCount, out Exception exception)
        {
            exception = null;
            try
            {
                GetDbTarget(typeof(T), out var dbTarget);
                var sessionFactory = NhControl.CreateSessionFactory(dbTarget);
                using (var session = sessionFactory.OpenSession(new NhControl.SqlWatcher()))
                {
                    ICriteria pQuery = session.CreateCriteria(typeof(T));
                    if (criterionList != null && criterionList.Count > 0)
                    {
                        for (int i = 0; i < criterionList.Count; i++)
                        {
                            if (criterionList[i] is SimpleExpression)
                            {
                                string entityName = ((SimpleExpression)criterionList[i]).PropertyName;
                                if (entityName.Contains("."))
                                {
                                    string aliasName = entityName.Substring(0, entityName.IndexOf(".", StringComparison.Ordinal));
                                    pQuery.CreateAlias(aliasName, aliasName);
                                }
                            }
                            pQuery = pQuery.Add(criterionList[i]);
                        }
                    }
                    if (orderList != null && orderList.Count > 0)
                    {
                        for (int i = 0; i < orderList.Count; i++)
                        {
                            pQuery = pQuery.AddOrder(orderList[i]);
                        }
                    }
                    if (fetchMode != null)
                    {
                        pQuery = pQuery.SetFetchMode(fetchMode.AssocPath, fetchMode.AssocFetchMode);
                    }

                    if (dataCount == -1) return pQuery.List<T>();
                    if (resultTransformer != null)
                    {
                        pQuery = pQuery.SetResultTransformer(resultTransformer);
                        var resultList = pQuery.List<T>();
                        return resultList.Skip(dataStart).Take(dataCount).ToList();
                    }
                    pQuery = pQuery.SetFirstResult(dataStart)
                        .SetMaxResults(dataCount);
                    return pQuery.List<T>();
                }
            }
            catch (Exception ex)
            {
                CsLogger.Error(ex);
                exception = ex;
            }
            return null;
        }

        /// <summary>
        /// 查询信息，额外支持FetchSettings/ResultTransformer
        /// </summary>
        /// <param name="criterionList"></param>
        /// <param name="orderList"></param>
        /// <param name="fetchMode"></param>
        /// <param name="resultTransformer"></param>
        /// <param name="dataStart"></param>
        /// <param name="dataCount"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static IList<TG> SearchItemEx(IList<AbstractCriterion> criterionList, List<Order> orderList,
            FetchSettings fetchMode, IResultTransformer resultTransformer,
            int dataStart, int dataCount, out Exception exception)
        {
            return SearchItemEx<TG>(criterionList, orderList, fetchMode, resultTransformer, dataStart, dataCount,
                out exception);
        }

        /// <summary>
        /// 查询信息,Disjunction方式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="disjunction"></param>
        /// <param name="orderList"></param>
        /// <param name="dataStart"></param>
        /// <param name="dataCount"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static IList<T> SearchItemByDisjunction<T>(Disjunction disjunction, List<Order> orderList,
        int dataStart, int dataCount, out Exception exception)
        {
            return SearchItemByDisjunction<T>(disjunction, orderList, null, null, dataStart, dataCount, out exception);
        }

        /// <summary>
        /// 查询信息,Disjunction方式
        /// </summary>
        /// <param name="disjunction"></param>
        /// <param name="orderList"></param>
        /// <param name="dataStart"></param>
        /// <param name="dataCount"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static IList<TG> SearchItemByDisjunction(Disjunction disjunction, List<Order> orderList,
            int dataStart, int dataCount, out Exception exception)
        {
            return SearchItemByDisjunction<TG>(disjunction, orderList, null, null, dataStart, dataCount, out exception);
        }

        /// <summary>
        /// 查询信息,Disjunction方式,额外支持FetchSettings/ResultTransformer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="disjunction"></param>
        /// <param name="orderList"></param>
        /// <param name="fetchMode"></param>
        /// <param name="resultTransformer"></param>
        /// <param name="dataStart"></param>
        /// <param name="dataCount"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static IList<T> SearchItemByDisjunction<T>(Disjunction disjunction, List<Order> orderList,
            FetchSettings fetchMode, IResultTransformer resultTransformer,
            int dataStart, int dataCount, out Exception exception)
        {
            exception = null;
            try
            {
                GetDbTarget(typeof(T), out var dbTarget);
                var sessionFactory = NhControl.CreateSessionFactory(dbTarget);
                using (var session = sessionFactory.OpenSession())
                {
                    ICriteria pQuery = session.CreateCriteria(typeof(T));
                    if (dataCount != -1)
                    {
                        pQuery = pQuery.SetFirstResult(dataStart)
                            .SetMaxResults(dataCount);
                    }
                    if (disjunction != null)
                    {
                        pQuery = pQuery.Add(disjunction);
                    }
                    if (orderList != null && orderList.Count > 0)
                    {
                        for (int i = 0; i < orderList.Count; i++)
                        {
                            pQuery = pQuery.AddOrder(orderList[i]);
                        }
                    }
                    if (fetchMode != null)
                    {
                        pQuery = pQuery.SetFetchMode(fetchMode.AssocPath, fetchMode.AssocFetchMode);
                    }

                    if (resultTransformer != null)
                    {
                        pQuery = pQuery.SetResultTransformer(resultTransformer);
                    }
                    return pQuery.List<T>();
                }
            }
            catch (Exception ex)
            {
                CsLogger.Error(ex);
                exception = ex;
            }
            return null;
        }


        /// <summary>
        /// 查询信息,Disjunction方式,额外支持FetchSettings/ResultTransformer
        /// </summary>
        /// <param name="disjunction"></param>
        /// <param name="orderList"></param>
        /// <param name="fetchMode"></param>
        /// <param name="resultTransformer"></param>
        /// <param name="dataStart"></param>
        /// <param name="dataCount"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static IList<TG> SearchItemByDisjunction(Disjunction disjunction, List<Order> orderList,
            FetchSettings fetchMode, IResultTransformer resultTransformer,
            int dataStart, int dataCount, out Exception exception)
        {
            return SearchItemByDisjunction<TG>(disjunction, orderList, fetchMode, resultTransformer,
                dataStart, dataCount, out exception);
        }

        /// <summary>
        /// 获取信息计数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criterionList"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static int GetItemCount<T>(IList<AbstractCriterion> criterionList, out Exception exception)
        {
            exception = null;
            try
            {
                GetDbTarget(typeof(T), out var dbTarget);
                var sessionFactory = NhControl.CreateSessionFactory(dbTarget);
                using (var session = sessionFactory.OpenSession())
                {
                    ICriteria pQuery = session.CreateCriteria(typeof(T));
                    if (criterionList != null && criterionList.Count > 0)
                    {
                        for (int i = 0; i < criterionList.Count; i++)
                        {
                            pQuery = pQuery.Add(criterionList[i]);
                        }
                    }
                    return (int)pQuery.SetProjection(Projections.RowCount()).UniqueResult();
                }
            }
            catch (Exception ex)
            {
                CsLogger.Error(ex);
                exception = ex;
            }
            return -200;
        }

        /// <summary>
        /// 获取信息计数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criterionList"></param>
        /// <param name="fetchMode"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static int GetItemCountEx<T>(IList<AbstractCriterion> criterionList, FetchSettings fetchMode, out Exception exception)
        {
            exception = null;
            try
            {
                GetDbTarget(typeof(T), out var dbTarget);
                var sessionFactory = NhControl.CreateSessionFactory(dbTarget);
                using (var session = sessionFactory.OpenSession())
                {
                    ICriteria pQuery = session.CreateCriteria(typeof(T));
                    if (criterionList != null && criterionList.Count > 0)
                    {
                        for (int i = 0; i < criterionList.Count; i++)
                        {
                            if (criterionList[i] is SimpleExpression)
                            {
                                string entityName = ((SimpleExpression)criterionList[i]).PropertyName;
                                if (entityName.Contains("."))
                                {
                                    string aliasName = entityName.Substring(0, entityName.IndexOf(".", StringComparison.Ordinal));
                                    pQuery.CreateAlias(aliasName, aliasName);
                                }
                            }
                            pQuery = pQuery.Add(criterionList[i]);
                        }
                    }
                    if (fetchMode != null)
                    {
                        pQuery = pQuery.SetFetchMode(fetchMode.AssocPath, fetchMode.AssocFetchMode);
                    }
                    return (int)pQuery.SetProjection(Projections.RowCount()).UniqueResult();
                }
            }
            catch (Exception ex)
            {
                CsLogger.Error(ex);
                exception = ex;
            }
            return -200;
        }

        /// <summary>
        /// 获取信息计数
        /// </summary>
        /// <param name="criterionList"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static int GetItemCount(IList<AbstractCriterion> criterionList, out Exception exception)
        {
            return GetItemCount<TG>(criterionList, out exception);
        }

        /// <summary>
        /// 查找单条信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="targetColumn"></param>
        /// <param name="inputValue"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static T GetItemInfo<T>(string targetColumn, object inputValue, out Exception exception)
        {
            IList<AbstractCriterion> critList = new List<AbstractCriterion>()
            {
                Restrictions.Eq(targetColumn, inputValue)
            };
            return GetItemInfo<T>(critList, out exception);
        }

        /// <summary>
        /// 查找单条信息
        /// </summary>
        /// <param name="targetColumn"></param>
        /// <param name="inputValue"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static TG GetItemInfo(string targetColumn, object inputValue, out Exception exception)
        {
            return GetItemInfo<TG>(targetColumn, inputValue, out exception);
        }

        /// <summary>
        /// 查找单条信息,支持多查询条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criterionList"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static T GetItemInfo<T>(IList<AbstractCriterion> criterionList, out Exception exception)
        {
            IList<T> resultList = SearchItem<T>(criterionList, null, 0, -1, out exception);
            if (!SqlDataHelper.IsDataValid(resultList)) return default(T);
            return resultList[0];
        }

        /// <summary>
        /// 查找单条信息,支持多查询条件
        /// </summary>
        /// <param name="criterionList"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static TG GetItemInfo(IList<AbstractCriterion> criterionList, out Exception exception)
        {
            return GetItemInfo<TG>(criterionList, out exception);
        }

        /// <summary>
        /// 获取简单统计数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criterionList"></param>
        /// <param name="groupName"></param>
        /// <param name="summaryType"></param>
        /// <param name="summaryEntity"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static IList GetSimpleGroupStatistics<T>(IList<AbstractCriterion> criterionList,
            string groupName, SummaryType summaryType, string summaryEntity, out Exception exception)
        {
            exception = null;
            try
            {
                GetDbTarget(typeof(T), out var dbTarget);
                var sessionFactory = NhControl.CreateSessionFactory(dbTarget);
                using (var session = sessionFactory.OpenSession())
                {
                    ICriteria pQuery = session.CreateCriteria(typeof(T));
                    if (criterionList != null && criterionList.Count > 0)
                    {
                        for (int i = 0; i < criterionList.Count; i++)
                        {
                            pQuery = pQuery.Add(criterionList[i]);
                        }
                    }
                    if (groupName.Contains("."))
                    {
                        string aliasName = groupName.Substring(0, groupName.IndexOf(".", StringComparison.Ordinal));
                        pQuery.CreateAlias(aliasName, aliasName);
                    }
                    ProjectionList reqProjections =
                        Projections.ProjectionList().Add(Projections.GroupProperty(groupName).As(groupName));
                    switch (summaryType)
                    {
                        case SummaryType.RowCount:
                            reqProjections = reqProjections.Add(Projections.RowCount());
                            break;
                        case SummaryType.Sum:
                            reqProjections = reqProjections.Add(Projections.Sum(summaryEntity));
                            break;
                        case SummaryType.Avg:
                            reqProjections = reqProjections.Add(Projections.Avg(summaryEntity));
                            break;
                        case SummaryType.Max:
                            reqProjections = reqProjections.Add(Projections.Max(summaryEntity));
                            break;
                        case SummaryType.Min:
                            reqProjections = reqProjections.Add(Projections.Min(summaryEntity));
                            break;
                    }
                    return pQuery.SetProjection(reqProjections).List();
                }
            }
            catch (Exception ex)
            {
                CsLogger.Error(ex);
                exception = ex;
            }
            return null;
        }

        /// <summary>
        /// 获取简单统计数据
        /// </summary>
        /// <param name="criterionList"></param>
        /// <param name="groupName"></param>
        /// <param name="summaryType"></param>
        /// <param name="summaryEntity"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static IList GetSimpleGroupStatistics(IList<AbstractCriterion> criterionList,
            string groupName, SummaryType summaryType, string summaryEntity, out Exception exception)
        {
            return GetSimpleGroupStatistics<TG>(criterionList, groupName, summaryType, summaryEntity, out exception);
        }

        /// <summary>
        /// 自定义统计查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criterionList"></param>
        /// <param name="projectionList"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static IList GetCustomStatistics<T>(IList<AbstractCriterion> criterionList,
            ProjectionList projectionList, out Exception exception)
        {
            exception = null;
            try
            {
                GetDbTarget(typeof(T), out var dbTarget);
                var sessionFactory = NhControl.CreateSessionFactory(dbTarget);
                using (var session = sessionFactory.OpenSession())
                {
                    ICriteria pQuery = session.CreateCriteria(typeof(T));
                    if (criterionList != null && criterionList.Count > 0)
                    {
                        for (int i = 0; i < criterionList.Count; i++)
                        {
                            pQuery = pQuery.Add(criterionList[i]);
                        }
                    }
                    return pQuery.SetProjection(projectionList).List();
                }
            }
            catch (Exception ex)
            {
                CsLogger.Error(ex);
                exception = ex;
            }
            return null;
        }

        /// <summary>
        /// 自定义统计查询
        /// </summary>
        /// <param name="criterionList"></param>
        /// <param name="projectionList"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static IList GetCustomStatistics(IList<AbstractCriterion> criterionList,
            ProjectionList projectionList, out Exception exception)
        {
            return GetCustomStatistics<TG>(criterionList, projectionList, out exception);
        }

        /// <summary>
        /// 存储信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemInfo"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static int SaveItem<T>(T itemInfo, out Exception exception)
        {
            return SaveItem(ref itemInfo, out exception);
        }

        /// <summary>
        /// 存储信息
        /// </summary>
        /// <param name="itemInfo"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static int SaveItem(TG itemInfo, out Exception exception)
        {
            return SaveItem(ref itemInfo, out exception);
        }

        /// <summary>
        /// 存储信息,可导出存储结果(一般用于获取自动生成的ID)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemInfo"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static int SaveItem<T>(ref T itemInfo, out Exception exception)
        {
            exception = null;
            try
            {
                GetDbTarget(typeof(T), out var dbTarget);
                var sessionFactory = NhControl.CreateSessionFactory(dbTarget);
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Save(itemInfo);
                        transaction.Commit();
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                CsLogger.Error(ex);
                exception = ex;
            }
            return -200;
        }

        /// <summary>
        /// 存储信息,可导出存储结果(一般用于获取自动生成的ID)
        /// </summary>
        /// <param name="itemInfo"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static int SaveItem(ref TG itemInfo, out Exception exception)
        {
            return SaveItem<TG>(ref itemInfo, out exception);
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemInfo"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static int UpdateItem<T>(T itemInfo, out Exception exception)
        {
            exception = null;
            try
            {
                if (itemInfo == null) return 0;
                GetDbTarget(typeof(T), out var dbTarget);
                var sessionFactory = NhControl.CreateSessionFactory(dbTarget);
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Update(itemInfo);
                        transaction.Commit();
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                CsLogger.Error(ex);
                exception = ex;
            }
            return -200;
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="itemInfo"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static int UpdateItem(TG itemInfo, out Exception exception)
        {
            return UpdateItem<TG>(itemInfo, out exception);
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="targetColumn"></param>
        /// <param name="inputValue"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static int DeleteItem<T>(string targetColumn, object inputValue, out Exception exception)
        {
            exception = null;
            try
            {
                T itemRecord = GetItemInfo<T>(targetColumn, inputValue, out exception);
                if (exception != null) throw exception;
                if (itemRecord == null) return 0;
                GetDbTarget(typeof(T), out var dbTarget);
                var sessionFactory = NhControl.CreateSessionFactory(dbTarget);
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Delete(itemRecord);
                        transaction.Commit();
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                CsLogger.Error(ex);
                exception = ex;
            }
            return -200;
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="targetColumn"></param>
        /// <param name="inputValue"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static int DeleteItem(string targetColumn, object inputValue, out Exception exception)
        {
            return DeleteItem<TG>(targetColumn, inputValue, out exception);
        }

        /// <summary>
        /// 删除信息,支持多查询条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criterionList"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static int DeleteItem<T>(IList<AbstractCriterion> criterionList, out Exception exception)
        {
            exception = null;
            try
            {
                GetDbTarget(typeof(T), out var dbTarget);
                var sessionFactory = NhControl.CreateSessionFactory(dbTarget);
                using (var session = sessionFactory.OpenSession())
                {
                    ICriteria pQuery = session.CreateCriteria(typeof(T));
                    if (criterionList != null && criterionList.Count > 0)
                    {
                        for (int i = 0; i < criterionList.Count; i++)
                        {
                            pQuery = pQuery.Add(criterionList[i]);
                        }
                    }
                    IList<T> resultList = pQuery.List<T>();
                    if (resultList.Count == 0) return 0;
                    using (var transaction = session.BeginTransaction())
                    {
                        for (int i = 0; i < resultList.Count; i++)
                        {
                            session.Delete(resultList[i]);
                        }
                        transaction.Commit();
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                CsLogger.Error(ex);
                exception = ex;
            }
            return -1;
        }

        /// <summary>
        /// 删除信息,支持多查询条件
        /// </summary>
        /// <param name="criterionList"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static int DeleteItem(IList<AbstractCriterion> criterionList, out Exception exception)
        {
            return DeleteItem<TG>(criterionList, out exception);
        }

        /// <summary>
        /// 删除多条信息(根据实体)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemList"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static int DeleteItem<T>(IList<T> itemList, out Exception exception)
        {
            exception = null;
            try
            {
                GetDbTarget(typeof(T), out var dbTarget);
                var sessionFactory = NhControl.CreateSessionFactory(dbTarget);
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        for (int i = 0; i < itemList.Count; i++)
                        {
                            session.Delete(itemList[i]);
                        }
                        transaction.Commit();
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                CsLogger.Error(ex);
                exception = ex;
            }
            return -200;
        }

        /// <summary>
        /// 删除多条信息(根据实体)
        /// </summary>
        /// <param name="itemList"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static int DeleteItem(IList<TG> itemList, out Exception exception)
        {
            return DeleteItem<TG>(itemList, out exception);
        }

        /// <summary>
        /// 自定义查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryCmd"></param>
        /// <param name="paraList"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static DataSet ExecQuery<T>(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            exception = null;
            try
            {
                GetDbTarget(typeof(T), out var dbTarget);
                var sessionFactory = NhControl.CreateSessionFactory(dbTarget);
                using (var session = sessionFactory.OpenSession())
                {
                    IDbCommand command = session.Connection.CreateCommand();
                    command.CommandText = queryCmd;
                    SqlDataAdapter da = new SqlDataAdapter(command as SqlCommand);
                    if (paraList != null)
                    {
                        foreach (DbParameter parm in paraList)
                            command.Parameters.Add(parm);
                    }
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                CsLogger.Error(ex);
                exception = ex;
            }
            return null;
        }

        /// <summary>
        /// 自定义查询
        /// </summary>
        /// <param name="queryCmd"></param>
        /// <param name="paraList"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static DataSet ExecQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return ExecQuery<TG>(queryCmd, paraList, out exception);
        }

        /// <summary>
        /// 获取Session(注意释放Session)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static ISession GetSession<T>(out Exception exception)
        {
            exception = null;
            try
            {
                GetDbTarget(typeof(T), out var dbTarget);
                var sessionFactory = NhControl.CreateSessionFactory(dbTarget);
                return sessionFactory.OpenSession();
            }
            catch (Exception ex)
            {
                CsLogger.Error(ex);
                exception = ex;
            }
            return null;
        }

        /// <summary>
        /// 执行批量任务
        /// </summary>
        /// <param name="taskList"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static int ExecBatchTask(IList<TaskInfo> taskList, out Exception exception)
        {
            exception = null;
            if (!SqlDataHelper.IsDataValid(taskList)) return 0;
            try
            {
                object taskObj = taskList[0].TaskObj;
                GetDbTarget(taskObj.GetType(), out var dbTarget);
                var sessionFactory = NhControl.CreateSessionFactory(dbTarget);
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        for (int i = 0; i < taskList.Count; i++)
                        {
                            switch (taskList[i].Operation)
                            {
                                case OperationType.Add:
                                    session.Save(taskList[i].TaskObj);
                                    break;
                                case OperationType.Update:
                                    session.Update(taskList[i].TaskObj);
                                    break;
                                case OperationType.Delete:
                                    session.Delete(taskList[i].TaskObj);
                                    break;
                            }
                        }
                        transaction.Commit();
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                CsLogger.Error(ex);
                exception = ex;
            }
            return -1;
        }

        public class FetchSettings
        {
            public string AssocPath;
            public FetchMode AssocFetchMode;

            public FetchSettings(string path, FetchMode fetchMode)
            {
                AssocPath = path;
                AssocFetchMode = fetchMode;
            }
        }

        public enum OperationType
        {
            /// <summary>
            /// 用于批量任务，指示任务类型为新增
            /// </summary>
            Add,
            /// <summary>
            /// 用于批量任务，指示任务类型为更新
            /// </summary>
            Update,
            /// <summary>
            /// 用于批量任务，指示任务类型为删除
            /// </summary>
            Delete
        }

        public enum SummaryType
        {
            /// <summary>
            /// 用于统计,请求计算行数
            /// </summary>
            RowCount,
            /// <summary>
            /// 用于统计,请求计算总和
            /// </summary>
            Sum,
            /// <summary>
            /// 用于统计,请求计算均值
            /// </summary>
            Avg,
            /// <summary>
            /// 用于统计,请求计算最大值
            /// </summary>
            Max,
            /// <summary>
            /// 用于统计,请求计算最小值
            /// </summary>
            Min
        }

        /// <summary>
        /// 用于批量任务，存储单条任务信息
        /// </summary>
        public class TaskInfo
        {
            public OperationType Operation;
            public object TaskObj;

            public TaskInfo(OperationType operationType, object taskObj)
            {
                Operation = operationType;
                TaskObj = taskObj;
            }
        }
    }
}
