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
        var actual = new ArrayList();
        expected.ForEach(o => actual.Add(o));
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ForEachOfTShouldEnumerateAll()
    {
        var expected = Enumerable.Range(0, 5);
        var actual = new List<int>();
        expected.ForEach(actual.Add);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void NullSequenceThrowsArgumentNullException()
    {
        IEnumerable<int> sequence = null;
        var exception = Assert.Throws<ArgumentNullException>(() =>
            sequence.Where(i => true, (Exception ex, int i) => { }).ToList()
        );
        Assert.Equal("sequence", exception.ParamName);
    }

    [Fact]
    public void NullPredicateThrowsArgumentNullException()
    {
        var sequence = Enumerable.Range(0, 5);
        var exception = Assert.Throws<ArgumentNullException>(() =>
            sequence.Where(null, (Exception ex, int i) => { }).ToList()
        );
        Assert.Equal("predicate", exception.ParamName);
    }

    [Fact]
    public void NullExceptionHandlerThrowsArgumentNullException()
    {
        var sequence = Enumerable.Range(0, 5);
        var exception = Assert.Throws<ArgumentNullException>(() =>
            sequence.Where(i => true, (Action<Exception, int>)null).ToList()
        );
        Assert.Equal("exceptionHandler", exception.ParamName);
    }

    [Fact]
    public void ResultingSequenceSkipsExceptions(){
        int[] numbers = {1, 2, 0, 3};
        var actual = numbers.Where(i => 5 / i > 0, (DivideByZeroException ex, int i) => {});
        int[] expected = {1, 2, 3};
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ExeptonHandlerIsInvoked(){
        int[] numbers = {1, 2, 0, 3};
        var actual = new List<int>();
        numbers.Where(i => 5 / i > 0, (DivideByZeroException ex, int i) => actual.Add(i)).ToList();
        int[] expected = {0};
        Assert.Equal(expected, actual);
    }
}