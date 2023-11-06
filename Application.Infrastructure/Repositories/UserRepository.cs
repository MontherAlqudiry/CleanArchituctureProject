using Application.Data.Entities;
using Application.Infrastructure.Abstracts;
using Application.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDBContext _dbContext;


        public UserRepository(ApplicationDBContext dbContext) 
        {
            _dbContext = dbContext;
        }




        public async Task<List<User>> GetUsersListAsync()
        {

            return await _dbContext.Users.ToListAsync();

        }



    }
}
