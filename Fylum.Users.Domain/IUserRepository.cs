using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Domain
{
    public interface IUserRepository
    {
        User GetById(int id);
    }
}
