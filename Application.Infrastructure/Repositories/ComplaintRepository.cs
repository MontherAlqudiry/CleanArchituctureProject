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


            return await _complaint.Include(c => c.Demands).Where(C => C.Status == "Pending").ToListAsync();

        }

        public async Task<Complaint> GetComplaintByIdAsync(int Id)
        {
            var result = await _complaint.Include(c => c.Demands).FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == Id);

            return result;
        }

        public async Task<List<Complaint>> GetComplaintByUserIdAsync(int UserId)
        {
            var result = await _complaint.Include(c => c.Demands).Where(x => x.UserId == UserId).ToListAsync();
            return result;

        }

        public async Task<string> ChangeComplaintStatusAsync(Complaint complaint, string State)
        {

            complaint.Status = State;
            _complaint.Update(complaint);
            await _dbContext.SaveChangesAsync();

            if (State.ToLower() == "approved")
            {
                return "Complaint state is changed to Approved!";
            }

            else if (State.ToLower() == "denied")
            {
                return "Complaint state is changed to Denied!";
            }

            else return "Bad Request!";

        }


    }
}
