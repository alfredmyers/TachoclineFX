using System;
using System.Collections;
using Xunit;
using Tachocline.Data;
using System.Linq;
using System.Collections.Generic;

public sealed class TupleToDataRecordProjectorTests : IDisposable
{
    private readonly ArrayList _record;
    private readonly ListSequenceDataReader _reader;

    public TupleToDataRecordProjectorTests()
    {
        _record = new ArrayList { true, byte.MaxValue, char.MaxValue, DateTime.MaxValue, Decimal.MaxValue, Double.MaxValue, float.MaxValue,
            Guid.Empty, short.MaxValue, int.MaxValue, long.MaxValue, string.Empty, DBNull.Value };
        _reader = new ListSequenceDataReader(new ArrayList[] { _record }, _record.Count);
        _reader.Read();
    }

    public void Dispose()
    {
        _reader.Dispose();
    }

    [Fact]
    public void IntIndexer()
    {
        for (int i = 0; i < _record.Count; i++)
        {
            Assert.Equal(_record[i], _reader[i]);
        }
    }

    [Fact] public void StringIndexer() => Assert.Throws<NotSupportedException>(() => _reader["anything"]);
    [Fact] public void GetBoolean() => Assert.True(_reader.GetBoolean(0));
    [Fact] public void GetByte() => Assert.Equal(byte.MaxValue, _reader.GetByte(1));
    [Fact] public void GetBytes() => Assert.Throws<NotSupportedException>(() => _reader.GetBytes(0, 0, null, 0, 0));
    [Fact] public void GetChar() => Assert.Equal(char.MaxValue, _reader.GetChar(2));
    [Fact] public void GetChars() => Assert.Throws<NotSupportedException>(() => _reader.GetChars(0, 0, null, 0, 0));
    [Fact] public void GetData() => Assert.Throws<NotSupportedException>(() => _reader.GetData(0));

    [Fact]
    public void GetDataTypeName()
    {
        for (int i = 0; i < _record.Count; i++)
        {
            Assert.Equal(_record[i].GetType().Name, _reader.GetDataTypeName(i));
        }
    }

    [Fact] public void GetDateTime() => Assert.Equal(DateTime.MaxValue, _reader.GetDateTime(3));
    [Fact] public void GetDecimal() => Assert.Equal(decimal.MaxValue, _reader.GetDecimal(4));
    [Fact] public void GetDouble() => Assert.Equal(double.MaxValue, _reader.GetDouble(5));

    [Fact]
    public void GetFieldType()
    {
        for (int i = 0; i < _record.Count; i++)
        {
            Assert.Equal(_record[i].GetType(), _reader.GetFieldType(i));
        }
    }

    [Fact] public void GetFloat() => Assert.Equal(float.MaxValue, _reader.GetFloat(6));
    [Fact] public void GetGuid() => Assert.Equal(Guid.Empty, _reader.GetGuid(7));
    [Fact] public void GetInt16() => Assert.Equal(short.MaxValue, _reader.GetInt16(8));
    [Fact] public void GetInt32() => Assert.Equal(int.MaxValue, _reader.GetInt32(9));
    [Fact] public void GetInt64() => Assert.Equal(long.MaxValue, _reader.GetInt64(10));
    [Fact] public void GetName() => Assert.Throws<NotSupportedException>(() => _reader.GetName(0));
    [Fact] public void GetOrdinal() => Assert.Throws<NotSupportedException>(() => _reader.GetOrdinal("anyThing"));
    [Fact] public void GetString() => Assert.Equal(string.Empty, _reader.GetString(11));

    [Fact]
    public void GetValue()
    {
        for (int i = 0; i < _record.Count; i++)
        {
            Assert.Equal(_reader[i], _reader.GetValue(i));
        }
    }

    [Fact]
    public void GetValues()
    {
        var copy = new object[_record.Count];
        _reader.GetValues(copy);
        Assert.Equal(_record.ToArray(), copy);
    }

    [Fact] public void IsDbNull() => Assert.True(_reader.IsDBNull(12));

    [Fact]
    public static void FieldCount()
    {
        var list = new List<int> { 1, 2, 3 };
        var record = new DataRecord
        {
            List = list
        };
        Assert.Equal(list.Count, record.FieldCount);
    }

    private class DataRecord : ListToDataRecordProjector
    {

    }
}
