using Fylum.Application;
using Fylum.Domain.UnitOfWork;
using Fylum.Users.Domain.Password;
using Fylum.Users.Domain.Register;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Application.Register
{
    public class UserRegisterUnitOfWorkFactory : UnitOfWorkFactory, IUserRegisterUnitOfWorkFactory
    {
        public UserRegisterUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) : 
            base(serviceScopeFactory)
        {
        }

        public UserRegisterUnitOfWork Create()
        {
            CreateScope();

            var transactionFactory = GetTransactionFactory();
            var userRepository = GetScopedService<IUserWithPasswordRepository>();

            return new UserRegisterUnitOfWork(
                transactionFactory,
                userRepository);
        }
    }
}
