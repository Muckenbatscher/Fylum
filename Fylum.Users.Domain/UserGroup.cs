using Fylum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Domain
{
    public class UserGroup : IdentifiableEntity<Guid>
    {
        private UserGroup(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; }

        public static UserGroup Create(Guid id, string name)
            => new UserGroup(id, name);

        public static UserGroup CreateNew(string name)
            => new UserGroup(Guid.NewGuid(), name);
    }
}
