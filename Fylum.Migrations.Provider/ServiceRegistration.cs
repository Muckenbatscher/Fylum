using Fylum.Migrations.Domain.Providing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migrations.Provider
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMigrationProviderServices(this IServiceCollection services)
        {
            services.AddTransient<IMigrationsProvider, MigrationsProvider>();
            return services;
        }
    }
}
