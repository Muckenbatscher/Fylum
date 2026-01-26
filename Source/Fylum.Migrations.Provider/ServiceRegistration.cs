using Fylum.Migrations.Domain.Providing;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Migrations.Provider;

public static class ServiceRegistration
{
    public static IServiceCollection AddMigrationProviderServices(this IServiceCollection services)
    {
        services.AddTransient<IMigrationsProvider, MigrationsProvider>();
        return services;
    }
}