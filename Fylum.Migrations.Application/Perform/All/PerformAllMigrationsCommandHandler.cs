using Fylum.Application;
using Fylum.Migrations.Application.Perform.UpTo;
using Fylum.Migrations.Domain.Perform;
using Fylum.Migrations.Domain.WithPerformedState;

namespace Fylum.Migrations.Application.Perform.All;

public class PerformAllMigrationsCommandHandler : IPerformAllMigrationsCommandHandler
{
    private readonly IPerformMigrationUnitOfWorkFactory _unitOfWorkFactory;
    private readonly IMigrationWithPerformedStateService _migrationService;

    public PerformAllMigrationsCommandHandler(IPerformMigrationUnitOfWorkFactory unitOfWorkFactory, 
        IMigrationWithPerformedStateService migrationService)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
        _migrationService = migrationService;
    }

    public Result<PerformAllMigrationsResult> Handle(PerformAllMigrationsCommand command)
    {
        var migrationsToPerform = _migrationService.GetUnperformedMigrations().ToList();

        var performedMigrations = new List<MigrationWithPerformedState>();
        using var unitOfWork = _unitOfWorkFactory.Create();
        foreach (var migration in migrationsToPerform)
        {
            var performed = unitOfWork.MigrationPerformingService.Perform(migration.Migration);
            performedMigrations.Add(performed);
        }
        unitOfWork.Commit();

        var result = new PerformAllMigrationsResult(performedMigrations);
        return Result.Success(result);
    }
}
