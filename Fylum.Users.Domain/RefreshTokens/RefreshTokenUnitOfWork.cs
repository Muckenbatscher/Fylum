using Fylum.Domain.UnitOfWork;

namespace Fylum.Users.Domain.RefreshTokens;

public class RefreshTokenUnitOfWork : UnitOfWork
{
    public RefreshTokenUnitOfWork(IUnitOfWorkTransactionFactory transactionFactory,
        IRefreshTokenRepository refreshTokenRepository)
        : base(transactionFactory)
    {
        RefreshTokenRepository = refreshTokenRepository;
    }
    public IRefreshTokenRepository RefreshTokenRepository { get; }
}