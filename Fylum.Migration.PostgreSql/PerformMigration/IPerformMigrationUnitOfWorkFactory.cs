using Fylum.Migration.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.PostgreSql.PerformMigration
{
    public interface IPerformMigrationUnitOfWorkFactory : IUnitOfWorkFactory<PerformMigrationUnitOfWork>
    {
    }
}
