using System;
using System.Data;

namespace Tachocline.Data
{
    public static class DataRecordExtensions
    {
        public static T GetNullableReferenceValue<T>(this IDataRecord record, int ordinal, Func<int, T> get) where T: class 
            => record.IsDBNull(ordinal) ? (T)null : get(ordinal);

        public static T? GetNullableValue<T>(this IDataRecord record, int ordinal, Func<int, T> get) where T: struct
            => record.IsDBNull(ordinal) ? (T?)null : get(ordinal);

        public static object GetNullableValue(this IDataRecord record, int ordinal) => record.GetNullableReferenceValue(ordinal, record.GetValue);

        public static bool? GetNullableBoolean(this IDataRecord record, int ordinal) => record.GetNullableValue(ordinal, record.GetBoolean);

        public static byte? GetNullableByte(this IDataRecord record, int ordinal) => record.GetNullableValue(ordinal, record.GetByte);

        public static char? GetNullableChar(this IDataRecord record, int ordinal) => record.GetNullableValue(ordinal, record.GetChar);

        public static Guid? GetNullableGuid(this IDataRecord record, int ordinal) => record.GetNullableValue(ordinal, record.GetGuid);

        public static short? GetNullableInt16(this IDataRecord record, int ordinal) => record.GetNullableValue(ordinal, record.GetInt16);

        public static int? GetNullableInt32(this IDataRecord record, int ordinal) => record.GetNullableValue(ordinal, record.GetInt32);

        public static long? GetNullableGetInt64(this IDataRecord record, int ordinal) => record.GetNullableValue(ordinal, record.GetInt64);

        public static float? GetNullableFloat(this IDataRecord record, int ordinal) => record.GetNullableValue(ordinal, record.GetFloat);

        public static double? GetNullableDouble(this IDataRecord record, int ordinal) => record.GetNullableValue(ordinal, record.GetDouble);

        public static string GetNullableString(this IDataRecord record, int ordinal) => record.GetNullableReferenceValue(ordinal, record.GetString);

        public static decimal? GetNullableDecimal(this IDataRecord record, int ordinal) => record.GetNullableValue(ordinal, record.GetDecimal);

        public static DateTime? GetNullableDateTime(this IDataRecord record, int ordinal) => record.GetNullableValue(ordinal, record.GetDateTime);
    }
}