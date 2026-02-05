using Fylum.Core.Application.Command;
using Fylum.Core.Application.Mapping;
using Fylum.Core.Application.Query;
using Fylum.Core.Domain;
using Fylum.Core.Infrastructure.Postgres;
using Fylum.Migrations.Api.Common.Application;
using Fylum.Migrations.Api.Common.Domain;
using Fylum.Migrations.Api.Common.Domain.Perform;
using Fylum.Migrations.Api.Common.Domain.Providing;
using Fylum.Migrations.Api.Common.Infrastructure.Postgres;
using Fylum.Migrations.Api.Common.Infrastructure.Providing;
using Fylum.Migrations.Api.PerformingAuthentication;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api;

public static class ServiceRegistration
{
    public static IServiceCollection AddMigrationsServices(this IServiceCollection services)
    {
        // Domain
        services.AddTransient<IMigrationService, MigrationService>();
        services.AddTransient<IMigrationPerformingService, MigrationPerformingService>();
        services.AddScoped<IUnitOfWorkTransactionFactory, UnitOfWorkTransactionFactory>();
        services.AddUnitOfWorkFactories(typeof(Program).Assembly);
        // Application
        services.AddCommandHandlers(typeof(Program).Assembly);
        services.AddQueryHandlers(typeof(Program).Assembly);
        services.AddTransient<IMapper<MigrationScript, MigrationScriptDto>, MigrationScriptDtoMapper>();
        services.AddTransient<IMapper<Migration, MigrationDto>, MigrationDtoMapper>();
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