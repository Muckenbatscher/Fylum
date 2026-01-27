using Fylum.Application;
using Fylum.Migrations.Domain.Perform;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Migrations.Application.Perform;

public class PerformMigrationUnitOfWorkFactory : UnitOfWorkFactory<PerformMigrationUnitOfWork>, IPerformMigrationUnitOfWorkFactory
{
    public PerformMigrationUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) :
        base(serviceScopeFactory)
    {
    }
}