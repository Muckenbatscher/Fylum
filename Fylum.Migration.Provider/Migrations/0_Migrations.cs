using Fylum.Migration.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Provider.Migrations
{
    internal class MigrationsMigration : MigrationFromFilesInDirectory
    {
        public override Guid Id => Guid.Parse("d8d4a2b4-edc7-4b40-a618-f196bf3eb633");
        public override string Name => "0_Migrations";

        public override DirectoryInfo MigrationsDirectory => new("MigrationFiles/0_Migrations/");
        public override IEnumerable<string> MigrationFileNames
        {
            get
            {
                yield return "migrations.psql";
                yield return "migrations_performed.psql";
            }
        }
    }
}
