using System;

namespace D3_API.Utilities
{
    public static class NullableDateTimeExtensions
    {
        public static DateTime ToDateTime(this DateTime? value)
        {
            return value ?? DateTime.Today;
        }

        public static bool IsNull(this DateTime? value)
        {
            return value == null;
        }

        public static string ToJString(this DateTime? value)
        {
            return GetFormatedDate(value, "{0:M/dd/yyyy}");
        }

        public static string ToJSONShortDate(this DateTime? value)
        {
            return GetFormatedDate(value, "{0:yyyy-MM-dd}");
        }

        /// <summary>
        ///     ToISO8601()
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToISO8601(this DateTime? value)
        {
            return GetFormatedDate(value, "{0:yyyy-MM-ddTHH:mm:ss.fffZ}");
        }

        /// <summary>
        ///     ToJsonLong()
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToJsonLong(this DateTime? value)
        {
            return GetFormatedDate(value, "{0:yyyy-MM-ddTHH:mm:ss}");
        }

        private static String GetFormatedDate(this DateTime? value, string format)
        {
            return value.IsNull() ? string.Empty : string.Format(format, new object[] { value });
        }
    }
}
