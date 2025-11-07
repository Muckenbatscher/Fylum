using Fylum.Migration.Application;
using Fylum.Migration.Postgres;
using Fylum.Migration.Provider;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migrations.Api
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMigrationsServices(this IServiceCollection services)
        {
            services.AddMigrationApplicationServices();
            services.AddMigrationPostgresServices();
            services.AddMigrationProviderServices();
            return services;
        }
    }
}
