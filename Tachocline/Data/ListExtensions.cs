using System;
using System.Collections;
using System.Data;

namespace Tachocline.Data
{
    public static class ListExtensions
    {
        public static bool GetBoolean(this IList values, int i)
        {
            return (bool)values[i];
        }

        public static byte GetByte(this IList values, int i)
        {
            return (byte)values[i];
        }

        public static char GetChar(this IList values, int i)
        {
            return (char)values[i];
        }

        public static DateTime GetDateTime(this IList values, int i)
        {
            return (DateTime)values[i];
        }

        public static decimal GetDecimal(this IList values, int i)
        {
            return (decimal)values[i];
        }

        public static double GetDouble(this IList values, int i)
        {
            return (double)values[i];
        }

        public static Type GetFieldType(this IList values, int i)
        {
            return values[i].GetType();
        }

        public static float GetFloat(this IList values, int i)
        {
            return (float)values[i];
        }

        public static Guid GetGuid(this IList values, int i)
        {
            return (Guid)values[i];
        }

        public static short GetInt16(this IList values, int i)
        {
            return (short)values[i];
        }

        public static int GetInt32(this IList values, int i)
        {
            return (int)values[i];
        }

        public static long GetInt64(this IList values, int i)
        {
            return (long)values[i];
        }

        public static string GetString(this IList values, int i)
        {
            return (string)values[i];
        }

        public static object GetValue(this IList values, int i)
        {
            return values[i];
        }

        public static bool IsDBNull(this IList values, int i)
        {
            return values[i] == DBNull.Value;
        }
    }
}
