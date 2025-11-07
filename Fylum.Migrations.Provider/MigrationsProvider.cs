using Fylum.Migration.Domain;
using Fylum.Migration.Provider.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Provider
{
    public class MigrationsProvider : IMigrationsProvider
    {
        public Domain.Migration GetInitialMigration()
        {
            return new MigrationsMigration().CreateMigration();
        }

        public IEnumerable<Domain.Migration> GetMigrations()
        {
            yield return new MigrationsMigration().CreateMigration();
            yield return new UsersMigration().CreateMigration();
        }
    }
}
