﻿using Application.Data.Entities;

namespace Application.Services.Abstracts
{
    public interface IUserService
    {

        public Task<List<User>> GetUsersListAsync();
        public Task<User> GetUserbyIdAsync(int id);
        public Task<User> GetUserbyIdAsNoTrackingAsync(int id);
        public Task<string> AddUserAsync(User user);
        public Task<string> UpdateUserAsync(User user);
        public Task<string> DeleteUserAsync(User user);
    }
}
