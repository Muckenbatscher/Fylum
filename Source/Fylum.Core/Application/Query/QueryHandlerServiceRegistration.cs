using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Fylum.Core.Application.Query;

public static class QueryHandlerServiceRegistration
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddQueryHandlers()
        {
            return services.AddQueryHandlers(Assembly.GetCallingAssembly());
        }

        public IServiceCollection AddQueryHandlers(Assembly assembly)
        {
            var implementationMap = GetImplementationMap(assembly);
            foreach (var implementation in implementationMap)
            {
                var handlerInterface = implementation.Key;
                var handlerImplementation = implementation.Value;
                services.AddTransient(handlerInterface, handlerImplementation);
            }
            return services;
        }
    }

    private static Dictionary<Type, Type> GetImplementationMap(Assembly assembly)
    {
        var implementationTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Where(ImplementsQueryHandlerInterface)
            .ToList();

        var implementationMap = new Dictionary<Type, Type>();
        foreach (var implementation in implementationTypes)
        {
            var interfaces = GetImplementedQueryHandlerInterfaces(implementation);
            foreach (var handlerInterface in interfaces)
            {
                if (implementationMap.ContainsKey(handlerInterface))
                {
                    throw new InvalidOperationException(
                        $"Found Conflict: The interface '{handlerInterface.Name}' has multiple implementations. ");
                }
                implementationMap.Add(handlerInterface, implementation);
            }
        }
        return implementationMap;
    }

    private static bool ImplementsQueryHandlerInterface(Type type)
        => GetImplementedQueryHandlerInterfaces(type).Any();

    private static IEnumerable<Type> GetImplementedQueryHandlerInterfaces(Type implementation)
    {
        var allInterfaces = implementation.GetInterfaces();
        var targetGeneric = typeof(IQueryHandler<,>);

        var directHandlers = allInterfaces
            .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == targetGeneric);

        var inheritedHandlers = allInterfaces
            .Where(i => i.GetInterfaces().Any(p =>
                p.IsGenericType && p.GetGenericTypeDefinition() == targetGeneric));

        return directHandlers.Union(inheritedHandlers);
    }
}

