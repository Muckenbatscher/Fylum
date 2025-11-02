using Fylum.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Application.Register
{
    public record UserRegisterCommand(string Username, string Password) : ICommand<UserRegisterResult>
    {
    }
}
