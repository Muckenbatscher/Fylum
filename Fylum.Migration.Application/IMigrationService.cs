using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Application
{
    public interface IMigrationService
    {
        IEnumerable<MigrationWithAppliedState> GetMigrationsWithAppliedState();
    }
}
