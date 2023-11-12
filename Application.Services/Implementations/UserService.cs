using Application.Data.Entities;
using Application.Infrastructure.Abstracts;
using Application.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
           _userRepository = userRepository;
        }

       

        public async Task<List<User>> GetUsersListAsync()
        {

          return await _userRepository.GetUsersListAsync();

        }
        
        public async Task<User> GetUserbyIdAsync(int id)
        {
          var user = await _userRepository.GetByIdAsync(id);
          return user;
        }
    }
}
