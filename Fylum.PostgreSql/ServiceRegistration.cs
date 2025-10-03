using Fylum.Connection;
using Fylum.Files;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPostgreSqlServices(this IServiceCollection services, Action<DatabaseConnectionDetails> dbConnectionOptions)
        {
            services.AddConnectionDetails(dbConnectionOptions);
            services.AddConnectionServices();
            services.AddRepositories();
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
            services.AddTransient<IConnectionProvider, ConnectionProvider>();
            services.AddTransient<IOpenedConnectionProvider, OpenedConnectionProvider>();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IFileRepository, FileRepository>();
        }
    }
}
