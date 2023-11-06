using Application.Infrastructure.Abstracts;
using Application.Infrastructure.Repositories;
using Application.Services.Abstracts;
using Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services
{
    public static class ModuleServiceDependencies
    {

        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {

            services.AddTransient<IUserService, UserService>();
            return services;

        }

    }
}