using Fylum.Domain.UnitOfWork;
using Fylum.Postgres.Shared.Connection;
using Fylum.Postgres.Shared.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Postgres.Shared
{
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
}
