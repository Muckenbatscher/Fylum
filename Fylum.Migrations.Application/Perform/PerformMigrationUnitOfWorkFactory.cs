using Fylum.Application;
using Fylum.Migrations.Domain.Perform;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Migrations.Application.Perform;

public class PerformMigrationUnitOfWorkFactory : UnitOfWorkFactory, IPerformMigrationUnitOfWorkFactory
{
    public PerformMigrationUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) :
        base(serviceScopeFactory)
    {
    }

    public PerformMigrationUnitOfWork Create()
    {
        CreateScope();

        var transactionFactory = GetTransactionFactory();
        var migrationPerformingService = GetScopedService<IMigrationPerformingService>();

        return new PerformMigrationUnitOfWork(
            transactionFactory,
            migrationPerformingService);
    }
}