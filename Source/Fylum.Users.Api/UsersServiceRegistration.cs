using Fylum.Application;
using Fylum.Users.Api.Common.Application.PasswordHash;
using Fylum.Users.Api.Common.Domain;
using Fylum.Users.Api.Common.Domain.Password;
using Fylum.Users.Api.Common.Domain.RefreshToken;
using Fylum.Users.Api.Common.Infrastructure.Postgres;
using Fylum.Users.Api.Features.Login;
using Fylum.Users.Api.Features.RefreshAccessToken;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Users.Api;

public static class UsersServiceRegistration
{
    public static IServiceCollection AddUsersServices(this IServiceCollection services,
        Action<PasswordHashSettings> passwodHashSettingsOptions,
        Action<RefreshTokenOptions> refreshTokenOptions)
    {
        services.Configure(passwodHashSettingsOptions);
        services.Configure(refreshTokenOptions);

        services.AddTransient<IPasswordHashCalculator, PasswordHashCalculator>();
        services.AddTransient<IPasswordLoginVerification, PasswordLoginVerification>();

        services.AddUnitOfWorkFactories();

        services.AddCommandHandlers();
        services.AddQueryHandlers();

        services.AddPostgresRepositories();

        return services;
    }

    private static IServiceCollection AddPostgresRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserWithPasswordRepository, UserWithPasswordRepository>()
            .AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
    }
}