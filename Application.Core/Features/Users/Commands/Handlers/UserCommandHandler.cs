using Application.Core.Bases;
using Application.Core.Features.Users.Commands.Models;
using Application.Data.Entities;
using Application.Services.Abstracts;
using AutoMapper;
using MediatR;

namespace Application.Core.Features.Users.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, string>,
                                                       IRequestHandler<EditUserCommand, string>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }

        public async Task<string> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            //the request here has the user that will create but the userservice parameter is of type User so we have to mapping from request to User

            var userMapper = _mapper.Map<User>(request);
            //add user
            var userResult = await _userService.AddUserAsync(userMapper);
            //check Condition
            if (userResult == "User is Exist Already!")
            {
                return "User is Exist Already!";
            }
            //return response
            else if (userResult == "User Added successfully!")
            {
                return userResult;
            }
            else
            {
                return "Bad Request!";
            }





        }

        public async Task<string> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            //check if user exist
            var user = await _userService.GetUserbyIdAsync(request.Id);
            if (user == null)
            {
                return "Bad Request!";
            }


            // Map request to User
            var userMapper = _mapper.Map<User>(request);
            var userResult = await _userService.UpdateUserAsync(userMapper);
            if (userResult == "Updated Successfully!")
            {
                return userResult;
            }
            else
            {
                return "Bad Request!";
            }

        }
    }
}
