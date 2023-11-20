using Application.Core.Bases;
using Application.Core.Features.Users.Queries.Models;
using Application.Core.Features.Users.Queries.Responses;
using Application.Core.Resources;
using Application.Services.Abstracts;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Application.Core.Features.Users.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler, IRequestHandler<GetUserListQuery, List<GetUserListResponse>>,
                                   IRequestHandler<GetUserByIDQuery, Response<GetUserByIdResponse>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public UserQueryHandler(IUserService userService,
                                IMapper mapper,
                                IStringLocalizer<SharedResources> stringLocalizer)
        {
            _userService = userService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }


        public async Task<List<GetUserListResponse>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var UserList = await _userService.GetUsersListAsync();
            var UserlistMapper = _mapper.Map<List<GetUserListResponse>>(UserList);
            return UserlistMapper;


        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {


            var user = await _userService.GetUserbyIdAsync(request.Id);
            if (user == null) { return NotFound<GetUserByIdResponse>(_stringLocalizer[SharedResoursesKeys.NotFound]); }
            var NotFound = _stringLocalizer[SharedResoursesKeys.NotFound];

            var userMapper = _mapper.Map<GetUserByIdResponse>(user);
            return Success(userMapper);
        }


    }
}
