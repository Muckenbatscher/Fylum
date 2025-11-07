using Fylum.Migration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Application.MinimallyRequired
{
    public interface IMinimallyRequiredMigrationService
    {
        public void EnusreMinimallyRequiredMigrationsApplied();
        public IEnumerable<Domain.Migration> GetMinimallyRequiredUnappliedMigrations();
    }
}
