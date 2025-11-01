using Fylum.Migration.Application.Perform;
using Fylum.Migration.Domain.Perform;
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
            services.AddTransient<IMigrationWithAppliedStateService, MigrationWithAppliedStateService>();
            services.AddTransient<IMigrationPerformingService, MigrationPerformingService>();

            services.AddScoped<IPerformMigrationUnitOfWorkFactory, PerformMigrationUnitOfWorkFactory>();
            return services;
        }
    }
}
