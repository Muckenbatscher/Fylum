using Fylum.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Domain.Register
{
    public interface IUserRegisterUnitOfWorkFactory : IUnitOfWorkFactory<UserRegisterUnitOfWork>
    {
    }
}
