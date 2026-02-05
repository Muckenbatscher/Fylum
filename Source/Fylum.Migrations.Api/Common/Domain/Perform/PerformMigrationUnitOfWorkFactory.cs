using Fylum.Core.Domain;

namespace Fylum.Migrations.Api.Common.Domain.Perform;

public class PerformMigrationUnitOfWorkFactory : UnitOfWorkFactory<PerformMigrationUnitOfWork>, IPerformMigrationUnitOfWorkFactory
{
    public PerformMigrationUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) :
        base(serviceScopeFactory)
    {
    }
}