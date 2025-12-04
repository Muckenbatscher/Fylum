using Fylum.Domain.UnitOfWork;

namespace Fylum.Migrations.Domain.Perform;

public interface IPerformMigrationUnitOfWorkFactory : IUnitOfWorkFactory<PerformMigrationUnitOfWork>
{
}