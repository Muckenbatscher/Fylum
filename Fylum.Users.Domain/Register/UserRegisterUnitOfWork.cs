using Fylum.Domain.UnitOfWork;
using Fylum.Users.Domain.Password;

namespace Fylum.Users.Domain.Register;

public class UserRegisterUnitOfWork : UnitOfWork
{
    public UserRegisterUnitOfWork(IUnitOfWorkTransactionFactory transactionFactory,
        IUserWithPasswordRepository userWithPasswordRepoitory)
        : base(transactionFactory)
    {
        UserWithPasswordRepository = userWithPasswordRepoitory;
    }

    public IUserWithPasswordRepository UserWithPasswordRepository { get; }
}