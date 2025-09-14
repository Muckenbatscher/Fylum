using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users
{
    public class UserGroupMember : IdentifiableEntity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
    }
}
