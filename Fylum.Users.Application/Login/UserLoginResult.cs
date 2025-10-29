using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Application.Login
{
    public record UserLoginResult(bool Successful, Guid? UserId);
}
