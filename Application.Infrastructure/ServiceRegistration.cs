//using Application.Data.Entities.Helpers;
//using Application.Data.Entities.Identity;
//using Application.Infrastructure.Data;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//namespace Application.Infrastructure
//{
//    public static class ServiceRegistration
//    {

//        public static IServiceCollection AddServiceRegistration(IServiceCollection services, IConfiguration configuration)
//        {

//            var jwtSettings = new JwtSettings();
//            configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);
//            services.AddSingleton(jwtSettings);
//            return services;

//        }
//    }
//}


//this commented cause it's done in program.cs no need to do this here