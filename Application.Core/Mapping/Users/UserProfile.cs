using Application.Core.Features.Users.Queries.Responses;
using Application.Data.Entities;
using AutoMapper;

namespace Application.Core.Mapping.Users
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUserListResponse>();
            CreateMap<User, GetUserByIdResponse>();
        }
    }
}
