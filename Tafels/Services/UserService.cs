using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Tafels.Models;

namespace Tafels.Services
{
    public class UserService
    {
        private readonly ILocalStorageService _localStorage;

        public UserService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<User> GetActiveUser()
        {
            var username = await _localStorage.GetItemAsync<string>("activeUser");
            var users = await GetUsers();

            if (username == null || users.Count == 0)
                return null;
            return users.FirstOrDefault(u => u.Name == username);
        }

        public async Task SetActiveUser(User user)
        {
            await _localStorage.SetItemAsync("activeUser", user.Name);
        }

        public async Task<User> RegisterNewUser(string name)
        {
            var user = new User {Name = name};
            await UpdateUser(user);
            await SetActiveUser(user);
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _localStorage.GetItemAsync<List<User>>("users") ?? new List<User>();
        }

        public async Task UpdateUser(User user)
        {
            var users = await GetUsers();
            await _localStorage.SetItemAsync("users", users.Where(u => u.Name != user.Name).Append(user).ToList());
        }
    }
}
