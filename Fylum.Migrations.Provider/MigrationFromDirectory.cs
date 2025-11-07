using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Provider
{
    public abstract class MigrationFromDirectory : MigrationFromFiles
    {
        public abstract DirectoryInfo MigrationsDirectory { get; }
        public override IEnumerable<FileInfo> MigrationScriptFiles => LoadMigrationFiles();

        private IEnumerable<FileInfo> LoadMigrationFiles()
        {
            MigrationsDirectory.Refresh();
            if (!MigrationsDirectory.Exists)
            {
                throw new DirectoryNotFoundException($"The directory '{MigrationsDirectory.FullName}' does not exist.");
            }
            return MigrationsDirectory.GetFiles("*.psql").OrderBy(f => f.Name);
        }
    }
}
