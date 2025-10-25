using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Application.Users
{
    public record UserLoginResult(bool Successful, string? Token);
}
