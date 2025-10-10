using Fylum.PostgreSql.Migration.Domain;
using Fylum.PostgreSql.Migration.Provider.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Provider
{
    public class MigrationsProvider : IMigrationsProvider
    {
        public IMigration GetInitialMigration()
        {
            return new MigrationsMigration();
        }

        public IEnumerable<IMigration> GetMigrations()
        {
            yield return new MigrationsMigration();
            yield return new UsersMigration();
        }
    }
}
