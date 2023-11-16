using Application.Core.Bases;
using Application.Core.Features.Complaints.Commands.Models;
using Application.Data.Entities;
using Application.Services.Abstracts;
using AutoMapper;
using MediatR;

namespace Application.Core.Features.Complaints.Commands.Handlers
{
    public class ComplaintCommandHandler : ResponseHandler, IRequestHandler<AddComplaintCommand, string>
                                                          , IRequestHandler<DeleteComplaintCommand, string>
                                                          , IRequestHandler<UpdateComplaintStateCommand, string>

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

            var demands = request.Demands;
            request.Demands = null;


            var complaintMapper = _mapper.Map<Complaint>(request);
            var complaintResult = await _complaintService.CreateComplaintAsync(complaintMapper);

            if (complaintResult == null)
            {
                return "Failed to add complaint";
            }


            var complaintId = complaintResult.Id;
            foreach (var demand in demands)
            {
                demand.CompId = complaintId;
            }


            var demandsResult = await _complaintService.CreateDemandsOfComplaintAsync(demands);

            if (demandsResult == "Demands Added Successfully")
            {
                return "Complaint and Demands Added Successfully";
            }
            else
            {
                return "Failed to add demands";
            }


        }

        public async Task<string> Handle(DeleteComplaintCommand request, CancellationToken cancellationToken)
        {
            var complaintResult = await _complaintService.GetComplaintByIdAsync(request.Id);
            if (complaintResult == null)
            {
                return $"No complaints with the given Id : {request.Id}";
            }
            var complaintToDeleteResult = await _complaintService.DeleteComplaintAsync(complaintResult);
            if (complaintToDeleteResult == "Complaint deleted successfully!")
            {
                return complaintToDeleteResult;
            }
            else
            {
                return "Bad Request!";
            }
        }

        public async Task<string> Handle(UpdateComplaintStateCommand request, CancellationToken cancellationToken)
        {

            var complaintMapper = _mapper.Map<Complaint>(request);
            var complaintResult = await _complaintService.ChangeComplaintStateAsync(complaintMapper, request.NewState);
            return complaintResult;


        }
    }
}
