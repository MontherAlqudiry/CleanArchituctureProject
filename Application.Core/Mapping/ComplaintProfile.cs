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
            CreateMap<Complaint, GetComplaintListResponse>();
        }
    }
}
