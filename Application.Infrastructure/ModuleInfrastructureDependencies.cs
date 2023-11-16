using Application.Infrastructure.Abstracts;
using Application.Infrastructure.Bases;
using Application.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Infrastructure
{
    public static class ModuleInfrastructureDepandancies
    {

        public static IServiceCollection AddInfrastructureDepandancies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IComplaintRepository, ComplaintRepository>();
            services.AddScoped<IDemandRepository, DemandRepository>();
            return services;

        }
    }
}
