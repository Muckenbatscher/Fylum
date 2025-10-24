namespace Fylum.Api.EndpointRouteDefinitions
{
    public static class EndpointDefinitionRegistrationExtension
    {
        public static IServiceCollection AddEndpointRouteDefinitions(this IServiceCollection services)
        {
            var endpointRouteDefinitionProviderType = typeof(IEndpointRouteDefinitionProvider);
            var implementations = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => endpointRouteDefinitionProviderType.IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);
            foreach (var implementation in implementations)
            {
                var interfaces = implementation.GetInterfaces()
                    .Except([endpointRouteDefinitionProviderType]);
                foreach (var iface in interfaces)
                {
                    if (endpointRouteDefinitionProviderType.IsAssignableFrom(iface) && !services.Any(x => x.ServiceType == iface))
                        services.AddTransient(iface, implementation);
                }
            }
            return services;
        }
    }
}
