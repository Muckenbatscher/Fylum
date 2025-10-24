using Fylum.PostgreSql.Migration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Application
{
    public record MigrationWithAppliedState(Domain.Migration Migration, MigrationAppliedState? AppliedState)
    {
        public bool IsApplied => AppliedState != null;
    }
}
