using System;
using System.Collections.Generic;
using System.Reflection;
using Utilities.Json;

namespace Utilities.Data
{
    public class CopyHelper
    {
        public static object DowngradeCopy(Type originType, Type newType, object originData)
        {
            try
            {
                object itemInstance = newType.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
                PropertyInfo[] properties = newType.GetProperties();
                PropertyInfo[] originProperties = originType.GetProperties();
                if (properties.Length > 0)
                {
                    for (int i = 0; i < properties.Length; i++)
                    {
                        int j;
                        bool isExist = false;
                        for (j = 0; j < originProperties.Length; j++)
                        {
                            if (originProperties[j].Name.Equals(properties[i].Name))
                            {
                                isExist = true;
                                break;
                            }
                        }
                        if (isExist)
                        {
                            try
                            {
                                object originValue = originProperties[j].GetValue(originData, null);
                                properties[i].SetValue(itemInstance, originValue, null);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }
                    }
                }
                return itemInstance;
            }
            catch (Exception)
            {
                // ignored
            }
            return null;
        }

        public static T DeepGenerate<T>(object origin)
        {
            string objectJson = ConvertJson.ObjectToJson(origin);
            return ConvertJson.JsonToObject<T>(objectJson);
        }

        public static IList<T> MergeList<T>(IList<T> originList, IList<T> newList)
        {
            for (int i = 0; i < newList.Count; i++)
            {
                originList.Add(newList[i]);
            }
            return originList;
        }
    }
}
