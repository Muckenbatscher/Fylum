using Fylum.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Application.Login
{
    public record UserLoginCommand(string Username, string Password) : 
        ICommand<UserLoginResult>;
}
