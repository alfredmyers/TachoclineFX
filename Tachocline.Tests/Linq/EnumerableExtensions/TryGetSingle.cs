using System;
using System.Collections.Generic;
using Tachocline.Linq;
using Xunit;

public static class TryGetSingle
{
    [Fact]
    public static void Zero()
    {
        var array = Array.Empty<int>();
        Assert.Equal(default(int), array.TryGetSingle(out bool single));
        Assert.False(single);
    }

    [Fact]
    public static void One()
    {
        var expected = 1;
        var array = new int[] { expected };
        Assert.Equal(expected, array.TryGetSingle(out bool single));
        Assert.True(single);
    }

    [Fact]
    public static void Two()
    {
        var array = new int[] { 1, 2 };
        Assert.Equal(default(int), array.TryGetSingle(out bool single));
        Assert.False(single);
    }
}
