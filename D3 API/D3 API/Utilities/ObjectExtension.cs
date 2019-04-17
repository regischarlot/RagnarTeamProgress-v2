using System;

namespace D3_API.Utilities
{
    public static class ObjectExtension
    {
        /// <summary>
        ///     ObjectExtension
        ///        
        ///     Author              Company                             Date            Description
        ///     ------------------- ----------------------------------- --------------- -----------------------------------------
        ///     Regis Charlot       Intelligent Medical Objects, Inc.   April 11, 2013  Inital Creation
        ///     
        /// </summary>

        /// <summary>
        ///     ToString
        ///     
        /// </summary>
        public static string ToString(this object value)
        {
            return (value != null && value.GetType() != typeof(DBNull)) ? Convert.ToString(value) : string.Empty;
        }

        /// <summary>
        ///     ToInt32
        ///     
        /// </summary>
        public static int ToInt32(this object value)
        {
            return ToInt32(value, 0);
        }

        /// <summary>
        ///     ToInt32
        ///     
        /// </summary>
        public static int ToInt32(this object value, int defaultValue)
        {
            return (value != null && value.GetType() != typeof(DBNull)) ? Convert.ToInt32(value) : defaultValue;
        }

        /// <summary>
        ///     ToNullableInt32
        ///     
        /// </summary>
        public static int? ToNullableInt32(this object value)
        {
            return (value != null && value.GetType() != typeof(DBNull) && !string.IsNullOrEmpty(value.ToString())) ? Convert.ToInt32(value) : (int?)null;
        }

        /// <summary>
        ///     ToNullableInt64
        ///     
        /// </summary>
        public static Int64? ToNullableInt64(this object value)
        {
            return (value != null && value.GetType() != typeof(DBNull) && !string.IsNullOrEmpty(value.ToString())) ? Convert.ToInt64(value) : (Int64?)null;
        }

        /// <summary>
        ///     ToGuid
        ///     
        /// </summary>
        public static Guid ToGuid(this object value)
        {
            return (value != null && value.GetType() != typeof(DBNull) && !string.IsNullOrEmpty(value.ToString()))? (Guid)value : Guid.Empty;
        }

        /// <summary>
        ///     ToNullableGuid
        ///     
        /// </summary>
        public static Guid? ToNullableGuid(this object value)
        {
            return (value != null && value.GetType() != typeof(DBNull) && !string.IsNullOrEmpty(value.ToString())) ? (Guid)value : Guid.Empty;
        }

        /// <summary>
        ///     ToDateTime
        ///     
        /// </summary>
        public static DateTime ToDateTime(this object value)
        {
            if (DateTime.TryParse((value ?? "").ToString(), out var result))
                return result;
            return new DateTime(0);
        }

        /// <summary>
        ///     ToDateTime
        ///     
        /// </summary>
        public static DateTime? ToNullableDateTime(this object value)
        {
            if (DateTime.TryParse((value ?? "").ToString(), out var result))
                return result;
            return null;
        }

        /// <summary>
        ///     ToDouble()
        ///     
        /// </summary>
        public static double ToDouble(this object value)
        {
            double result;
            if (value is DBNull || value == null)
                result = 0.0;
            else if (value is bool)
                result = value.ToBool() ? 1 : 0;
            else if (value.IsReal())
                result = Convert.ToDouble(value);
            else if (value.IsNumber())
                result = value.ToInt32();
            else
                result = Convert.ToDouble(value.ToString());
            return result;
        }

        /// <summary>
        ///     ToNullableDouble()
        ///     
        /// </summary>
        public static double? ToNullableDouble(this object value)
        {
            double? result;
            if (value is DBNull)
                return null;
            else if (value is bool)
                result = value.ToBool() ? 1 : 0;
            else if (value.IsReal())
                // ReSharper disable CompareOfFloatsByEqualityOperator
                result = Convert.ToDouble(value);
            // ReSharper restore CompareOfFloatsByEqualityOperator
            else if (value.IsNumber())
                result = value.ToInt32();
            else
                result = double.Parse(value.ToString());
            return result;
        }

        /// <summary>
        ///     ToDouble()
        ///     
        /// </summary>
        public static decimal ToDecimal(this object value)
        {
            decimal result;
            if (value is DBNull || value == null)
                result = 0;
            else if (value is bool)
                result = value.ToBool() ? 1 : 0;
            else if (value.IsReal())
                result = Convert.ToDecimal(value);
            else if (value.IsNumber())
                result = value.ToInt32();
            else
                result = Convert.ToDecimal(value.ToString());
            return result;
        }

        /// <summary>
        ///     ToNullableDecimal()
        ///     
        /// </summary>
        public static decimal? ToNullableDecimal(this object value)
        {
            decimal? result;
            if (value is DBNull)
                return null;
            else if (value is bool)
                result = value.ToBool() ? 1 : 0;
            else if (value.IsReal())
                // ReSharper disable CompareOfFloatsByEqualityOperator
                result = Convert.ToDecimal(value);
            // ReSharper restore CompareOfFloatsByEqualityOperator
            else if (value.IsNumber())
                result = value.ToInt32();
            else
                result = decimal.Parse(value.ToString());
            return result;
        }

        /// <summary>
        ///     ToBool()
        ///     
        /// </summary>
        public static bool ToBool(this object value)
        {
            bool result;
            if (value is bool b)
                result = b;
            else if (value.IsNumber())
                result = value.ToInt32() != 0;
            else if (value.IsReal())
                result = Math.Abs(value.ToDouble()) > double.Epsilon;
            else
            {
                string s = value.ToString();
                result = (!string.IsNullOrEmpty(s)) && (!s.Equals("no", StringComparison.OrdinalIgnoreCase)) && (!s.Equals("false", StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }

        /// <summary>
        ///     ToBool()
        ///     
        /// </summary>
        public static bool? ToNullableBool(this object value)
        {
            bool? result;
            if (value is bool b)
                result = b;
            else if (value.IsNumber())
                result = value.ToInt32() != 0;
            else if (value.IsReal())
                // ReSharper disable CompareOfFloatsByEqualityOperator
                result = value.ToDouble() != 0;
            // ReSharper restore CompareOfFloatsByEqualityOperator
            else
            {
                string s = value.ToString();
                result = (!string.IsNullOrEmpty(s)) && (!s.Equals("no", StringComparison.OrdinalIgnoreCase)) && (!s.Equals("false", StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }

        /// <summary>
        ///    IsNumber() 
        ///
        /// </summary>
        public static bool IsNumber(this object value)
        {
            if (value is String)
                return int.TryParse(value.ToString(), out _);
            return (value is Int16 || value is Int32 || value is Int64 || value is Decimal || value is Single || value is Double || value is Boolean);
        }

        /// <summary>
        ///   IsReal()
        ///     
        /// </summary>
        public static bool IsReal(this object value)
        {
            return double.TryParse(value.ToString(), out _);
        }
    }
}
