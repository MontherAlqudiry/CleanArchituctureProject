using Application.Core.Bases;
using Application.Core.Features.Users.Queries.Models;
using Application.Core.Features.Users.Queries.Responses;
using Application.Services.Abstracts;
using AutoMapper;
using MediatR;

namespace Application.Core.Features.Users.Queries.Handlers
{
    public class UserQueryHandler :IRequestHandler<GetUserListQuery,List<GetUserListResponse>> ,
                                   IRequestHandler<GetUserByIDQuery,GetUserByIdResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserQueryHandler(IUserService userService ,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        public async Task<List<GetUserListResponse>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
           var UserList = await _userService.GetUsersListAsync();
           var UserlistMapper = _mapper.Map<List<GetUserListResponse>>(UserList);
           return UserlistMapper;
            

        }

        public async Task<GetUserByIdResponse> Handle(GetUserByIDQuery request , CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserbyIdAsync(request.Id);
            var userMapper=_mapper.Map<GetUserByIdResponse>(user);
            return userMapper;
        }

        
    }
}
