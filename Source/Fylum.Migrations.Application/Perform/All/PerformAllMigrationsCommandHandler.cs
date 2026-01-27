using Fylum.Application;
using Fylum.Migrations.Domain;
using Fylum.Migrations.Domain.Perform;

namespace Fylum.Migrations.Application.Perform.All;

public class PerformAllMigrationsCommandHandler : IPerformAllMigrationsCommandHandler
{
    private readonly IPerformMigrationUnitOfWorkFactory _unitOfWorkFactory;
    private readonly IMigrationService _migrationService;

    public PerformAllMigrationsCommandHandler(IPerformMigrationUnitOfWorkFactory unitOfWorkFactory,
        IMigrationService migrationService)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
        _migrationService = migrationService;
    }

    public Result<PerformAllMigrationsResult> Handle(PerformAllMigrationsCommand command)
    {
        var migrationsToPerform = _migrationService.GetUnperformedMigrations().ToList();

        var performedMigrations = new List<Migration>();
        using var unitOfWork = _unitOfWorkFactory.Create();
        foreach (var migration in migrationsToPerform)
        {
            var performed = unitOfWork.MigrationPerformingService.Perform(migration.ProvidedMigration);
            performedMigrations.Add(performed);
        }
        unitOfWork.Commit();

        var result = new PerformAllMigrationsResult(performedMigrations);
        return Result.Success(result);
    }
}