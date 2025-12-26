using Fylum.Application;
using Fylum.Users.Application.Login;
using Fylum.Users.Application.Logout;
using Fylum.Users.Application.RefreshTokens;
using Fylum.Users.Application.Register;
using Fylum.Users.Domain.Password;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Users.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddUsersApplicationServices(this IServiceCollection services,
        Action<PasswordHashSettings> passwodHashSettingsOptions,
        Action<RefreshTokenOptions> refreshTokenOptions)
    {
        services.Configure(passwodHashSettingsOptions);
        services.Configure(refreshTokenOptions);

        services.AddTransient<IPasswordHashCalculator, PasswordHashCalculator>();
        services.AddTransient<IPasswordLoginVerification, PasswordLoginVerification>();

        services.AddUnitOfWorkFactories();

        services.AddCommandHandlers();

        return services;
    }
}