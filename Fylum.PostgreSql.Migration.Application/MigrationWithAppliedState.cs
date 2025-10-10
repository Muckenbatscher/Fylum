using Fylum.PostgreSql.Migration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Application
{
    public record MigrationWithAppliedState(IMigration Migration, MigrationAppliedState? AppliedState)
    {
        public bool IsApplied => AppliedState != null;
    }
}
