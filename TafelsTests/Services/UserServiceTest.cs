using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Blazor.Analytics;
using Bunit;
using Tafels.Services;
using Xunit;

namespace TafelsTests.Services
{
    public class UserServiceTest : TestContext
    {
        [Fact]
        public async Task RegistersNewUser()
        {
            var localStorage = this.AddBlazoredLocalStorage();

            var userService = new UserService(localStorage, null, new MockAnalytics());

            await userService.RegisterNewUser("John");

            var users = await userService.GetUsers();

            Assert.Equal("John", users[0].Name);
        }
        
    }
}
