using Application.Data.Entities;
using Application.Infrastructure.Bases;

namespace Application.Infrastructure.Abstracts
{
    public interface IUserRepository :IGenericRepository<User>
    {

        public Task<List<User>> GetUsersListAsync();



    }
}
