using Fylum.Domain.UnitOfWork;
using Fylum.Infrastructure.Postgres.Shared.Connection;
using Fylum.Infrastructure.Postgres.Shared.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Infrastructure.Postgres.Shared;

public static class ServiceRegistration
{
    public static IServiceCollection AddPostgresSharedServices(this IServiceCollection services, Action<DatabaseConnectionDetails> dbConnectionOptions)
    {
        services.AddScoped<IUnitOfWorkTransactionFactory, UnitOfWorkTransactionFactory>();

        services.AddConnectionDetails(dbConnectionOptions);
        services.AddConnectionServices();
        services.AddTableSpecMappingProviders();
        return services;
    }

    private static void AddConnectionDetails(this IServiceCollection services, Action<DatabaseConnectionDetails> dbConnectionOptions)
    {
        services.Configure(dbConnectionOptions);
    }
    private static void AddConnectionServices(this IServiceCollection services)
    {
        services.AddTransient<IConnectionStringProvider, ConnectionStringProvider>();
        services.AddScoped<IConnectionProvider, ConnectionProvider>();
        services.AddScoped<IOpenedConnectionProvider, OpenedConnectionProvider>();
    }
}