using System.Collections.Generic;
using Bunit;
using Tafels.Shared;
using Xunit;

namespace TafelsTests.Shared
{
    public class TableSelectorTest : TestContext
    {
        [Fact]
        public void SelectMultiple()
        {
            List<int> tables = new();

            var cut = RenderComponent<TableSelector>(parameters => parameters
                .Add(p => p.Single, false)
                .Add(p => p.OnChange, ints => tables = ints));

            var buttons = cut.FindAll("button", true);

            buttons[2].Click();
            buttons[3].Click();

            cut.Render();

            Assert.Equal(new List<int>
            {
                3, 4
            }, tables);
        }

        [Fact]
        public void SelectSingle()
        {
            List<int> tables = new();

            var cut = RenderComponent<TableSelector>(parameters => parameters
                .Add(p => p.Single, true)
                .Add(p => p.OnChange, ints => tables = ints));

            var buttons = cut.FindAll("button", true);

            buttons[2].Click();
            buttons[3].Click();

            cut.Render();

            Assert.Equal(new List<int>
            {
                4
            }, tables);
        }
    }
}