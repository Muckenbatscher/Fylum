using Fylum.Migrations.Application.GetMigrations;
using Fylum.Migrations.Application.Perform;
using Fylum.Migrations.Application.Perform.All;
using Fylum.Migrations.Application.Perform.UpTo;
using Fylum.Migrations.Domain;
using Fylum.Migrations.Domain.Perform;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Migrations.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddMigrationApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IMigrationService, MigrationService>();
        services.AddTransient<IMigrationPerformingService, MigrationPerformingService>();

        services.AddScoped<IPerformMigrationUnitOfWorkFactory, PerformMigrationUnitOfWorkFactory>();

        services.AddScoped<IGetMigrationCommandHandler, GetMigrationCommandHandler>();
        services.AddScoped<IGetAllMigrationsCommandHandler, GetAllMigrationsCommandHandler>();
        services.AddScoped<IPerformMigrationsUpToCommandHandler, PerformMigrationsUpToCommandHandler>();
        services.AddScoped<IPerformAllMigrationsCommandHandler, PerformAllMigrationsCommandHandler>();
        return services;
    }
}
