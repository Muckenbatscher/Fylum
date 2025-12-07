using Fylum.Application;
using Fylum.Users.Domain.RefreshTokens;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Users.Application.RefreshTokens;

internal class RefreshTokenUnitOfWorkFactory : UnitOfWorkFactory, IRefreshTokenUnitOfWorkFactory
{
    public RefreshTokenUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
    }

    public RefreshTokenUnitOfWork Create()
    {
        CreateScope();
        var transactionFactory = GetTransactionFactory();
        var refreshTokenRepository = GetScopedService<IRefreshTokenRepository>();
        return new RefreshTokenUnitOfWork(
            transactionFactory,
            refreshTokenRepository);
    }
}