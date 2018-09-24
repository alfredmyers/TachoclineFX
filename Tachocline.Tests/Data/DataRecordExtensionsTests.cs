using System;
using System.Collections;
using System.Data;
using Xunit;
using Tachocline.Data;

public class DataRecordExtensionsTests
{
    [Fact] public void GetNullableBoolean() => AssertNullAndNotNull(DataRecordExtensions.GetNullableBoolean);
    [Fact] public void GetNullableByte() => AssertNullAndNotNull(DataRecordExtensions.GetNullableByte);
    [Fact] public void GetNullableChar() => AssertNullAndNotNull(DataRecordExtensions.GetNullableChar);
    [Fact] public void GetNullableGuid() => AssertNullAndNotNull(DataRecordExtensions.GetNullableGuid);
    [Fact] public void GetNullableInt16() => AssertNullAndNotNull(DataRecordExtensions.GetNullableInt16);
    [Fact] public void GetNullableInt32() => AssertNullAndNotNull(DataRecordExtensions.GetNullableInt32);
    [Fact] public void GetNullableInt64() => AssertNullAndNotNull(DataRecordExtensions.GetNullableInt64);
    [Fact] public void GetNullableFloat() => AssertNullAndNotNull(DataRecordExtensions.GetNullableFloat);
    [Fact] public void GetNullableDouble() => AssertNullAndNotNull(DataRecordExtensions.GetNullableDouble);
    [Fact] public void GetNullableDecimal() => AssertNullAndNotNull(DataRecordExtensions.GetNullableDecimal);
    [Fact] public void GetNullableDateTime() => AssertNullAndNotNull(DataRecordExtensions.GetNullableDateTime);

    private void AssertNullAndNotNull<T>(Func<IDataRecord, int, T?> f) where T : struct
    {
        var record = new DataRecord
        {
            List = new ArrayList { DBNull.Value, default(T) }
        };

        Assert.Null(f(record, 0));
        Assert.Equal(default(T), f(record, 1).Value);
    }

    private class DataRecord : ListToDataRecordProjector
    {

    }
}
