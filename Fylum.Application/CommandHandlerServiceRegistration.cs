using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Fylum.Application;

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
            if (interfaces.Count() > 1)
            {
                throw new InvalidOperationException(
                    $"Found Conflict: The class '{implementation.Name}' implements multiple ICommandHandler interfaces. " +
                    "Each command handler class should implement only one ICommandHandler interface.");
            }
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
        var interfaces = implementation.GetInterfaces()
            .Where(i => i.IsGenericType)
            .Where(i =>
            {
                var genericDef = i.GetGenericTypeDefinition();
                return genericDef == typeof(ICommandHandler<>)
                    || genericDef == typeof(ICommandHandler<,>);
            });
        return interfaces;
    }
}
