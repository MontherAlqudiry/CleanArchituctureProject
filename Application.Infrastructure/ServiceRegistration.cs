//using Application.Data.Entities.Identity;
//using Application.Infrastructure.Data;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.DependencyInjection;

//namespace Application.Infrastructure
//{
//    public static class ServiceRegistration
//    {

//        public static IServiceCollection AddServiceRegistration(IServiceCollection services)
//        {
//            services.AddIdentity<ApplicationUser>(
//               options =>
//               {
//                   // Password settings.
//                   options.Password.RequireDigit = true;
//                   options.Password.RequireLowercase = true;
//                   options.Password.RequireNonAlphanumeric = true;
//                   options.Password.RequireUppercase = true;
//                   options.Password.RequiredLength = 6;
//                   options.Password.RequiredUniqueChars = 1;

//                   // Lockout settings.
//                   options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(4);
//                   options.Lockout.MaxFailedAccessAttempts = 5;
//                   options.Lockout.AllowedForNewUsers = true;

//                   // User settings.
//                   options.User.AllowedUserNameCharacters =
//                   "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
//                   options.User.RequireUniqueEmail = false;



//               }).AddRoles<IdentityRole<int>>().AddEntityFrameworkStores<ApplicationDBContext>();

//            return services;

//        }
//    }
//}