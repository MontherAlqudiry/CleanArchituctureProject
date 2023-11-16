using Application.Data.Entities;
using Application.Infrastructure.Bases;

namespace Application.Infrastructure.Abstracts
{
    public interface IComplaintRepository : IGenericRepository<Complaint>
    {
        public Task<List<Complaint>> GetComplaintsListAsync();
        public Task<Complaint> GetComplaintByIdAsync(int Id);
        public Task<List<Complaint>> GetComplaintByUserIdAsync(int UserId);
    }
}
