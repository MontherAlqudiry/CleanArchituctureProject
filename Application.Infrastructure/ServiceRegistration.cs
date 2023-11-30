//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.OpenApi.Models;

//namespace Application.Infrastructure
//{
//    public static class ServiceRegistration
//    {

//        public static IServiceCollection AddServiceRegistration(IServiceCollection services)
//        {
//            services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo { Title = "School Project", Version = "v1" });
//                c.EnableAnnotations();

//                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
//                {
//                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
//                    Name = "Authorization",
//                    In = ParameterLocation.Header,
//                    Type = SecuritySchemeType.ApiKey,
//                    Scheme = JwtBearerDefaults.AuthenticationScheme
//                });

//                c.AddSecurityRequirement(new OpenApiSecurityRequirement
//               {
//               {
//              new OpenApiSecurityScheme
//              {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = JwtBearerDefaults.AuthenticationScheme
//                }
//              },
//                 Array.Empty<string>()
//              }
//                     });
//            });

//            return services;

//        }
//    }
//}

//ON comment because it's  done by program.cs
