using Application.Data.Entities;
using Application.Infrastructure.Abstracts;
using Application.Infrastructure.Bases;
using Application.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Repositories
{
    public class ComplaintRepository : GenericRepository<Complaint>, IComplaintRepository
    {
        private readonly DbSet<Complaint> _complaint;

        public ComplaintRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _complaint = dbContext.Set<Complaint>();
        }


        public async Task<List<Complaint>> GetComplaintsListAsync()
        {
            return await _complaint.ToListAsync();

        }


    }
}
