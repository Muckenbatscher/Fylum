using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migrations.Application.WithAppliedState
{
    public interface IMigrationWithAppliedStateService
    {
        IEnumerable<MigrationWithAppliedState> GetMigrationsWithAppliedState();
        MigrationWithAppliedState? GetMigrationWithAppliedState(Guid id);
    }
}
