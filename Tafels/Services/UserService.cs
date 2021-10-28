using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Analytics;
using Blazored.LocalStorage;
using Microsoft.Extensions.Logging;
using Tafels.Models;

namespace Tafels.Services
{
    public class UserService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly ILogger<UserService> _logger;
        private readonly IAnalytics _analytics;

        public UserService(ILocalStorageService localStorage, ILogger<UserService> logger, IAnalytics analytics)
        {
            _localStorage = localStorage;
            _logger = logger;
            _analytics = analytics;
        }

        public event Action UsersUpdated;

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
            await _analytics.TrackEvent("UserService.RegisterNewUser");
            return await UpdateUser(new User {Name = name});
        }

        public async Task<List<User>> GetUsers()
        {
            return await _localStorage.GetItemAsync<List<User>>("users") ?? new List<User>();
        }

        public async Task<User> UpdateUser(User user)
        {
            var users = await GetUsers();
            await _localStorage.SetItemAsync("users", users.Where(u => u.Name != user.Name).Append(user).ToList());
            await SetActiveUser(user);
            UsersUpdated?.Invoke();
            return user;
        }

        public async Task AddStars(int i)
        {
            var activeUser = await GetActiveUser();

            if (activeUser is null) return;
            
            activeUser.Stars += 1;

            await UpdateUser(activeUser);
        }
    }
}
