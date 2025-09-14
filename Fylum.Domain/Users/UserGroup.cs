using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users
{
    public class UserGroup : IdentifiableEntity<Guid>
    {
        public string Name { get; set; }
    }
}
