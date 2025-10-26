using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMigrationApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMigrationService, MigrationService>();
            return services;
        }
    }
}
