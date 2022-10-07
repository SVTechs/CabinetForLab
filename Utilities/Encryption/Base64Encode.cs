using System;
using System.Text;

namespace Utilities.Encryption
{
    public class Base64Encode
    {
        public static string Utf8Encode(string src)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(src));
        }

        public static string Utf8Decode(string src)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(src));
        }
    }
}
