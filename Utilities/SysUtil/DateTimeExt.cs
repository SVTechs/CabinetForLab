using System;

namespace Utilities.SysUtil
{
    public static class DateTimeExt
    {
        public static string ToStdString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
