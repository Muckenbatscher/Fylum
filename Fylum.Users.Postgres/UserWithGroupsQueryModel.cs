using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Postgres
{
    internal class UserWithGroupsQueryModel
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public Guid? UserGroupId { get; set; }
        public string? UserGroupName { get; set; }
    }
}
