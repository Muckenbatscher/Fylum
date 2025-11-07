using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Provider
{
    public abstract class MigrationFromFilesInDirectory : MigrationFromFiles
    {
        public abstract DirectoryInfo MigrationsDirectory { get; }
        public abstract IEnumerable<string> MigrationFileNames { get; }

        public override IEnumerable<FileInfo> MigrationScriptFiles 
            => MigrationFileNames.Select(GetFileInMigrationsDirectory);

        private FileInfo GetFileInMigrationsDirectory(string fileName)
        {
            var filePath = Path.Combine(MigrationsDirectory.FullName, fileName);
            return new FileInfo(filePath);
        }
    }
}
