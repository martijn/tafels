using System.Collections.Generic;
using System.Linq;
using Tafels.Models;
using Xunit;

namespace TafelsTests.Models
{
    public class RoundTest
    {
        [Fact]
        public void TestCompleted()
        {
            var round = new Round
            {
                Sums = new List<Sum> {(2, 2)}
            };

            Assert.False(round.Completed);

            round.Sums.First().UserAnswer = 4;
            Assert.True(round.Completed);
        }
    }
}
