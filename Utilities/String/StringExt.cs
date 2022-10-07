using System.Text;

namespace Utilities.String
{
    public static class StringExt
    {
        public static string ArrayJoin(this string[] origin, string splitter)
        {
            if (origin == null) return null;
            StringBuilder retBuilder = new StringBuilder();
            for (int i = 0; i < origin.Length; i++)
            {
                retBuilder.Append(origin[i] + splitter);
            }
            return retBuilder.ToString();
        }
    }
}
