using System.Text;
using System.Web;

namespace Utilities.Net
{
    public class JsHelper
    {
        public static string Escape(string src)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < src.Length; i++)
            {
                string t = src[i].ToString();
                string k = HttpUtility.UrlEncode(t, Encoding.Default);
                if (t == k)
                {
                    stringBuilder.Append(t);
                }
                else
                {
                    stringBuilder.Append(k.ToUpper());
                }
            }
            return stringBuilder.ToString().Replace("+", "%20");
        }

        public static string UnEscape(string s)
        {
            return HttpUtility.UrlDecode(s);
        }
    }
}
