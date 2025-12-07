using Fylum.Domain.UnitOfWork;
using Fylum.Users.Domain.Password;
using Fylum.Users.Domain.RefreshTokens;

namespace Fylum.Users.Domain.Login;

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
