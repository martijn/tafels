using System.Collections.Generic;
using System.Linq;
using Tafels.Models;
using Tafels.Services;
using Xunit;

namespace TafelsTests.Services;

public class SumServiceTest
{
    private readonly SumService _service;

    public SumServiceTest()
    {
        _service = new SumService();
    }

    [Fact]
    public void TestSingleDistribution()
    {
        var sums = _service.Random(1000, new List<int> { 1 });

        var groups = sums.GroupBy(s => s.A);

        // Test that all values for A are present
        Assert.Equal(10, groups.Count());

        // Test that distribution is within acceptable limits (+/- 20% sums per value of A)
        foreach (var group in groups) Assert.InRange(group.Count(), 80, 120);
    }

    [Fact]
    public void TestMultiDistribution()
    {
        var sums = _service.Random(1000, Enumerable.Range(1, 10).ToList());

        // Test th average answer for all sums between 1x1 and 10x10. Expected is 30 +/- 10
        Assert.InRange(sums.Select(sum => sum.Answer).Average(), 20, 40);
    }

    [Fact]
    public void TestBatchDistribution()
    {
        List<Sum> sums = new();

        for (var i = 0; i < 100; i++) sums.AddRange(_service.Random(10, new List<int> { 1 }));

        var groups = sums.GroupBy(s => s.A);

        // Test that all values for A are present
        Assert.Equal(10, groups.Count());

        // Test that distribution is within acceptable limits (+/- 20% sums per value of A)
        foreach (var group in groups) Assert.InRange(group.Count(), 80, 120);
    }

    [Fact]
    public void TestSingleTable()
    {
        var sums = SumService.FullTable(10);

        Assert.Equal(10, sums.Count);

        Assert.Equal(55, sums.Sum(s => s.A));
        Assert.Equal(100, sums.Sum(s => s.B));
    }

    [Fact]
    public void TestRemoveFromHistory()
    {
        var _sums = _service.Random(10, new List<int> { 2 });

        _service.RemoveFromHistory((2, 2));
    }
}
