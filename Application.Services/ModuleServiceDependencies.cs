using Application.Services.Abstracts;
using Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services
{
    public static class ModuleServiceDependencies
    {

        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {

            services.AddScoped<IUserService, UserService>();
            return services;

        }

    }
}