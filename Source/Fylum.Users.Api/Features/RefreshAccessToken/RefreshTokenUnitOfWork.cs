using Fylum.Core.Domain;
using Fylum.Users.Api.Common.Domain;
using Fylum.Users.Api.Common.Domain.RefreshToken;

namespace Fylum.Users.Api.Features.RefreshAccessToken;

public class RefreshTokenUnitOfWork : UnitOfWork
{
    public RefreshTokenUnitOfWork(IUnitOfWorkTransactionFactory transactionFactory,
        IRefreshTokenRepository refreshTokenRepository,
        IUserRepository userRepository)
        : base(transactionFactory)
    {
        RefreshTokenRepository = refreshTokenRepository;
        UserRepository = userRepository;
    }

    public IRefreshTokenRepository RefreshTokenRepository { get; }
    public IUserRepository UserRepository { get; }
}