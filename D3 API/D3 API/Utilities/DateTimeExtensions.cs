using System;

namespace D3_API.Utilities
{
    public static class DateTimeExtensions
    {
        public static string ToOracleFormat(this DateTime value)
        {
            return value.ToString("MM/dd/yyyy HH:mm:ss"); 
        }

        public static DateTime ToLastDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, DateTime.DaysInMonth(value.Year, value.Month));
        }

        public static DateTime ToFirstDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);
        }


        public static string ToJsonShortDate(this DateTime value)
        {
            return GetFormatedDate(value, "{0:yyyy-MM-dd}"); //2012-04-23T18:25:43.511Z
        }

        /// <summary>
        ///     ToJsonLongDate()
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToJsonLongDate(this DateTime value)
        {
            return GetFormatedDate(value, "{0:yyyy-MM-ddTHH:mm:ss}");
        }

        private static String GetFormatedDate(this DateTime? value, string format)
        {
            return value.IsNull() ? string.Empty : string.Format(format, new object[] { value });
        }
    }
}
