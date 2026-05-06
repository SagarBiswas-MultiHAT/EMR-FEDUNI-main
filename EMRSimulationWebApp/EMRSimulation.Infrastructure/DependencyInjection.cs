using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EMRSimulation.Infrastructure.Repositories;
using EMRSimulation.Application.Services;
using EMRSimulation.Infrastructure.Connection;
using EMRSimulation.Application.Interfaces;

namespace EMRSimulation.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register repositories and other infrastructure services
            services.AddRepositories(configuration);

            // You can also register other services here
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILoginService, LoginService>();

            services.AddScoped<ILabRepository, LabRepository>();
            services.AddScoped<ILabService, LabService>();

            services.AddScoped<IPatientService, PatientService>();
            return services;
        }
    }
}
