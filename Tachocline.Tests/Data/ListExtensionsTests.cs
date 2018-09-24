using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Tachocline.Data;
using System.Linq;

public class ListExtensionsTests
{
    private readonly IList _list;
    private readonly IEnumerable<int> _range;

    public ListExtensionsTests()
    {
        _list = new ArrayList { null, 42, "Name", DBNull.Value };
        _range = Enumerable.Range(0, _list.Count);
    }

    [Fact]
    public static void NullListThrowsArgumentNullException()
    {
        IList list = null;
        Assert.Throws<ArgumentNullException>(() =>
            list.GetValue<int>(0)
        );
    }

    [Fact]
    public void GetValueType()
    {
        var index = 1;
        Assert.Equal(_list[index], _list.GetValue<int>(index));
    }

    [Fact]
    public void GetReferenceType()
    {
        var index = 2;
        Assert.Equal(_list[index], _list.GetValue<string>(index));
    }

    [Fact]
    public void GetNullReferenceType()
    {
        var index = 0;
        Assert.Equal(_list[index], _list.GetValue<string>(index));
    }

    [Fact]
    public static void NullListGetValueThrowsArgumentNullException() => Assert.Throws<ArgumentNullException>(()=>((IList)null).GetValue(0));

    [Fact]
    public void GetObject() => Assert.Equal(_list, _range.Select(_list.GetValue).ToList());

    [Fact]
    public void IsDBNull() => Assert.Equal(new bool[] { false, false, false, true }, _range.Select(_list.IsDBNull));

    [Fact]
    public void GetFieldType() => Assert.Equal(new Type[] { typeof(int), typeof(string), typeof(DBNull) }, _range.Skip(1).Select(_list.GetFieldType));
}
