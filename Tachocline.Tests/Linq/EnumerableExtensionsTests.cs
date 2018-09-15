using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tachocline.Linq;
using Xunit;

public class EnumerableExtensionsTests
{
    [Fact]
    public void ForEachShouldEnumerateAll()
    {
        var expected = (IEnumerable)Enumerable.Range(0, 5);
        var list = new ArrayList();
        expected.ForEach(o => list.Add(o));
        Assert.Equal(expected, list);
    }

    [Fact]
    public void ForEachOfTShouldEnumerateAll()
    {
        var expected = Enumerable.Range(0, 5);
        var list = new List<int>();
        expected.ForEach(list.Add);
        Assert.Equal(expected, list);
    }
}