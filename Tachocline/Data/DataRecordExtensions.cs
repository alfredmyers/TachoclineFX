using System;
using System.Data;

namespace Tachocline.Data
{
    public static class DataRecordExtensions
    {
        private static T GetNullableReferenceValue<T>(Func<int, T> get, int ordinal) where T : class
        {
            var record = (IDataRecord)get.Target;
            return record.IsDBNull(ordinal) ? (T)null : get(ordinal);
        }

        private static T? GetNullableValue<T>(Func<int, T> get, int ordinal) where T : struct
        {
            var record = (IDataRecord)get.Target;
            return record.IsDBNull(ordinal) ? (T?)null : get(ordinal);
        }

        public static object GetNullableValue(this IDataRecord record, int ordinal) => GetNullableReferenceValue(record.GetValue, ordinal);

        public static bool? GetNullableBoolean(this IDataRecord record, int ordinal) => GetNullableValue(record.GetBoolean, ordinal);

        public static byte? GetNullableByte(this IDataRecord record, int ordinal) => GetNullableValue(record.GetByte, ordinal);

        public static char? GetNullableChar(this IDataRecord record, int ordinal) => GetNullableValue(record.GetChar, ordinal);

        public static Guid? GetNullableGuid(this IDataRecord record, int ordinal) => GetNullableValue(record.GetGuid, ordinal);

        public static short? GetNullableInt16(this IDataRecord record, int ordinal) => GetNullableValue(record.GetInt16, ordinal);

        public static int? GetNullableInt32(this IDataRecord record, int ordinal) => GetNullableValue(record.GetInt32, ordinal);

        public static long? GetNullableInt64(this IDataRecord record, int ordinal) => GetNullableValue(record.GetInt64, ordinal);

        public static float? GetNullableFloat(this IDataRecord record, int ordinal) => GetNullableValue(record.GetFloat, ordinal);

        public static double? GetNullableDouble(this IDataRecord record, int ordinal) => GetNullableValue(record.GetDouble, ordinal);

        public static string GetNullableString(this IDataRecord record, int ordinal) => GetNullableReferenceValue(record.GetString, ordinal);

        public static decimal? GetNullableDecimal(this IDataRecord record, int ordinal) => GetNullableValue(record.GetDecimal, ordinal);

        public static DateTime? GetNullableDateTime(this IDataRecord record, int ordinal) => GetNullableValue(record.GetDateTime, ordinal);

        public static object[] GetValues(this IDataRecord record)
        {
            var values = new object[record.FieldCount];
            record.GetValues(values);
            return values;
        }
    }
}
