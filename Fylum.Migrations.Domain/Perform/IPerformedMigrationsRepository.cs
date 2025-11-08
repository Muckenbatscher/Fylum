using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migrations.Domain.Perform
{
    public interface IPerformedMigrationsRepository
    {
        IEnumerable<PerformedMigration> GetPerformedMigrations();
        PerformedMigration? GetPerformedMigrationById(Guid id);

        void AddPerformedMigration(PerformedMigration performedMigration);
    }
}
