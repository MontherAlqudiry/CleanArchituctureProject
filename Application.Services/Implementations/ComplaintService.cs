using Application.Data.Entities;
using Application.Infrastructure.Abstracts;
using Application.Services.Abstracts;

namespace Application.Services.Implementations
{
    public class ComplaintService : IComplaintService
    {
        private readonly IComplaintRepository _complaintRepository;

        public ComplaintService(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;

        }

        public async Task<List<Complaint>> GetComplaintsAsync()
        {
            var ComplaintsResult = await _complaintRepository.GetComplaintsListAsync();
            return ComplaintsResult;
        }

        public async Task<Complaint> GetComplaintByIdAsync(int Id)
        {
            var ComplaintResult = await _complaintRepository.GetComplaintByIdAsync(Id);
            return ComplaintResult;
        }

        public async Task<string> CreateComplaintAsync(Complaint complaint)
        {
            await _complaintRepository.AddAsync(complaint);
            return "Complaint Added Successfully";
        }

    }
}
