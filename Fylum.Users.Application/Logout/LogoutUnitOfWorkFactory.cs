using Fylum.Application;
using Fylum.Users.Domain.Logout;
using Fylum.Users.Domain.RefreshTokens;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Users.Application.Logout;

public class LogoutUnitOfWorkFactory : UnitOfWorkFactory, ILogoutUnitOfWorkFactory
{
    public LogoutUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
    }

    public LogoutUnitOfWork Create()
    {
        CreateScope();

        var transactionFactory = GetTransactionFactory();
        var refreshTokenRepository = GetScopedService<IRefreshTokenRepository>();

        return new LogoutUnitOfWork(
            transactionFactory,
            refreshTokenRepository);
    }
}
