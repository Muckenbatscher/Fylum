using Fylum.PostgreSql.Migration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Provider.Migrations
{
    internal class MigrationsMigration : MigrationFromDirectory, IMigration
    {
        public override Guid Id => Guid.Parse("d8d4a2b4-edc7-4b40-a618-f196bf3eb633");
        public override string Name => "0_Migrations";
        public override DirectoryInfo MigrationsDirectory => new DirectoryInfo("MigrationFiles/0_Migrations/");
    }
}
