using Tafels.Models;
using Xunit;

namespace TafelsTests.Models
{
    public class UserTest
    {
        [Fact]
        public void TestStarsDefault()
        {
            var user = new User();

            Assert.Equal(0, user.Stars);
        }
    }
}
