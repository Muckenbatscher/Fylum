using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Domain
{
    public class UsernameAlreadyExistsException : Exception
    {
        public string Username { get; }
        public override string Message => $"The username '{Username}' is already taken.";

        public UsernameAlreadyExistsException(string username)
        {
            Username = username;
        }

    }
}
