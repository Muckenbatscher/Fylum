using Fylum.Migrations.Application.GetMigrations;
using Fylum.Migrations.Application.MinimallyRequired;
using Fylum.Migrations.Application.Perform;
using Fylum.Migrations.Application.WithPerformedState;
using Fylum.Migrations.Domain.Perform;
using Fylum.Migrations.Domain.WithPerformedState;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Migrations.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddMigrationApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IMigrationWithPerformedStateService, MigrationWithPerformedStateService>();
        services.AddTransient<IMigrationPerformingService, MigrationPerformingService>();

        services.AddScoped<IPerformMigrationUnitOfWorkFactory, PerformMigrationUnitOfWorkFactory>();
        services.AddScoped<IMinimallyRequiredMigrationService, MinimallyRequiredMigrationService>();

        services.AddScoped<IGetMigrationCommandHandler, GetMigrationCommandHandler>();
        services.AddScoped<IGetAllMigrationsCommandHandler, GetAllMigrationsCommandHandler>();
        return services;
    }
}
