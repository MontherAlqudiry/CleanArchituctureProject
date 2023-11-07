using Application.Core.Features.Users.Queries.Models;
using Application.Data.Entities;
using Application.Services.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Users.Queries.Handlers
{
    public class UserHandler : IRequestHandler<GetUserListQuery, List<User>>
    {
        private readonly IUserService _userService;

        public UserHandler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<List<User>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUsersListAsync();
        }
    }
}
