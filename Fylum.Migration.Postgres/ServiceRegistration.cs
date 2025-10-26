using Fylum.Domain.UnitOfWork;
using Fylum.Migration.Application.PerformMigration;
using Fylum.Migration.Domain.PerformedMigrations;
using Fylum.Migration.Postgres.PerformedMigrations;
using Fylum.Migration.Postgres.PerformMigration;
using Fylum.Migration.Postgres.ScriptExecution;
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
        public static void AddMigrationPostgresServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWorkTransactionFactory, UnitOfWorkTransactionFactory>();
            services.AddScoped<IPerformMigrationUnitOfWorkFactory, PerformMigrationUnitOfWorkFactory>();

            services.AddTransient<IPerformedMigrationsRepository, PerformedMigrationsRepository>();
            services.AddTransient<IMigrationPerformingService, MigrationPerformingService>();
            services.AddTransient<IScriptExecutor, ScriptExecutor>();
        }
    }
}
