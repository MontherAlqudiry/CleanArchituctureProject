using Application.Data.Entities;

namespace Application.Services.Abstracts
{
    public interface IComplaintService
    {
        public Task<List<Complaint>> GetComplaintsAsync();
        public Task<Complaint> GetComplaintByIdAsync(int Id);
        public Task<string> CreateComplaintAsync(Complaint complaint);
    }
}
