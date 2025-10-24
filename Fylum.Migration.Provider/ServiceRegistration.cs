using Fylum.Migration.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Provider
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPostgreSqlMigrationProviderServices(this IServiceCollection services)
        {
            services.AddTransient<IMigrationsProvider, MigrationsProvider>();
            return services;
        }
    }
}
