using Fylum.Domain.UnitOfWork;
using Fylum.Users.Domain.RefreshTokens;

namespace Fylum.Users.Domain.Logout;

public class LogoutUnitOfWork : UnitOfWork
{
    public LogoutUnitOfWork(IUnitOfWorkTransactionFactory transactionFactory,
        IRefreshTokenRepository refreshTokenRepository)
        : base(transactionFactory)
    {
        RefreshTokenRepository = refreshTokenRepository;
    }

    public IRefreshTokenRepository RefreshTokenRepository { get; }
}
