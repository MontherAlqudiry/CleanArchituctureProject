using Application.Data.Entities;

namespace Application.Infrastructure.Abstracts
{
    public interface IUserRepository
    {

        public Task<List<User>> GetUsersListAsync();



    }
}
