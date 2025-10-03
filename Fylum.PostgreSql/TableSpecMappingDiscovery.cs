using Fylum.Connection;
using Fylum.TableSpec;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum
{
    internal static class TableSpecMappingDiscovery
    {
        internal static void AddTableSpecMappingProviders(this IServiceCollection services)
        {
            services.AddDiscoveredMappingProviders();
            services.AddTransient<IPostgresColumnNameTranslator, PostgresColumnNameTranslator>();
        }

        private static void AddDiscoveredMappingProviders(this IServiceCollection services)
        {
            var openGenericInterface = typeof(IEntityTableMappingSpecProvider<,>);

            var implementations = typeof(TableSpecMappingDiscovery).Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(implementationType => new
                {
                    ImplementationType = implementationType,
                    ServiceInterface = implementationType.GetInterfaces().FirstOrDefault(interfaceType =>
                        interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == openGenericInterface)
                })
                .Where(x => x.ServiceInterface != null);


            foreach (var item in implementations)
                services.AddTransient(item.ServiceInterface!, item.ImplementationType);
        }
    }
}
