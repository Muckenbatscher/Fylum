using Fylum.Migrations.Domain.Perform;
using Fylum.Migrations.Postgres.Perform;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Migrations.Postgres;

public static class ServiceRegistration
{
    public static IServiceCollection AddMigrationPostgresServices(this IServiceCollection services)
    {
        services.AddTransient<IPerformedMigrationsRepository, PerformedMigrationsRepository>();
        services.AddTransient<IScriptExecutor, ScriptExecutor>();
        return services;
    }
}