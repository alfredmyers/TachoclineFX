using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using Tachocline.IO;
using System.Diagnostics;

public static class StreamEnumerableTests
{
    private const string FileName = "LoremIpsum.txt";

    [Fact]
    public static void EnumerateAllLines()
    {
        var expected = File.ReadAllLines(FileName);
        using (var file = File.OpenRead(FileName))
        {
            Assert.Equal(expected, new StreamEnumerable(file));
        }
    }

    [Fact]
    public static void ReturnsNullBeforeMoving()
    {
        using (var e = new StreamEnumerable(File.OpenRead(FileName)).GetEnumerator())
        {
            Assert.Null(e.Current);
        }
    }

    [Fact]
    public static void Reset()
    {
        using (var e = new StreamEnumerable(File.OpenRead(FileName)).GetEnumerator())
        {
            var expected = new List<string>();
            while (e.MoveNext())
            {
                expected.Add(e.Current);
            }

            Debug.Assert(expected.Count > 0);

            e.Reset();

            var actual = new List<string>();
            while (e.MoveNext())
            {
                actual.Add(e.Current);
            }

            Assert.Equal(expected, actual);
        }
    }
}
