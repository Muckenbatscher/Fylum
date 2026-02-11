using Fylum.Domain.UnitOfWork;
using Fylum.Users.Api.Common.Domain.Password;
using Fylum.Users.Api.Common.Domain.RefreshToken;

namespace Fylum.Users.Api.Features.Login;

public class LoginUnitOfWork : UnitOfWork
{
    public LoginUnitOfWork(IUnitOfWorkTransactionFactory transactionFactory,
        IUserWithPasswordRepository userWithPasswordRepoitory,
        IRefreshTokenRepository refreshTokenRepository)
        : base(transactionFactory)
    {
        UserWithPasswordRepository = userWithPasswordRepoitory;
        RefreshTokenRepository = refreshTokenRepository;
    }

    public IUserWithPasswordRepository UserWithPasswordRepository { get; }
    public IRefreshTokenRepository RefreshTokenRepository { get; }
}