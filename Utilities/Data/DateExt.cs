using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Utilities.Data
{
    public static class DataExt
    {
        public static T DeepClone<T>(this T obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);
                ms.Position = 0;
                return (T)bf.Deserialize(ms);
            }
        }
    }
}
