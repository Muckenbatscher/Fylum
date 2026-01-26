using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Postgres.Shared;

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