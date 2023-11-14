using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Core
{
    public static class ModuleCoreDependencies
    {



        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            ///Configuration of MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //Configuration of AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;

        }


    }
}