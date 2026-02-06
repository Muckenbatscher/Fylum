using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Fylum.Core.Application.Mapping;

public static class MapperServiceRegistration
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddMappers()
        {
            return services.AddMappers(Assembly.GetCallingAssembly());
        }

        public IServiceCollection AddMappers(Assembly assembly)
        {
            var implementationMap = GetImplementationMap(assembly);
            foreach (var implementation in implementationMap)
            {
                var mapperInterface = implementation.Key;
                var mapperImplementation = implementation.Value;
                services.AddTransient(mapperInterface, mapperImplementation);

                if (mapperInterface.GetGenericTypeDefinition() == typeof(IMapper<,>))
                {
                    var genericTypeArgs = mapperInterface.GetGenericArguments();
                    var enumerableInterface = typeof(IMapper<,>).MakeGenericType(
                        typeof(IEnumerable<>).MakeGenericType(genericTypeArgs[0]),
                        typeof(IEnumerable<>).MakeGenericType(genericTypeArgs[1])
                    );
                    var enumerableImplementation = typeof(IEnumerableMapper<,>).MakeGenericType(genericTypeArgs);
                    services.AddTransient(enumerableInterface, enumerableImplementation);
                }
            }

            return services;
        }
    }

    private static Dictionary<Type, Type> GetImplementationMap(Assembly assembly)
    {
        var implementationTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Where(ImplementsMapperInterface)
            .ToList();

        var implementationMap = new Dictionary<Type, Type>();
        foreach (var implementation in implementationTypes)
        {
            var interfaces = GetImplementedMapperInterfaces(implementation);
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

    private static bool ImplementsMapperInterface(Type type)
        => GetImplementedMapperInterfaces(type).Any();

    private static IEnumerable<Type> GetImplementedMapperInterfaces(Type implementation)
    {
        var allInterfaces = implementation.GetInterfaces();
        var targetGeneric = typeof(IMapper<,>);

        var directMappers = allInterfaces
            .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == targetGeneric);

        var inheritedMappers = allInterfaces
            .Where(i => i.GetInterfaces().Any(p =>
                p.IsGenericType && p.GetGenericTypeDefinition() == targetGeneric));

        return directMappers.Union(inheritedMappers);
    }
}
