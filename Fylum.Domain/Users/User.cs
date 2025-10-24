using Fylum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Domain.Users
{
    public class User : IdentifiableEntity<Guid>
    {
        public string Username { get; set; }
        public bool IsActive { get; set; }
    }
}
