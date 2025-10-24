using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Domain
{
    public interface IMigrationsProvider
    {
        IEnumerable<Migration> GetMigrations();
        Migration GetInitialMigration();
    }
}
