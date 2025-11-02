using Fylum.Migration.Domain.Perform;
using Fylum.Migration.Postgres.Perform;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Postgres
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMigrationPostgresServices(this IServiceCollection services)
        {
            services.AddTransient<IPerformedMigrationsRepository, PerformedMigrationsRepository>();
            services.AddTransient<IScriptExecutor, ScriptExecutor>();
            return services;
        }
    }
}
