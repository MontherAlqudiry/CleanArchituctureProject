using Application.Data.Entities;
using Application.Infrastructure.Abstracts;
using Application.Infrastructure.Bases;
using Application.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Repositories
{
    public class UserRepository :GenericRepository<User> , IUserRepository
    {

        private readonly DbSet<User> _user;


        public UserRepository(ApplicationDBContext dbContext) :base(dbContext) 
        {
            //it's equal to (_dbcontext.User.) so every time you have to use (_dbcontext.User) you just use (_user) because the _user =dbcontext.Set(User);
            //so the _user point to User Tabble into the database

            _user = dbContext.Set<User>();     

        }




        public async Task<List<User>> GetUsersListAsync()
        {

            return await _user.ToListAsync();

        }



    }
}
