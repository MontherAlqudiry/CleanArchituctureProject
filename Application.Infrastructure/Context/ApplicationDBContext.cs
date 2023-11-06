using Application.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext()
        {
            
        }


        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options) 
        {
              
        }

       public DbSet<User> Users { get; set; }
       public DbSet<Complaint> Complaints { get; set; }
       public DbSet<Demand> Demands { get; set; }

     

    }

}
