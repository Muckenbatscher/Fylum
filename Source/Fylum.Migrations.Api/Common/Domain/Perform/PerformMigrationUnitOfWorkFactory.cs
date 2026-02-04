using Fylum.Application;

namespace Fylum.Migrations.Api.Common.Domain.Perform;

public class PerformMigrationUnitOfWorkFactory : UnitOfWorkFactory<PerformMigrationUnitOfWork>, IPerformMigrationUnitOfWorkFactory
{
    public PerformMigrationUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) :
        base(serviceScopeFactory)
    {
    }
}