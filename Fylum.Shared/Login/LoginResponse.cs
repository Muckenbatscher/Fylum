using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Login
{
    public class LoginResponse
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
    }
}
