using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Domain
{
    public class Migration
    {
        private Migration(Guid id, string name, IEnumerable<MigrationScript> migrationScripts)
        {
            Id = id;
            Name = name;
            MigrationScripts = migrationScripts;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<MigrationScript> MigrationScripts { get; private set; }


        public static Migration CreateNew(string name)
            => new Migration(Guid.NewGuid(), name, Enumerable.Empty<MigrationScript>());

        public static Migration CreateNew(string name, IEnumerable<MigrationScript> migrationScripts)
            => new Migration(Guid.NewGuid(), name, migrationScripts);

        public static Migration Create(Guid id, string name, IEnumerable<MigrationScript> migrationScripts)
            => new Migration(id, name, migrationScripts);
        
        public static Migration Create(Guid id, string name)
            => new Migration(id, name, Enumerable.Empty<MigrationScript>());
        
    }
}
