using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Domain.Password
{
    public interface IPasswordLoginVerification
    {
        bool VerifyPasswordLogin(string password, PasswordLogin login);
    }
}
