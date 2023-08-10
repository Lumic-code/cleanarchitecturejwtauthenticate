﻿using CleanArchitecture.Infra.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSqlServer<DemoDBContext>(Configuration.GetConnectionString("DefaultConnection"));
 
            return services;
        }
    }
}