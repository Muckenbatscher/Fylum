using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Domain
{
    internal abstract class MigrationFromDirectory : IMigration
    {
        public abstract int ExecutionOrderPosition { get; }
        public abstract Guid Id { get; }
        public abstract string Name { get; }
        public abstract DirectoryInfo MigrationsDirectory { get; }
        public IEnumerable<FileInfo> MigrationFiles
        {
            get
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
}
