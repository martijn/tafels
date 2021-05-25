using System;
using System.Collections.Generic;
using Tafels.Services;
using Xunit;
using System.Linq;
using Tafels.Models;

namespace TafelsTests.Services
{
    public class SumServiceTest
    {
        [Fact]
        public void TestSingleDistribution()
        {
            var service = new SumService();

            var sums = service.Random(1000, new() {1});

            var groups = sums.GroupBy(s => s.A);

            // Test that all values for A are present
            Assert.Equal(10, groups.Count());
            
            // Test that distribution is within acceptable limits (+/- 20% sums per value of A)
            foreach (var group in groups)
            {
                Assert.InRange(group.Count(), 80, 120);
            }
        }

        [Fact]
        public void TestMultiDistribution()
        {
            var service = new SumService();

            var sums = service.Random(1000, Enumerable.Range(1, 10).ToList());

            // Test th average answer for all sums between 1x1 and 10x10. Expected is 30 +/- 10
            Assert.InRange(sums.Select(sum => sum.Answer).Average(), 20, 40);
        }

        [Fact]
        public void TestBatchDistribution()
        {
            var service = new SumService();
            
            List<Sum> sums = new();

            for (var i = 0; i < 100; i++)
            {
                sums.AddRange(service.Random(10, new() {1}));
            }
            
            var groups = sums.GroupBy(s => s.A);
            
            // Test that all values for A are present
            Assert.Equal(10, groups.Count());
            
            // Test that distribution is within acceptable limits (+/- 20% sums per value of A)
            foreach (var group in groups)
            {
                Assert.InRange(group.Count(), 80, 120);
            }
        }
        
    }
}
