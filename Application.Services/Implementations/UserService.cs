using Application.Data.Entities;
using Application.Infrastructure.Abstracts;
using Application.Services.Abstracts;

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

        public async Task<User> GetUserbyIdAsNoTrackingAsync(int id)
        {
            var user = await _userRepository.GetByIdAsNoTrackingAsync(id);
            return user;
        }

        public async Task<string> AddUserAsync(User user)
        {

            //Check if the gmail is Exist or Not
            var userCheck = _userRepository.GetTableNoTracking().Where(x => x.Email == user.Email).FirstOrDefault();
            if (userCheck != null)
            {
                return "User is Exist Already!";
            }

            //add the user to the database after checking if it's already exist  
            await _userRepository.AddAsync(user);
            return "User Added successfully!";


        }

        public async Task<string> UpdateUserAsync(User user)
        {

            await _userRepository.UpdateAsync(user);
            return "Updated Successfully!";


        }

        public async Task<string> DeleteUserAsync(User user)
        {

            await _userRepository.DeleteAsync(user);
            return "User Deleted Successfully!";
        }
    }

}
