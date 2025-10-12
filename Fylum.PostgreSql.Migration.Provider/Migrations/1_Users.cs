using Fylum.PostgreSql.Migration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Provider.Migrations
{
    internal class UsersMigration : MigrationFromDirectory
    {
        public override Guid Id => Guid.Parse("3ead4e8f-16dd-4219-953a-600d0c8f035d");
        public override string Name => "1_Users";
        public override DirectoryInfo MigrationsDirectory => new DirectoryInfo("MigrationFiles/1_Users/");
    }
}
