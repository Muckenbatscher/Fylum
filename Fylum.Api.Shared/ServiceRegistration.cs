using Fylum.Api.Shared.JwtAuthentication;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Api.Shared;

public static class ServiceRegistration
{
    public static IServiceCollection AddApiSharedServices(this IServiceCollection services,
        Action<JwtAuthOptions> options)
    {
        services.Configure<JwtAuthOptions>(options);
        services.AddTransient<IJwtAuthService, JwtAuthService>();

        return services;
    }
}