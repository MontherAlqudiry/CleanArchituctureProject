using Application.Core.Features.Complaints.Queries.Models;
using Application.Core.Features.Complaints.Queries.Responses;
using Application.Services.Abstracts;
using AutoMapper;
using MediatR;

namespace Application.Core.Features.Complaints.Queries.Handlers
{
    public class ComplaintQueryHandler : IRequestHandler<GetComplaintsListQuery, List<GetComplaintListResponse>>
    {
        private readonly IComplaintService _complaintService;
        private readonly IMapper _mapper;

        public ComplaintQueryHandler(IComplaintService complaintService, IMapper mapper)
        {
            _complaintService = complaintService;
            _mapper = mapper;
        }

        public async Task<List<GetComplaintListResponse>> Handle(GetComplaintsListQuery request, CancellationToken cancellationToken)
        {
            var ComplaintList = await _complaintService.GetComplaintsAsync();
            var ComplaintMapper = _mapper.Map<List<GetComplaintListResponse>>(ComplaintList);
            return ComplaintMapper;
        }


    }
}
