using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Application
{
    public interface IPasswordHashCalculator
    {
        string Hash(string password);
        string Hash(string password, string salt);

        bool Verify(string password, string hash, string salt);
    }
}
