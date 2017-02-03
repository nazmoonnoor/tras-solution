using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Core.Helpers
{
    public static class EnumHelper
    {
        public static String ConvertToString(this Enum eff)
        {
            return Enum.GetName(eff.GetType(), eff);
        }

        public static TEnumType ConverToEnum<TEnumType>(this String enumValue)
        {
            return (TEnumType)Enum.Parse(typeof(TEnumType), enumValue);
        }
    }

    public static class EnumUtil
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
