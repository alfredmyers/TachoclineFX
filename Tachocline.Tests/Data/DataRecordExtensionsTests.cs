using System;
using System.Collections;
using System.Data;
using Tachocline.Data;
using Xunit;

public class DataRecordExtensionsTests
{
    [Fact] public void GetNullableValue() => AssertNullAndNotNull(DataRecordExtensions.GetNullableValue, new Uri("http://www.example.com"));
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
    [Fact] public void GetNullableString() => AssertNullAndNotNull(DataRecordExtensions.GetNullableString, string.Empty);
    [Fact] public void GetNullableDateTime() => AssertNullAndNotNull(DataRecordExtensions.GetNullableDateTime);

    [Fact]
    public void GetValues()
    {
        var array = new object[] { 1, 2, 3 };
        var record = new DataRecord
        {
            List = array
        };
        Assert.Equal(array, record.GetValues());
    }

    private void AssertNullAndNotNull<T>(Func<IDataRecord, int, T?> f) where T : struct
    {
        var record = new DataRecord
        {
            List = new ArrayList { DBNull.Value, default(T) }
        };

        Assert.Null(f(record, 0));
        Assert.Equal(default(T), f(record, 1).Value);
    }

    private void AssertNullAndNotNull<T>(Func<IDataRecord, int, T> f, T value) where T : class
    {
        var record = new DataRecord
        {
            List = new ArrayList { DBNull.Value, value }
        };

        Assert.Null(f(record, 0));
        Assert.Equal(value, f(record, 1));
    }

    private class DataRecord : ListToDataRecordProjector
    {

    }
}
