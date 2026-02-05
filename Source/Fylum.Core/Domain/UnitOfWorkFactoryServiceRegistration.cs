using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Fylum.Core.Domain;

public static class UnitOfWorkFactoryServiceRegistration
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddUnitOfWorkFactories()
            => services.AddUnitOfWorkFactories(Assembly.GetCallingAssembly());

        public IServiceCollection AddUnitOfWorkFactories(Assembly assembly)
        {
            var implementationTypes = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Where(ImplementsUnitOfWorkFactory)
                .ToList();

            var implementationMap = new Dictionary<Type, Type>();
            foreach (var implementation in implementationTypes)
            {
                var interfaces = GetImplementedUnitOfWorkFactoryInterfaces(implementation);
                foreach (var handlerInterface in interfaces)
                {
                    if (implementationMap.ContainsKey(handlerInterface))
                    {
                        throw new InvalidOperationException(
                            $"Found Conflict: The interface '{handlerInterface.Name}' has multiple implementations. ");
                    }
                    services.AddScoped(handlerInterface, implementation);
                }
            }
            return services;
        }
    }

    private static bool ImplementsUnitOfWorkFactory(Type type)
        => GetImplementedUnitOfWorkFactoryInterfaces(type).Any();

    private static IEnumerable<Type> GetImplementedUnitOfWorkFactoryInterfaces(Type implementation)
    {
        var allInterfaces = implementation.GetInterfaces();
        var targetGeneric = typeof(IUnitOfWorkFactory<>);

        // IUnitOfWorkFactory<MyType>
        var directGenericInterfaces = allInterfaces
            .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == targetGeneric);

        // IMyTypedInterface : IUnitOfWorkFactory<MyUnitOfWorkType>
        var inheritedTypedInterfaces = allInterfaces
            .Where(i => i.GetInterfaces().Any(p => p.IsGenericType && p.GetGenericTypeDefinition() == targetGeneric));

        return directGenericInterfaces.Union(inheritedTypedInterfaces);
    }
}