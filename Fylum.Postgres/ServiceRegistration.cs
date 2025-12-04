using Fylum.Domain.Files;
using Fylum.Postgres.Files;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Postgres;

public static class ServiceRegistration
{
    public static IServiceCollection AddPostgresServices(this IServiceCollection services)
    {
        services.AddRepositories();
        return services;
    }


    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IFileRepository, FileRepository>();
    }
}