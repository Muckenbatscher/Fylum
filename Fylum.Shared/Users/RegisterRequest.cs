using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Shared.Users
{
    public record RegisterRequest(string Username, string Password);
}
