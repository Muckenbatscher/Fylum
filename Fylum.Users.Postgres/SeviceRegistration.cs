using Fylum.Users.Domain;
using Fylum.Users.Domain.Groups;
using Fylum.Users.Domain.Password;
using Fylum.Users.Domain.RefreshTokens;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Users.Postgres;

public static class SeviceRegistration
{
    public static void AddUsersPostgresServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserWithPasswordRepository, UserWithPasswordRepository>();
        services.AddScoped<IUserWithGroupsRepository, UserWithGroupsRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
    }
}