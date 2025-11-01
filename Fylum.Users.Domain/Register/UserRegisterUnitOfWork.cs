using Fylum.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Domain.Register
{
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
}
