using Application.Data.Entities;
using Application.Infrastructure.Abstracts;
using Application.Services.Abstracts;

namespace Application.Services.Implementations
{
    public class ComplaintService : IComplaintService
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IDemandRepository _demandRepository;

        public ComplaintService(IComplaintRepository complaintRepository, IDemandRepository demandRepository)
        {
            _complaintRepository = complaintRepository;
            _demandRepository = demandRepository;
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

        public async Task<Complaint> CreateComplaintAsync(Complaint complaint)
        {
            var result = await _complaintRepository.AddAsync(complaint);
            return result;
        }

        public async Task<string> CreateDemandsOfComplaintAsync(ICollection<Demand> demands)
        {
            await _demandRepository.AddRangeAsync(demands);
            return "Demands Added Successfully";
        }

        public async Task<string> DeleteComplaintAsync(Complaint complaint)
        {
            await _complaintRepository.DeleteAsync(complaint);
            return "Complaint deleted successfully!";
        }

        public async Task<List<Complaint>> GetComplaintByUserIdAsync(int userId)
        {
            var result = await _complaintRepository.GetComplaintByUserIdAsync(userId);
            return result;
        }

    }
}
