using Fylum.PostgreSql.Migration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Application.PerformMigration
{
    public interface IMigrationPerformingService
    {
        void Perform(Domain.Migration migration);
    }
}
