using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Domain.Server.Types;
using NHibernate;
using NHibernate.Criterion;
using NLog;
using Utilities.DbHelper;
using WebConsole.DAL.NhUtils;

namespace WebConsole.DAL
{
    /// <summary>
    /// By JHY
    /// </summary>
    public class DalSyncManager
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 获取变化数据
        /// </summary>
        /// <param name="tableType"></param>
        /// <param name="lastId"></param>
        /// <param name="dbTarget"></param>
        /// <returns></returns>
        public static DataSet GetChangedData(Type tableType, long lastId, NhTypes.DbTarget dbTarget)
        {
            try
            {
                var sessionFactory = NhControl.CreateSessionFactory(dbTarget);
                using (var session = sessionFactory.OpenSession())
                {
                    string idColumn = "";
                    Type idType = typeof(long);
                    PropertyInfo[] properties = tableType.GetProperties();
                    for (int i = 0; i < properties.Length; i++)
                    {
                        if (properties[i].Name.ToUpper().Equals("PAGINGID"))
                        {
                            idColumn = properties[i].Name;
                            idType = properties[i].PropertyType;
                            break;
                        }
                        if (properties[i].Name.ToUpper().Equals("ID"))
                        {
                            if (properties[i].PropertyType == typeof(int) ||
                                properties[i].PropertyType == typeof(long))
                            {
                                idColumn = properties[i].Name;
                                idType = properties[i].PropertyType;
                                break;
                            }
                        }
                    }
                    ICriteria pQuery = session.CreateCriteria(tableType);
                    if (idType == typeof(int))
                    {
                        pQuery = pQuery.Add(Restrictions.Ge(idColumn, (int)lastId));
                    }
                    else
                    {
                        pQuery = pQuery.Add(Restrictions.Ge(idColumn, lastId));
                    }
                    IList resultList = pQuery.List();
                    if (SqlDataHelper.IsDataValid(resultList))
                    {
                        return SqlDataHelper.ConvertToDataSet(tableType, resultList);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// 保存数据于服务端
        /// </summary>
        /// <param name="tableType"></param>
        /// <param name="infoSet"></param>
        /// <param name="dataOwner"></param>
        /// <param name="dbTarget"></param>
        /// <returns></returns>
        public static int SaveData(Type tableType, DataSet infoSet, string dataOwner, NhTypes.DbTarget dbTarget)
        {
            try
            {
                var sessionFactory = NhControl.CreateSessionFactory(dbTarget);
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        //添加及更新项目
                        for (int i = 0; i < infoSet.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr = infoSet.Tables[0].Rows[i];
                            object ci = null;
                            string clientId = infoSet.Tables[0].Rows[i]["Id"].ToString();
                            if (!string.IsNullOrEmpty(clientId) && clientId.Length > 32)
                            {
                                //GUID Mode
                                ci = GetItemById(session, tableType, clientId, out var hasError);
                                if (hasError)
                                {
                                    return -250;
                                }
                            }
                            if (ci != null)
                            {
                                int updResult = UpdateItem(session, tableType, ci, dr);
                                if (updResult <= 0) return -210;
                            }
                            else
                            {
                                int addResult = AddItem(session, tableType, dr, dataOwner);
                                if (addResult <= 0) return -220;
                            }
                        }
                        transaction.Commit();
                        return infoSet.Tables[0].Rows.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return -200;
        }

        /// <summary>
        /// 以ID获取项目信息
        /// </summary>
        /// <param name="session"></param>
        /// <param name="tableType"></param>
        /// <param name="serverId"></param>
        /// <param name="hasError"></param>
        /// <returns></returns>
        public static object GetItemById(ISession session, Type tableType, string serverId, out bool hasError)
        {
            hasError = false;
            try
            {
                ICriteria pQuery = session.CreateCriteria(tableType)
                    .Add(Restrictions.Eq("Id", serverId));
                IList itemList = pQuery.List();
                if (SqlDataHelper.IsDataValid(itemList))
                {
                    return itemList[0];
                }
            }
            catch (Exception ex)
            {
                hasError = true;
                Logger.Error(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// 添加项目信息
        /// </summary>
        /// <param name="session"></param>
        /// <param name="tableType"></param>
        /// <param name="newInfo"></param>
        /// <param name="dataOwner"></param>
        /// <returns></returns>
        private static int AddItem(ISession session, Type tableType, DataRow newInfo, string dataOwner)
        {
            try
            {
                object itemInstance = tableType.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
                PropertyInfo[] properties = tableType.GetProperties();
                if (properties.Length > 0)
                {
                    for (int i = 0; i < properties.Length; i++)
                    {
                        if (properties[i].Name.Equals("SyncColumn"))
                        {
                            continue;
                        }
                        if (properties[i].Name.Equals("LastChanged"))
                        {
                            properties[i].SetValue(itemInstance, DateTime.Now, null);
                            continue;
                        }
                        if (properties[i].Name.ToUpper().Equals("DATAOWNER"))
                        {
                            properties[i].SetValue(itemInstance, dataOwner, null);
                            continue;
                        }
                        if (newInfo.Table.Columns.Contains(properties[i].Name))
                        {
                            try
                            {
                                if (newInfo[properties[i].Name] is long && properties[i].PropertyType == typeof(int))
                                {
                                    properties[i].SetValue(itemInstance, Convert.ToInt32(newInfo[properties[i].Name]), null);
                                }
                                else if (newInfo[properties[i].Name] is long && properties[i].PropertyType == typeof(short))
                                {
                                    properties[i].SetValue(itemInstance, Convert.ToInt16(newInfo[properties[i].Name]), null);
                                }
                                else if (newInfo[properties[i].Name] is double && properties[i].PropertyType == typeof(float))
                                {
                                    properties[i].SetValue(itemInstance, Convert.ToSingle(newInfo[properties[i].Name]), null);
                                }
                                else
                                {
                                    properties[i].SetValue(itemInstance, newInfo[properties[i].Name], null);
                                }
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }
                    }
                }
                session.SaveOrUpdate(itemInstance);
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return -200;
        }

        /// <summary>
        /// 更新项目信息
        /// </summary>
        /// <param name="session"></param>
        /// <param name="tableType"></param>
        /// <param name="originInfo"></param>
        /// <param name="newInfo"></param>
        /// <returns></returns>
        private static int UpdateItem(ISession session, Type tableType, object originInfo, DataRow newInfo)
        {
            try
            {
                bool partialUpdate = false;
                List<string> columnList = new List<string>();
                if (newInfo.Table.Columns.Contains("SyncColumn"))
                {
                    partialUpdate = true;
                    string targetColumn = newInfo["SyncColumn"].ToString();
                    if (string.IsNullOrWhiteSpace(targetColumn)) return 1;
                    string []columnArray = targetColumn.TrimEnd(',').Split(',');
                    for (int i = 0; i < columnArray.Length; i++)
                    {
                        columnList.Add(columnArray[i].Substring(1, columnArray[i].Length - 2));
                    }
                }
                PropertyInfo[] properties = tableType.GetProperties();
                if (properties.Length > 0)
                {
                    for (int i = 0; i < properties.Length; i++)
                    {
                        if (properties[i].Name.Equals("LastChanged"))
                        {
                            //记录更新时间
                            properties[i].SetValue(originInfo, DateTime.Now, null);
                            continue;
                        }
                        if (partialUpdate && !columnList.Contains(properties[i].Name))
                        {
                            //局部更新判定
                            continue;
                        }
                        if (properties[i].Name.ToUpper().Equals("ID"))
                        {
                            continue;
                        }
                        if (newInfo.Table.Columns.Contains(properties[i].Name))
                        {
                            try
                            {
                                if (newInfo[properties[i].Name] is long && properties[i].PropertyType == typeof(int))
                                {
                                    properties[i].SetValue(originInfo, Convert.ToInt32(newInfo[properties[i].Name]), null);
                                }
                                else if (newInfo[properties[i].Name] is long && properties[i].PropertyType == typeof(short))
                                {
                                    properties[i].SetValue(originInfo, Convert.ToInt16(newInfo[properties[i].Name]), null);
                                }
                                else if (newInfo[properties[i].Name] is double && properties[i].PropertyType == typeof(float))
                                {
                                    properties[i].SetValue(originInfo, Convert.ToSingle(newInfo[properties[i].Name]), null);
                                }
                                else
                                {
                                    properties[i].SetValue(originInfo, newInfo[properties[i].Name], null);
                                }
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }
                    }
                }
                session.SaveOrUpdate(originInfo);
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return -200;
        }
    }
}
