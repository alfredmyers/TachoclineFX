using System;
using System.Collections;
using Xunit;
using Tachocline.Data;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public sealed class TupleToDataRecordProjectorTests : IDisposable
{
    private readonly ITuple _record;
    private readonly TupleSequenceDataReader _reader;

    public TupleToDataRecordProjectorTests()
    {
        _record = (true, byte.MaxValue, char.MaxValue, DateTime.MaxValue, Decimal.MaxValue, Double.MaxValue, float.MaxValue,
            Guid.Empty, short.MaxValue, int.MaxValue, long.MaxValue, string.Empty, DBNull.Value );
        _reader = new TupleSequenceDataReader(new List<ITuple>() { _record }, _record.Length);
        _reader.Read();
    }

    public void Dispose()
    {
        _reader.Dispose();
    }

    [Fact]
    public void IntIndexer()
    {
        for (int i = 0; i < _record.Length; i++)
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
        for (int i = 0; i < _record.Length; i++)
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
        for (int i = 0; i < _record.Length; i++)
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
        for (int i = 0; i < _record.Length; i++)
        {
            Assert.Equal(_reader[i], _reader.GetValue(i));
        }
    }

    [Fact]
    public void GetValues()
    {
        var copy = new object[_record.Length];
        _reader.GetValues(copy);
        for (int i = 0; i < _record.Length; i++)
        {
            Assert.Equal(_record[i], copy[i]);
        }
    }

    [Fact] public void IsDbNull() => Assert.True(_reader.IsDBNull(12));

    [Fact]
    public static void FieldCount()
    {
        var tuple = (ITuple)( 1, 2, 3 );
        var record = new DataRecord
        {
            Tuple = tuple
        };
        Assert.Equal(tuple.Length, record.FieldCount);
    }

    private class DataRecord : TupleToDataRecordProjector
    {

    }
}
