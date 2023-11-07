using Application.Infrastructure.Abstracts;
using Application.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Core
{
    public static class ModuleCoreDependencies
    {

       

            public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
            {

                services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
                return services;

            }
        

    }
}