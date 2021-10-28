using Tafels.Models;
using Xunit;

namespace TafelsTests.Models;

public class SumTest
{
    [Fact]
    public void TestCorrect()
    {
        var sum = new Sum { A = 2, B = 3 };

        Assert.False(sum.Correct);

        sum.UserAnswer = 5;
        Assert.False(sum.Correct);

        sum.UserAnswer = 6;
        Assert.True(sum.Correct);
    }

    [Fact]
    public void TestEqualTo()
    {
        var sum = new Sum { A = 2, B = 3 };

        Assert.False(sum.EqualTo((1, 4)));
        Assert.True(sum.EqualTo((2, 3)));
        Assert.True(sum.EqualTo((3, 2)));
    }
}
