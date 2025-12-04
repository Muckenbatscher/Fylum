using Fylum.Migrations.Api.PerformingAuthentication;
using Fylum.Migrations.Application;
using Fylum.Migrations.Postgres;
using Fylum.Migrations.Provider;

namespace Fylum.Migrations.Api;

public static class ServiceRegistration
{
    public static IServiceCollection AddMigrationsServices(this IServiceCollection services)
    {
        services.AddMigrationApplicationServices();
        services.AddMigrationPostgresServices();
        services.AddMigrationProviderServices();

        services.AddScoped<IPerformingKeyRequestValidator, PerformingKeyRequestValidator>();
        return services;
    }
}