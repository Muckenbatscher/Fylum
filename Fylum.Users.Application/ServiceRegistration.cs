using Fylum.Application;
using Fylum.Users.Application.GetUser;
using Fylum.Users.Application.Login;
using Fylum.Users.Application.Logout;
using Fylum.Users.Application.RefreshTokens;
using Fylum.Users.Application.Register;
using Fylum.Users.Domain;
using Fylum.Users.Domain.Login;
using Fylum.Users.Domain.Logout;
using Fylum.Users.Domain.Password;
using Fylum.Users.Domain.RefreshTokens;
using Fylum.Users.Domain.Register;
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

        services.AddScoped<ILoginUnitOfWorkFactory, LoginUnitOfWorkFactory>();
        services.AddScoped<ILogoutUnitOfWorkFactory, LogoutUnitOfWorkFactory>();
        services.AddScoped<IUserRegisterUnitOfWorkFactory, UserRegisterUnitOfWorkFactory>();
        services.AddScoped<IRefreshTokenUnitOfWorkFactory, RefreshTokenUnitOfWorkFactory>();

        services.AddTransient<ICommandHandler<UserLoginCommand, UserLoginResult>, UserLoginCommandHandler>();
        services.AddTransient<ICommandHandler<LogoutCommand>, LogoutCommandHandler>();
        services.AddTransient<ICommandHandler<UserRegisterCommand, UserRegisterResult>, UserRegisterCommandHandler>();
        services.AddTransient<ICommandHandler<TokenRefreshCommand, TokenRefreshResult>, TokenRefreshCommandHandler>();
        services.AddTransient<ICommandHandler<GetUserCommand, User>, GetUserCommandHandler>();

        return services;
    }
}