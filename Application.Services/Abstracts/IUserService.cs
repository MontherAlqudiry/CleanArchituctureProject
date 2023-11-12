using Application.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstracts
{
    public interface IUserService
    {

        public Task<List<User>> GetUsersListAsync();
        public Task<User>GetUserbyIdAsync(int id);
    }
}
