using Application.Data.Entities;

namespace Application.Services.Abstracts
{
    public interface IComplaintService
    {
        public Task<List<Complaint>> GetComplaintsAsync();
        public Task<Complaint> GetComplaintByIdAsync(int Id);
        public Task<Complaint> CreateComplaintAsync(Complaint complaint);
        public Task<string> CreateDemandsOfComplaintAsync(ICollection<Demand> demands);
        public Task<string> DeleteComplaintAsync(Complaint complaint);
    }
}
