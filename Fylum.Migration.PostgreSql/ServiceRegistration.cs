using Fylum.Migration.Application.PerformMigration;
using Fylum.Migration.Domain.PerformedMigrations;
using Fylum.Migration.Domain.UnitOfWork;
using Fylum.Migration.PostgreSql.PerformedMigrations;
using Fylum.Migration.PostgreSql.PerformMigration;
using Fylum.Migration.PostgreSql.ScriptExecution;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.PostgreSql
{
    public static class ServiceRegistration
    {
        public static void AddPostgreSqlMigrationPostgreSqlServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWorkTransactionFactory, UnitOfWorkTransactionFactory>();
            services.AddScoped<IPerformMigrationUnitOfWorkFactory, PerformMigrationUnitOfWorkFactory>();

            services.AddTransient<IPerformedMigrationsRepository, PerformedMigrationsRepository>();
            services.AddTransient<IMigrationPerformingService, MigrationPerformingService>();
            services.AddTransient<IScriptExecutor, ScriptExecutor>();
        }
    }
}
