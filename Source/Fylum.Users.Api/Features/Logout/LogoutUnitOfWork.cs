using Fylum.Core.Domain;
using Fylum.Users.Api.Common.Domain.RefreshToken;

namespace Fylum.Users.Api.Features.Logout;

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
