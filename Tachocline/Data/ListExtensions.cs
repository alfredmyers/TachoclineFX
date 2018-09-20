using System;
using System.Collections;

namespace Tachocline.Data
{
    public static class ListExtensions
    {
        public static Type GetFieldType(this IList values, int i) => values.GetValue(i).GetType();

        public static object GetValue(this IList values, int i)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return values[i];
        }

        public static T GetValue<T>(this IList values, int i)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return (T)values[i];
        }

        public static bool IsDBNull(this IList values, int i) => values[i] == DBNull.Value;
    }
}
