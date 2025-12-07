using Fylum.Application;
using Fylum.Users.Domain.Login;
using Fylum.Users.Domain.Password;
using Fylum.Users.Domain.RefreshTokens;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Users.Application.Login;

public class LoginUnitOfWorkFactory : UnitOfWorkFactory, ILoginUnitOfWorkFactory
{
    public LoginUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
    }

    public LoginUnitOfWork Create()
    {
        CreateScope();

        var transactionFactory = GetTransactionFactory();
        var userRepository = GetScopedService<IUserWithPasswordRepository>();
        var refreshTokenRepository = GetScopedService<IRefreshTokenRepository>();

        return new LoginUnitOfWork(
            transactionFactory,
            userRepository,
            refreshTokenRepository);
    }
}
