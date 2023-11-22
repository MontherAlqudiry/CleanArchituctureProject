using Application.Core.Features.ApplicationUserCore.Commands.Models;
using Application.Core.Features.ApplicationUserCore.Queries.Responses;
using Application.Data.Entities.Identity;
using AutoMapper;

namespace Application.Core.Mapping
{
    public class UserApplicationProfile : Profile
    {
        public UserApplicationProfile()
        {   //command
            CreateMap<AddApplicationUserCommand, ApplicationUser>();
            CreateMap<EditApplicationUserCommand, ApplicationUser>();


            //Queries
            CreateMap<ApplicationUser, GetApplicationUserListResponse>()
                .ForMember(dest => dest.PhoneNumer, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));

            CreateMap<ApplicationUser, GetApplicationUserByIdResponse>()
               .ForMember(dest => dest.PhoneNumer, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));
        }
    }
}
