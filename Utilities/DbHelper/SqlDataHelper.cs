using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Utilities.DbHelper
{
    public class SqlDataHelper
    {
        public static bool IsJsonDataValid(JArray ds)
        {
            if (ds != null && ds.Count != 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsDataValid(DataSet ds)
        {
            if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsDataValid(IList ls)
        {
            if (ls != null && ls.Count > 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsDataValid<T>(IList<T> ls)
        {
            if (ls != null && ls.Count > 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsDataValid(ArrayList ls)
        {
            if (ls != null && ls.Count > 0)
            {
                return true;
            }
            return false;
        }

        public static string GetHbComment(PropertyInfo itemProp)
        {
            var attr = itemProp.GetCustomAttributes(false);
            for (int i = 0; i < attr.Length; i++)
            {
                if (attr[i] is HbAnnotations)
                {
                    return ((HbAnnotations)attr[i]).ValDesp;
                }
            }
            return null;
        }

        public static string GetHbComment(Type itemType)
        {
            var attr = itemType.GetCustomAttributes(false);
            for (int i = 0; i < attr.Length; i++)
            {
                if (attr[i] is HbAnnotations)
                {
                    return ((HbAnnotations)attr[i]).ValDesp;
                }
            }
            if (!(itemType.BaseType == typeof(object)))
            {
                itemType = itemType.BaseType;
                attr = itemType.GetCustomAttributes(false);
                for (int i = 0; i < attr.Length; i++)
                {
                    if (attr[i] is HbAnnotations)
                    {
                        return ((HbAnnotations)attr[i]).ValDesp;
                    }
                }
            }
            return null;
        }

        public static DomainAnnotations GetDomainAnnotations(Type itemType)
        {
            var attr = itemType.GetCustomAttributes(false);
            if (attr.Length > 0)
            {
                for (int i = 0; i < attr.Length; i++)
                {
                    if (attr[i] is DomainAnnotations hbAttr) return (DomainAnnotations)attr[i];
                }
            }
            return null;
        }

        public static int DataRowToTargetItem<T>(DataRow dr, ref T target)
        {
            try
            {
                Type configType = target.GetType();
                //检测注解
                Hashtable columnMap = new Hashtable();
                //检测注解
                PropertyInfo[] info = typeof(T).GetProperties();
                foreach (PropertyInfo var in info)
                {
                    Object[] attr = var.GetCustomAttributes(false);
                    if (attr.Length > 0)
                    {
                        SqlAnnotations myattr = attr[0] as SqlAnnotations;
                        if (myattr?.ColumnMapping != null)
                        {
                            columnMap[myattr.ColumnMapping] = var.Name;
                        }
                    }
                }
                //数值填充
                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    string columnName = dr.Table.Columns[i].ColumnName;
                    if (columnMap[columnName] != null) columnName = (string)columnMap[columnName];
                    PropertyInfo property = configType.GetProperty(columnName);
                    if (property != null)
                    {
                        if (property.PropertyType == typeof(int))
                        {
                            property.SetValue(target, (int)dr[dr.Table.Columns[i].ColumnName], null);
                        }
                        else if (property.PropertyType == typeof(float))
                        {
                            property.SetValue(target, float.Parse(dr[dr.Table.Columns[i].ColumnName].ToString()), null);
                        }
                        else if (property.PropertyType == typeof(double))
                        {
                            property.SetValue(target, double.Parse(dr[dr.Table.Columns[i].ColumnName].ToString()), null);
                        }
                        else if (property.PropertyType == typeof(DateTime))
                        {
                            property.SetValue(target, (DateTime)dr[dr.Table.Columns[i].ColumnName], null);
                        }
                        else if (property.PropertyType == typeof(string))
                        {
                            property.SetValue(target, dr[dr.Table.Columns[i].ColumnName].ToString(), null);
                        }
                    }
                }
                return 1;
            }
            catch (Exception)
            {
                // ignored
            }
            return -500;
        }

        /// DataSet装换为泛型集合 
        /// <typeparam name="T"></typeparam> 
        /// <param name="pDataSet">DataSet</param> 
        /// <param name="pTableIndex">待转换数据表索引</param> 
        /// <returns></returns> 
        public static IList<T> DataSetToIList<T>(DataSet pDataSet, int pTableIndex)
        {
            if (pDataSet == null || pDataSet.Tables.Count < 0)
                return null;
            if (pTableIndex > pDataSet.Tables.Count - 1)
                return null;
            if (pTableIndex < 0)
                pTableIndex = 0;

            Hashtable columnMap = new Hashtable();
            //检测注解
            PropertyInfo[] info = typeof(T).GetProperties();
            foreach (PropertyInfo var in info)
            {
                Object[] attr = var.GetCustomAttributes(false);
                if (attr.Length > 0)
                {
                    SqlAnnotations myattr = attr[0] as SqlAnnotations;
                    if (myattr?.ColumnMapping != null)
                    {
                        columnMap[var.Name] = myattr.ColumnMapping;
                    }
                }
            }
            DataTable pData = pDataSet.Tables[pTableIndex];
            // 返回值初始化 
            IList<T> result = new List<T>();
            for (int j = 0; j < pData.Rows.Count; j++)
            {
                T t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    string columnName = pi.Name;
                    if (columnMap[pi.Name] != null) columnName = (string)columnMap[pi.Name];
                    for (int i = 0; i < pData.Columns.Count; i++)
                    {
                        // 属性与字段名称一致的进行赋值 
                        if (columnName.Equals(pData.Columns[i].ColumnName))
                        {
                            // 数据库NULL值单独处理 
                            if (pData.Rows[j][i] != DBNull.Value)
                            {
                                if (pData.Rows[j][i] is long && pi.PropertyType == typeof(int))
                                {
                                    pi.SetValue(t, Convert.ToInt32(pData.Rows[j][i]), null);
                                }
                                else if (pData.Rows[j][i] is long && pi.PropertyType == typeof(short))
                                {
                                    pi.SetValue(t, Convert.ToInt16(pData.Rows[j][i]), null);
                                }
                                else if (pData.Rows[j][i] is double && pi.PropertyType == typeof(float))
                                {
                                    pi.SetValue(t, Convert.ToInt16(pData.Rows[j][i]), null);
                                }
                                else if (pData.Rows[j][i] is string && pi.PropertyType == typeof(DateTime))
                                {
                                    pi.SetValue(t, DateTime.Parse((string)pData.Rows[j][i]), null);
                                }
                                else if (pData.Rows[j][i] is string && pi.PropertyType == typeof(bool))
                                {
                                    if (!string.IsNullOrEmpty(pData.Rows[j][i].ToString().Trim()))
                                    {
                                        pi.SetValue(t, bool.Parse((string)pData.Rows[j][i]), null);
                                    }
                                    else
                                        pi.SetValue(t, false, null);
                                }
                                else
                                {
                                    pi.SetValue(t, pData.Rows[j][i], null);
                                }
                            }
                            else
                            {
                                pi.SetValue(t, null, null);
                            }
                            break;
                        }
                    }
                }
                result.Add(t);
            }
            return result;
        }

        /// <summary>
        /// Ilist 转换成 DataSet
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataSet ConvertToDataSet<T>(IList list)
        {
            if (list == null || list.Count <= 0)
            {
                return null;
            }
            DataSet ds = new DataSet();
            DataTable dt = new DataTable(typeof(T).Name);
            DataColumn column;
            DataRow row;
            PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (T t in list)
            {
                if (t == null)
                {
                    continue;
                }
                row = dt.NewRow();
                for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
                {
                    PropertyInfo pi = myPropertyInfo[i];
                    if (pi.PropertyType.FullName.StartsWith("System.Collections")) continue;
                    string name = pi.Name;
                    if (dt.Columns[name] == null)
                    {
                        column = new DataColumn(name, pi.PropertyType);
                        dt.Columns.Add(column);
                    }
                    row[name] = pi.GetValue(t, null);
                }
                dt.Rows.Add(row);
            }
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>
        /// Ilist 转换成 DataSet
        /// </summary>
        /// <param name="tableType"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataSet ConvertToDataSet(Type tableType, IList list)
        {
            if (list == null || list.Count <= 0)
            {
                return null;
            }
            DataSet ds = new DataSet();
            DataTable dt = new DataTable(tableType.Name);
            DataColumn column;
            DataRow row;
            PropertyInfo[] myPropertyInfo = tableType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var t in list)
            {
                if (t == null)
                {
                    continue;
                }
                row = dt.NewRow();
                for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
                {
                    PropertyInfo pi = myPropertyInfo[i];
                    if (pi.PropertyType.FullName.StartsWith("System.Collections")) continue;
                    if (!pi.PropertyType.FullName.StartsWith("System."))
                    {
                        if (pi.PropertyType.GetProperty("Id") == null) continue;
                        //Sub set
                        object objInst = pi.GetValue(t, null);
                        PropertyInfo[] subInfo = pi.PropertyType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                        for (int k = 0; k < subInfo.Length; k++)
                        {
                            PropertyInfo spi = subInfo[k];
                            string sname = spi.Name;
                            if (sname.ToUpper() == "ID") continue;
                            if (dt.Columns[sname] == null)
                            {
                                if (spi.PropertyType.GetGenericArguments().Length == 0)
                                {
                                    column = new DataColumn(sname, spi.PropertyType);
                                }
                                else
                                {
                                    column = new DataColumn(sname, spi.PropertyType.GetGenericArguments()[0]);
                                }
                                dt.Columns.Add(column);
                            }
                            row[sname] = spi.GetValue(objInst, null) == null ? DBNull.Value : spi.GetValue(objInst, null);
                        }
                        continue;
                    }
                    string name = pi.Name;
                    if (dt.Columns[name] == null)
                    {
                        if (pi.PropertyType.GetGenericArguments().Length == 0)
                        {
                            column = new DataColumn(name, pi.PropertyType);
                        }
                        else
                        {
                            column = new DataColumn(name, pi.PropertyType.GetGenericArguments()[0]);
                        }
                        dt.Columns.Add(column);
                    }
                    row[name] = pi.GetValue(t, null) == null ? DBNull.Value : pi.GetValue(t, null);
                }
                dt.Rows.Add(row);
            }
            ds.Tables.Add(dt);
            return ds;
        }
    }
}
