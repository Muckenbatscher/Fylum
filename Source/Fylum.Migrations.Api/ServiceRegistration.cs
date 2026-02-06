using Fylum.Core.Application.Command;
using Fylum.Core.Application.Mapping;
using Fylum.Core.Application.Query;
using Fylum.Core.Domain;
using Fylum.Core.Infrastructure.Postgres;
using Fylum.Migrations.Api.Common.Domain;
using Fylum.Migrations.Api.Common.Domain.Perform;
using Fylum.Migrations.Api.Common.Domain.Providing;
using Fylum.Migrations.Api.Common.Infrastructure.Postgres;
using Fylum.Migrations.Api.Common.Infrastructure.Providing;
using Fylum.Migrations.Api.PerformingAuthentication;

namespace Fylum.Migrations.Api;

public static class ServiceRegistration
{
    public static IServiceCollection AddMigrationsServices(this IServiceCollection services)
    {
        // Domain
        services.AddTransient<IMigrationService, MigrationService>();
        services.AddTransient<IMigrationPerformingService, MigrationPerformingService>();
        services.AddScoped<IUnitOfWorkTransactionFactory, UnitOfWorkTransactionFactory>();
        services.AddUnitOfWorkFactories();
        // Application
        services.AddCommandHandlers();
        services.AddQueryHandlers();
        services.AddMappers();
        // Infrastructure - Postgres
        services.AddTransient<IPerformedMigrationsRepository, PerformedMigrationsRepository>();
        services.AddTransient<IScriptExecutor, ScriptExecutor>();
        // Infrastructure - Providing
        services.AddTransient<IMigrationsProvider, MigrationsProvider>();
        // Presentation - Auth
        services.AddScoped<IPerformingKeyRequestValidator, PerformingKeyRequestValidator>();

        return services;
    }
}