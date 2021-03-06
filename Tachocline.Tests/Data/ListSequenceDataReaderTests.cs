using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Xunit;
using Tachocline.Data;
using System.Linq;

public sealed class ListSequenceDataReaderTests : IDisposable
{
    private const int FieldCount = 1;

    private readonly ListSequenceDataReader _reader;

    public ListSequenceDataReaderTests()
    {
        _reader = new ListSequenceDataReader(Enumerable.Empty<int[]>(), FieldCount);
    }

    [Fact]
    public static void NullSequenceThrowsArgumentNullException() => Assert.Throws<ArgumentNullException>(() => new ListSequenceDataReader(null, default(int)));

    [Fact]
    public void FieldCountPropagatesToProperty() => Assert.Equal(FieldCount, _reader.FieldCount);

    [Fact]
    public void DepthIsZero() => Assert.Equal(0, _reader.Depth);

    [Fact]
    public static void IsClosed()
    {
        var reader = new ListSequenceDataReader(Enumerable.Empty<int[]>(), FieldCount);
        Assert.False(reader.IsClosed);
        reader.Close();
        Assert.True(reader.IsClosed);
    }

    [Fact]
    public void RecordsAffectedReturnsMinusOne() => Assert.Equal(-1, _reader.RecordsAffected);

    [Fact]
    public void NextResultThrowsNotSupportedException() => Assert.Throws<NotSupportedException>(() => _reader.NextResult());

    [Fact]
    public static void ReadDisposedObjectThrowsObjectDisposedException()
    {
        var reader = new ListSequenceDataReader(Enumerable.Empty<int[]>(), FieldCount);
        reader.Dispose();
        Assert.Throws<ObjectDisposedException>(() => reader.Read());
    }

    [Fact]
    public static void Read()
    {
        var reader = new ListSequenceDataReader(Enumerable.Range(0, 2).Select(i => new int[] { i }), 1);
        Assert.True(reader.Read());
        Assert.True(reader.Read());
        Assert.False(reader.Read());
        Assert.False(reader.Read());
    }

    [Fact]
    public void GetSchemaTableThrowsNotSupportedException() => Assert.Throws<NotSupportedException>(() => _reader.GetSchemaTable());

    public void Dispose()
    {
        _reader.Dispose();
    }
}
