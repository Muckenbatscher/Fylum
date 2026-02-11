using Fylum.Domain.UnitOfWork;
using Fylum.Users.Api.Common.Domain.RefreshToken;

namespace Fylum.Users.Api.Features.RefreshAccessToken;

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