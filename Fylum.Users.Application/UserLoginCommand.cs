using Fylum.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Application
{
    public record UserLoginCommand(UserLoginParameter Parameter) : 
        IResultCommand<UserLoginParameter, UserLoginResult>;
}
