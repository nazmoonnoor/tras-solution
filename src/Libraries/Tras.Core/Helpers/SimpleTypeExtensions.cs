using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Core.Helpers
{
    public static class SimpleTypeExtensions
    {
        public static int ToInt(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;
            try
            {
                return int.Parse(value);
            }
            catch
            {
                return 0;
            }
        }

        public static decimal ToDecimal(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;
            try
            {
                return decimal.Parse(value);
            }
            catch
            {
                return 0;
            }
        }

        public static double ToDouble(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;
            try
            {
                return double.Parse(value);
            }
            catch
            {
                return 0;
            }
        }

        public static float ToFloat(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;
            try
            {
                return float.Parse(value);
            }
            catch
            {
                return 0;
            }
        }

        public static DateTime ToDateTime(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return DateTime.MinValue;
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public static string ToDateString(this DateTime value)
        {
            if (DateTime.MinValue == value) return string.Empty;
            try
            {
                return value.ToString("dd-MM-yyyy");
            }
            catch
            {
                return string.Empty;
            }
        }

        public static void Merge<TKey, TValue>(this Dictionary<TKey, TValue> me, Dictionary<TKey, TValue> merge)
        {
            foreach (var item in merge)
            {
                me[item.Key] = item.Value;
            }
        }

        public static void Merge<TKey, TValue>(this IDictionary<TKey, TValue> me, IDictionary<TKey, TValue> merge)
        {
            if (merge != null && merge.Count > 0 && me != null && me.Count > 0)
            {
                foreach (var item in merge)
                {
                    me[item.Key] = item.Value;
                }
            }
        }
    }
}
