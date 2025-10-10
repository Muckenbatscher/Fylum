using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Domain.PerformedMigrations
{
    public interface IPerformedMigrationsRepository
    {
        IEnumerable<PerformedMigration> GetPerformedMigrations();
        void AddPerformedMigration(PerformedMigration performedMigration);
    }
}
