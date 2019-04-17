using System;


namespace D3_API.Utilities
{
    public static class NullableInt64Extensions
    {
        public static Int64 ToInt64(this Int64? value)
        {
            return value == null ? -1 : (Int64)value;
        }

        public static string ToString(this Int64? value)
        {
            return value == null ? string.Empty : ((Int64)value).ToString();
        }

        public static bool IsNull(this Int64? value)
        {
            return value == null;
        }
    }
}
