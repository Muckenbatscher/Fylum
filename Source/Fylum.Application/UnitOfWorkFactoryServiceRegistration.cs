using Fylum.Domain.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Fylum.Application;

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
                if (interfaces.Count() > 1)
                {
                    throw new InvalidOperationException(
                        $"Found Conflict: The class '{implementation.Name}' implements multiple IUnitOfWorkFactory interfaces. " +
                        "Each UnitOfWorkFactory class should implement only one IUnitOfWorkFactory interface.");
                }
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
        var interfaces = implementation.GetInterfaces()
            .Where(i => i.IsGenericType)
            .Where(i =>
            {
                var genericDef = i.GetGenericTypeDefinition();
                return genericDef == typeof(IUnitOfWorkFactory<>);
            });
        return interfaces;
    }
}