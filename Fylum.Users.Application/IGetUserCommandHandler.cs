using Fylum.Application;
using Fylum.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Application
{
    public interface IGetUserCommandHandler : ICommandHandler<GetUserCommand, User>
    {
    }
}
