using Fylum.PostgreSql.TableSpec;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql
{
    public static class TableSpecMappingDiscovery
    {
        public static void AddTableSpecMappingProviders(this IServiceCollection services)
        {
            services.AddTransient<IPostgresColumnNameTranslator, PostgresColumnNameTranslator>();
            services.AddDiscoveredMappingProviders();
        }

        private static void AddDiscoveredMappingProviders(this IServiceCollection services)
        {
            var implementations = GetDiscoveredTableSpecMappingProviders();
            foreach (var implementation in implementations)
                implementation.AddTransientTo(services);
        }

        private static IEnumerable<DiscoveredTableSpecMappingProvider> GetDiscoveredTableSpecMappingProviders()
        {
            return typeof(TableSpecMappingDiscovery).Assembly.GetTypes()
                .Where(IsImplementationOfMappingSpecProvider)
                .Select(implementationType =>
                {
                    var interfaceType = GetGenericMappingSpecProviderInterface(implementationType)!;
                    return new DiscoveredTableSpecMappingProvider(implementationType, interfaceType);
                });
        }
        private static bool IsImplementationOfMappingSpecProvider(Type implementationType)
        {
            if (!implementationType.IsClass || implementationType.IsAbstract)
                return false;

            var mappingProviderInterface = GetGenericMappingSpecProviderInterface(implementationType);
            return mappingProviderInterface != null;
        }
        private static Type? GetGenericMappingSpecProviderInterface(Type implementationType)
        {
            var openGenericInterface = typeof(IEntityTableMappingSpecProvider<,>);
            var implementedGenericInterfaces = implementationType.GetInterfaces()
                .Where(interfaceType => interfaceType.IsGenericType);
            var matchingInterfaces = implementedGenericInterfaces
                .Where(interfaceType => interfaceType.GetGenericTypeDefinition() == openGenericInterface);

            return matchingInterfaces.SingleOrDefault();
        }

    }
}
