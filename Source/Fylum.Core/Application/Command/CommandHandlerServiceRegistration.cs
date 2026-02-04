using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Fylum.Core.Application.Command;

public static class CommandHandlerServiceRegistration
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddCommandHandlers()
        {
            return services.AddCommandHandlers(Assembly.GetCallingAssembly());
        }

        public IServiceCollection AddCommandHandlers(Assembly assembly)
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
            .Where(ImplementsCommandHandlerInterface)
            .ToList();

        var implementationMap = new Dictionary<Type, Type>();
        foreach (var implementation in implementationTypes)
        {
            var interfaces = GetImplementedCommandHandlerInterface(implementation);
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

    private static bool ImplementsCommandHandlerInterface(Type type)
        => GetImplementedCommandHandlerInterface(type).Any();

    private static IEnumerable<Type> GetImplementedCommandHandlerInterface(Type implementation)
    {
        var allInterfaces = implementation.GetInterfaces();
        var targetDefinitions = new[]
        {
            typeof(ICommandHandler<>),
            typeof(ICommandHandler<,>)
        };

        var directHandlers = allInterfaces
            .Where(i => i.IsGenericType && targetDefinitions.Contains(i.GetGenericTypeDefinition()));

        var inheritedHandlers = allInterfaces
            .Where(i => i.GetInterfaces().Any(parent =>
                parent.IsGenericType && targetDefinitions.Contains(parent.GetGenericTypeDefinition())));

        return directHandlers.Union(inheritedHandlers);
    }
}
