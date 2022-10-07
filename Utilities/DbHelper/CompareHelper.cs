using System;
using System.Reflection;
using System.Text;

namespace Utilities.DbHelper
{
    public class CompareHelper
    {
        public static string CompareEntity(object item1, object item2)
        {
            if (item1.GetType() != item2.GetType()) return "";
            Type entityType = item1.GetType();
            PropertyInfo[] piList = entityType.GetProperties();
            if (piList.Length == 0) return "";
            StringBuilder infoBuilder = new StringBuilder();
            for (int i = 0; i < piList.Length; i++)
            {
                if (piList[i].Name.ToUpper() == "ID") continue;
                if (piList[i].Name.ToUpper() == "LASTUPDATE") continue;
                if (!(piList[i].PropertyType.IsPrimitive || piList[i].PropertyType == typeof(string) || piList[i].PropertyType == typeof(decimal)
                      || (piList[i].PropertyType.GenericTypeArguments?.Length > 0 && piList[i].PropertyType.GenericTypeArguments[0].IsPrimitive) )) continue;
                string propValue1 = (piList[i].GetValue(item1, null) ?? "").ToString();
                string propValue2 = (piList[i].GetValue(item2, null) ?? "").ToString();
                if (propValue1 != propValue2)
                {
                    string propName = piList[i].Name;
                    string hbName = SqlDataHelper.GetHbComment(piList[i]);
                    if (!string.IsNullOrEmpty(hbName)) propName = hbName;
                    infoBuilder.Append(propName + ": " + propValue1 + "->" + propValue2 + ",");
                }
            }
            return infoBuilder.ToString().TrimEnd(',');
        }

        public static string GetEntityInfo(object item)
        {
            Type entityType = item.GetType();
            PropertyInfo []piList = entityType.GetProperties();
            if (piList.Length == 0) return "";
            StringBuilder infoBuilder = new StringBuilder();
            for (int i = 0; i < piList.Length; i++)
            {
                if (piList[i].Name.ToUpper() == "ID") continue;
                if (piList[i].Name.ToUpper() == "LASTUPDATE") continue;
                if (!(piList[i].PropertyType.IsPrimitive || piList[i].PropertyType == typeof(string) || piList[i].PropertyType == typeof(decimal)
                      || (piList[i].PropertyType.GenericTypeArguments?.Length > 0 && piList[i].PropertyType.GenericTypeArguments[0].IsPrimitive) )) continue;
                string propName = piList[i].Name;
                string hbName = SqlDataHelper.GetHbComment(piList[i]);
                if (!string.IsNullOrEmpty(hbName)) propName = hbName;
                string propValue = (piList[i].GetValue(item, null) ?? "").ToString();
                infoBuilder.Append(propName + ": " + propValue + ",");
            }
            return infoBuilder.ToString().TrimEnd(',');
        }
    }
}
