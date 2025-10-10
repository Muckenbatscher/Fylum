using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Domain.PerformedMigrations
{
    public class Migration
    {
        public Guid Id { get; }
        public string Name { get; }

        private Migration(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Migration Create(Guid id, string name)
        {
            return new Migration(id, name);
        }
        public static Migration CreateNew(string name)
        {
            return new Migration(Guid.NewGuid(), name);
        }
    }
}
