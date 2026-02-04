using Fylum.Domain.UnitOfWork;

namespace Fylum.Migrations.Api.Common.Domain.Perform;

public interface IPerformMigrationUnitOfWorkFactory : IUnitOfWorkFactory<PerformMigrationUnitOfWork>
{
}