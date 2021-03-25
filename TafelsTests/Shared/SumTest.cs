using Bunit;
using Tafels.Models;
using Tafels.Shared;
using Xunit;

namespace TafelsTests.Shared
{
    public class SumTest : TestContext
    {
        [Fact]
        public void SuccessStatus()
        {
            var sum = new Sum {A = 2, B = 3};

            var cut = RenderComponent<QuizSum>(
                parameters => parameters
                    .Add(p => p.ShowResult, false)
                    .Add(p => p.Sum, sum)
                    .Add(p => p.onchange, () => {})
                );

            var spanA = cut.Find("span:nth-child(1)");
            var spanB = cut.Find("span:nth-child(3)");
            
            Assert.Equal("2", spanA.InnerHtml);
            Assert.Equal("3", spanB.InnerHtml);
            
            var answerInput = cut.Find("input");
            Assert.False(answerInput.ClassList.Contains("is-success"));

            sum.UserAnswer = 5;
            
            cut.SetParametersAndRender(parameters => parameters
                .Add(p => p.ShowResult, true));
            
            Assert.False(answerInput.ClassList.Contains("is-success"));
            
            sum.UserAnswer = 6;
            cut.Render();
            
            Assert.True(answerInput.ClassList.Contains("is-success"));
        }
    }
}