using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Shared
{
    internal class DiscoveredTableSpecMappingProvider
    {
        public Type ImplementationType { get; }
        public Type ServiceType { get; }

        public DiscoveredTableSpecMappingProvider(Type implementationType, Type serviceType)
        {
            ImplementationType = implementationType;
            ServiceType = serviceType;
        }

        public void AddTransientTo(IServiceCollection services)
        {
            services.AddTransient(ServiceType, ImplementationType);
        }
    }
}
