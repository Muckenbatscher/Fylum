using Fylum.Migrations.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migrations.Provider
{
    public abstract class MigrationFromFiles
    {
        public abstract Guid Id { get; }
        public abstract string Name { get; }
        public virtual bool IsMinimallyRequired => false; 
        public abstract IEnumerable<FileInfo> MigrationScriptFiles { get; }

        public Migration CreateMigration()
        {
            var scripts = GetMigrationScripts();
            var migration = Fylum.Migrations.Domain.Migration.Create(Id, Name, scripts);
            if (IsMinimallyRequired)
                migration.MakeMinimallyRequired();
            return migration;
        }

        private IEnumerable<MigrationScript> GetMigrationScripts()
        {
            return MigrationScriptFiles.Select(f => new MigrationScript(File.ReadAllText(f.FullName)));
        }
    }
}
