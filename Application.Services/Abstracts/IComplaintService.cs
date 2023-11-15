using Application.Data.Entities;

namespace Application.Services.Abstracts
{
    public interface IComplaintService
    {
        public Task<List<Complaint>> GetComplaintsAsync();
    }
}
