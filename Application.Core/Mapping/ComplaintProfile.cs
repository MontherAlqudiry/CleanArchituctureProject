using Application.Core.Features.Complaints.Commands.Models;
using Application.Core.Features.Complaints.Queries.Responses;
using Application.Data.Entities;
using AutoMapper;

namespace Application.Core.Mapping
{
    public class ComplaintProfile : Profile
    {
        public ComplaintProfile()
        {

            //Queries
            CreateMap<Complaint, GetComplaintListResponse>()
               .ForMember(dest => dest.Demands, opt => opt.MapFrom(src => src.Demands));

            CreateMap<Complaint, GetComplaintByIdResponse>()
                .ForMember(dest => dest.Demands, opt => opt.MapFrom(src => src.Demands));

            CreateMap<Complaint, GetComplaintByUserIdResponse>()
                .ForMember(dest => dest.Demands, opt => opt.MapFrom(src => src.Demands));

            //Command
            CreateMap<AddComplaintCommand, Complaint>()
                .ForMember(dest => dest.Demands, opt => opt.MapFrom(src => src.Demands));

        }
    }
}
