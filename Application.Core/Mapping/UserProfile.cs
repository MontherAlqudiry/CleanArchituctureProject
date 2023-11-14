using Application.Core.Features.Users.Commands.Models;
using Application.Core.Features.Users.Queries.Responses;
using Application.Data.Entities;
using AutoMapper;

namespace Application.Core.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUserListResponse>();
            CreateMap<User, GetUserByIdResponse>();
            CreateMap<AddUserCommand, User>();
            CreateMap<EditUserCommand, User>();

        }
    }
}
