using Fylum.PostgreSql.Migration.Application.PerformMigration;
using Fylum.PostgreSql.Migration.Domain.PerformedMigrations;
using Fylum.PostgreSql.Migration.Domain.UnitOfWork;
using Fylum.PostgreSql.Migrations.PostgreSql.PerformedMigrations;
using Fylum.PostgreSql.Migrations.PostgreSql.PerformMigration;
using Fylum.PostgreSql.Migrations.PostgreSql.ScriptExecution;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migrations.PostgreSql
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
