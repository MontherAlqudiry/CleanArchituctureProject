using Application.Core.Features.ApplicationUserCore.Queries.Models;
using Application.Core.Features.ApplicationUserCore.Queries.Responses;
using Application.Data.Entities.Identity;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Features.ApplicationUserCore.Queries.Handlers
{
    public class ApplicationUserQueryHandler : IRequestHandler<GetApllicationUserListQuery, List<GetApplicationUserListResponse>>
                                              , IRequestHandler<GetApplicationUserByIdQuery, GetApplicationUserByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserQueryHandler(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }


        public async Task<List<GetApplicationUserListResponse>> Handle(GetApllicationUserListQuery request, CancellationToken cancellationToken)
        {
            var ApplicationUserList = await _userManager.Users.ToListAsync();
            //if (ApplicationUserList.Count ==0) {return success("ApplicationUser list is empty!") }
            var ApplicationUserMapper = _mapper.Map<List<GetApplicationUserListResponse>>(ApplicationUserList);
            return ApplicationUserMapper;
        }

        public async Task<GetApplicationUserByIdResponse> Handle(GetApplicationUserByIdQuery request, CancellationToken cancellationToken)
        {
            var ApplicationUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            // if (ApplicationUser == null) { return "No ApplicationUser With The Given Id"};
            var ApplicationUserMapper = _mapper.Map<GetApplicationUserByIdResponse>(ApplicationUser);
            return ApplicationUserMapper;
        }
    }
}
