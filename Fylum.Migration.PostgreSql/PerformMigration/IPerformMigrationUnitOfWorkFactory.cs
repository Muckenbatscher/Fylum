using Fylum.PostgreSql.Migration.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.PostgreSql.PerformMigration
{
    public interface IPerformMigrationUnitOfWorkFactory : IUnitOfWorkFactory<PerformMigrationUnitOfWork>
    {
    }
}
