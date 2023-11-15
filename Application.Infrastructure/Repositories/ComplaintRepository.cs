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


            return await _complaint.Include(c => c.Demands).ToListAsync();

        }

        public async Task<Complaint> GetComplaintByIdAsync(int Id)
        {
            var result = await _complaint.Include(c => c.Demands).FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == Id);

            return result;
        }


    }
}
