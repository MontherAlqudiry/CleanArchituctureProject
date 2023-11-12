using Application.Infrastructure.Abstracts;
using Application.Infrastructure.Bases;
using Application.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Infrastructure
{
    public static class ModuleInfrastructureDepandancies
    {

        public static IServiceCollection AddInfrastructureDepandancies(this IServiceCollection services) {

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            return services;
        
        }
    }
}
