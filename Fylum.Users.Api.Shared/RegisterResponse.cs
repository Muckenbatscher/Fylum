using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Api.Shared
{
    public record RegisterResponse(Guid UserId, string Token);
}
