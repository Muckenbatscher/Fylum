using Fylum.Domain.UnitOfWork;

namespace Fylum.Migrations.Api.Common.Domain.Perform;

public class PerformMigrationUnitOfWork : UnitOfWork, IUnitOfWork
{
    public IMigrationPerformingService MigrationPerformingService { get; init; }

    public PerformMigrationUnitOfWork(IUnitOfWorkTransactionFactory transactionFactory,
        IMigrationPerformingService migrationPerformingService)
        : base(transactionFactory)
    {
        MigrationPerformingService = migrationPerformingService;
    }
}