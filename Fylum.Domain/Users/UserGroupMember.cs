using Fylum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Domain.Users
{
    public class UserGroupMember
    {
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
    }
}
