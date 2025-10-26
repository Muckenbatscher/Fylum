using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Postgres
{
    public class UserQueryModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
