using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Domain
{
    public class PasswordLogin
    {
        private PasswordLogin(string passwordHash, string salt)
        {
            PasswordHash = passwordHash;
            Salt = salt;
        }

        public string PasswordHash { get; init; }
        public string Salt { get; init; }

        public static PasswordLogin Create(string passwordHash, string salt)
        {
            return new PasswordLogin(passwordHash, salt);
        }
    }
}
