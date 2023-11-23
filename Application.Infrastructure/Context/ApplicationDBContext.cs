using Application.Data.Entities;
using Application.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDBContext()
        {

        }


        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Demand> Demands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //User Entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.FName)
                      .IsRequired()
                      .HasComment("First Name is required");
                entity.Property(x => x.LName)
                      .IsRequired()
                      .HasComment("Last Name is required!");
                entity.Property(x => x.Email)
                      .IsRequired()
                      .HasComment("Email is required!");
                entity.Property(x => x.Password)
                      .IsRequired()
                      .HasComment("Password is required!");

                entity.HasMany(x => x.Complaints)
                      .WithOne(r => r.user)
                      .HasForeignKey(r => r.UserId)
                      .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            });


            //User Complaint
            modelBuilder.Entity<Complaint>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Description)
                      .IsRequired()
                      .HasComment("Content is required!");
                entity.Property(x => x.Status)
                      .HasDefaultValue("pending");

                entity.HasMany(x => x.Demands)
                      .WithOne(r => r.Complaint)
                      .HasForeignKey(r => r.CompId)
                      .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            });


            //Deamnd
            modelBuilder.Entity<Demand>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Description)
                      .IsRequired()
                      .HasComment("Content is required!");

            });


            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(x => x.Fullname).IsRequired().HasComment("Full Name is required!");
                entity.Property(x => x.UserName).IsRequired().HasComment("User Name is required!");
                entity.Property(x => x.Email).IsRequired().HasComment("Email is required!");

            });




            base.OnModelCreating(modelBuilder);

        }

    }

}
