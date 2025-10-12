using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Domain
{
    public abstract class MigrationFromDirectory
    {
        public abstract Guid Id { get; }
        public abstract string Name { get; }
        public abstract DirectoryInfo MigrationsDirectory { get; }

        public Migration CreateMigration()
        {
            var scripts = GetMigrationScripts();
            return Migration.Create(Id, Name, scripts);
        }


        private IEnumerable<MigrationScript> GetMigrationScripts()
        {
            var migrationFiles = LoadMigrationFiles();
            return migrationFiles.Select(f => new MigrationScript(File.ReadAllText(f.FullName)));
        }
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
