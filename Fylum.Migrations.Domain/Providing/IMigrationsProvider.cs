using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migrations.Domain.Providing
{
    public interface IMigrationsProvider
    {
        IEnumerable<ProvidedMigration> GetMigrations();
        ProvidedMigration? GetMigrationById(Guid id);
    }
}
