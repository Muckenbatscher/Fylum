using Fylum.PostgreSql.Migration.Domain;
using Fylum.PostgreSql.Migration.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Provider
{
    public abstract class MigrationFromFiles
    {
        public abstract Guid Id { get; }
        public abstract string Name { get; }
        public abstract IEnumerable<FileInfo> MigrationScriptFiles { get; }

        public Domain.Migration CreateMigration()
        {
            var scripts = GetMigrationScripts();
            return Domain.Migration.Create(Id, Name, scripts);
        }

        private IEnumerable<MigrationScript> GetMigrationScripts()
        {
            return MigrationScriptFiles.Select(f => new MigrationScript(File.ReadAllText(f.FullName)));
        }
    }
}
