using Fylum.PostgreSql.Shared.Connection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Shared
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPostgreSqlSharedServices(this IServiceCollection services, Action<DatabaseConnectionDetails> dbConnectionOptions)
        {
            services.AddConnectionDetails(dbConnectionOptions);
            services.AddConnectionServices();
            services.AddTableSpecMappingProviders();
            return services;
        }

        private static void AddConnectionDetails(this IServiceCollection services, Action<DatabaseConnectionDetails> dbConnectionOptions)
        {
            services.Configure<DatabaseConnectionDetails>(dbConnectionOptions);
        }
        private static void AddConnectionServices(this IServiceCollection services)
        {
            services.AddTransient<IConnectionStringProvider, ConnectionStringProvider>();
            services.AddScoped<IConnectionProvider, ConnectionProvider>();
            services.AddScoped<IOpenedConnectionProvider, OpenedConnectionProvider>();
        }
    }
}
