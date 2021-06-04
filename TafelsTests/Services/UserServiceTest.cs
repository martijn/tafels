using System.Threading.Tasks;
using Bunit;
using Tafels.Services;
using Xunit;

namespace TafelsTests.Services
{
    public class UserServiceTest : TestContext
    {
        private readonly UserService _userService;

        public UserServiceTest()
        {
            var localStorage = this.AddBlazoredLocalStorage();
            _userService = new UserService(localStorage, null, new MockAnalytics());
        }

        [Fact]
        public async Task RegistersNewUser()
        {
            await _userService.RegisterNewUser("John");

            var users = await _userService.GetUsers();

            Assert.Equal("John", users[0].Name);
        }

        [Fact]
        public async Task SetsGetsActiveUser()
        {
            Assert.Null(await _userService.GetActiveUser());

            var john = await _userService.RegisterNewUser("John");
            var anna = await _userService.RegisterNewUser("Anna");

            await _userService.SetActiveUser(john);
            Assert.Equal("John", (await _userService.GetActiveUser()).Name);

            await _userService.SetActiveUser(anna);
            Assert.Equal("Anna", (await _userService.GetActiveUser()).Name);
        }


        [Fact]
        public async Task AddsStars()
        {
            await _userService.RegisterNewUser("John");

            await _userService.AddStars(1);

            var john = await _userService.GetActiveUser();
            Assert.Equal(1, john.Stars);
        }
    }
}
