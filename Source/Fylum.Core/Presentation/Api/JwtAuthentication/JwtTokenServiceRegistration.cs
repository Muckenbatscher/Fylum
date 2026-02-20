using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Core.Presentation.Api.JwtAuthentication;

public static class JwtTokenServiceRegistration
{
    public static IServiceCollection AddJwtTokenCoreServices(this IServiceCollection services,
        Action<JwtAuthOptions> options)
    {
        services.Configure(options);
        services.AddTransient<IJwtTokenBuilder, JwtTokenBuilder>();

        return services;
    }
}