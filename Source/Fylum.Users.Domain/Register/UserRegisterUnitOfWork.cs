using Fylum.Domain.UnitOfWork;
using Fylum.Users.Domain.Password;
using Fylum.Users.Domain.RefreshTokens;

namespace Fylum.Users.Domain.Register;

public class UserRegisterUnitOfWork : UnitOfWork
{
    public UserRegisterUnitOfWork(IUnitOfWorkTransactionFactory transactionFactory,
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