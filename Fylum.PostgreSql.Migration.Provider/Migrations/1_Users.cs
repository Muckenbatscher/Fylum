using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Provider.Migrations
{
    internal class UsersMigration : MigrationFromFilesInDirectory
    {
        public override Guid Id => Guid.Parse("3ead4e8f-16dd-4219-953a-600d0c8f035d");
        public override string Name => "1_Users";

        public override DirectoryInfo MigrationsDirectory => new("MigrationFiles/1_Users/");
        public override IEnumerable<string> MigrationFileNames
        {
            get
            {
                yield return "users.psql";
                yield return "user_groups.psql";
                yield return "user_group_members.psql";
                yield return "user_password_logins.psql";
            }
        }
    }
}
