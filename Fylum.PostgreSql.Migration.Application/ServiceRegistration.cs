using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPostgreSqlMigrationApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMigrationService, MigrationService>();
            return services;
        }
    }
}
