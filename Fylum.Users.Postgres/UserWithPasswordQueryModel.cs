using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Postgres
{
    public class UserWithPasswordQueryModel
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public bool UserIsActive { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
    }
}
