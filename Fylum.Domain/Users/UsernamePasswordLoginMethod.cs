using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users
{
    public class UsernamePasswordLoginMethod : IdentifiableEntity<Guid>, ILoginMethod
    {
        public Guid UserId { get; set; }
        public string PasswordHash { get; set; }
    }
}
