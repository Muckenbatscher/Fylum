using Fylum.Migrations.Api.Common.Application;
using Fylum.Migrations.Api.Common.Domain;
using Fylum.Migrations.Api.Common.Domain.Providing;
using Fylum.Migrations.Api.PerformingAuthentication;
using Fylum.Migrations.Application;
using Fylum.Migrations.Domain;
using Fylum.Migrations.Domain.Providing;
using Fylum.Migrations.Postgres;
using Fylum.Migrations.Provider;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api;

public static class ServiceRegistration
{
    public static IServiceCollection AddMigrationsServices(this IServiceCollection services)
    {
        services.AddMigrationApplicationServices();
        services.AddMigrationPostgresServices();
        services.AddMigrationProviderServices();

        services.AddScoped<IPerformingKeyRequestValidator, PerformingKeyRequestValidator>();

        services.AddTransient<IMapper<MigrationScript, MigrationScriptDto>, MigrationScriptDtoMapper>();
        services.AddTransient<IMapper<Migration, MigrationDto>, MigrationDtoMapper>();

        return services;
    }
}