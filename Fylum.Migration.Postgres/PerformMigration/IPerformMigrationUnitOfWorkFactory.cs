using Fylum.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Postgres.PerformMigration
{
    public interface IPerformMigrationUnitOfWorkFactory : IUnitOfWorkFactory<PerformMigrationUnitOfWork>
    {
    }
}
