using Fylum.Core.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Core.Infrastructure.Postgres;

public static class PostgresServiceRegistration
{
    public static IServiceCollection AddPostgresCoreServices(this IServiceCollection services, 
        Action<DatabaseConnectionDetails> dbConnectionOptions)
    {
        services.AddScoped<IUnitOfWorkTransactionFactory, UnitOfWorkTransactionFactory>();

        services.AddConnectionDetails(dbConnectionOptions);
        services.AddConnectionServices();
        return services;
    }

    private static IServiceCollection AddConnectionDetails(this IServiceCollection services, 
        Action<DatabaseConnectionDetails> dbConnectionOptions)
    {
        services.Configure(dbConnectionOptions);
        return services;
    }
    private static IServiceCollection AddConnectionServices(this IServiceCollection services)
    {
        services.AddTransient<IConnectionStringProvider, ConnectionStringProvider>();
        services.AddScoped<IConnectionProvider, ConnectionProvider>();
        services.AddScoped<IOpenedConnectionProvider, OpenedConnectionProvider>();
        return services;
    }
}