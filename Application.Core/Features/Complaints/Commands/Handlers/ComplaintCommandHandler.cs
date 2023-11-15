using Application.Core.Bases;
using Application.Core.Features.Complaints.Commands.Models;
using Application.Data.Entities;
using Application.Services.Abstracts;
using AutoMapper;
using MediatR;

namespace Application.Core.Features.Complaints.Commands.Handlers
{
    public class ComplaintCommandHandler : ResponseHandler, IRequestHandler<AddComplaintCommand, string>
    {
        private readonly IComplaintService _complaintService;
        private readonly IMapper _mapper;

        public ComplaintCommandHandler(IComplaintService complaintService, IMapper mapper)
        {
            _complaintService = complaintService;
            _mapper = mapper;
        }

        public async Task<string> Handle(AddComplaintCommand request, CancellationToken cancellationToken)
        {
            var complaintMapper = _mapper.Map<Complaint>(request);
            var complintResult = await _complaintService.CreateComplaintAsync(complaintMapper);
            if (complintResult == "Complaint Added Successfully")
            {

                return complintResult;
            }
            else
            {
                return "Bad Request!";
            }

        }
    }
}
