using Fylum.Core.Application.Command;
using Fylum.Core.Application.Query;
using Fylum.Core.Domain;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Fylum.Core;

public static class ServiceRegistration
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
            => services.AddCoreServices(Assembly.GetCallingAssembly());

    public static IServiceCollection AddCoreServices(this IServiceCollection services, Assembly assembly)
    {
        return services
            .AddUnitOfWorkFactories(assembly)
            .AddQueryHandlers(assembly)
            .AddCommandHandlers(assembly);
    }
}
