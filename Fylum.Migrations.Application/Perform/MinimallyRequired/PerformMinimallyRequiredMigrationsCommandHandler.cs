using Fylum.Application;
using Fylum.Migrations.Application.Perform.All;
using Fylum.Migrations.Domain;
using Fylum.Migrations.Domain.Perform;

namespace Fylum.Migrations.Application.Perform.MinimallyRequired;

public class PerformMinimallyRequiredMigrationsCommandHandler : IPerformMinimallyRequiredMigrationsCommandHandler
{
    private readonly IPerformMigrationUnitOfWorkFactory _unitOfWorkFactory;
    private readonly IMigrationService _migrationService;

    public PerformMinimallyRequiredMigrationsCommandHandler(IPerformMigrationUnitOfWorkFactory unitOfWorkFactory,
        IMigrationService migrationService)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
        _migrationService = migrationService;
    }


    public Result<PerformMinimallyRequiredMigrationsResult> Handle(PerformMinimallyRequiredMigrationsCommand command)
    {
        var migrationsToPerform = _migrationService.GetMinimallyRequiredUnperformedMigrations().ToList();

        var performedMigrations = new List<Migration>();
        using var unitOfWork = _unitOfWorkFactory.Create();
        foreach (var migration in migrationsToPerform)
        {
            var performed = unitOfWork.MigrationPerformingService.Perform(migration.ProvidedMigration);
            performedMigrations.Add(performed);
        }
        unitOfWork.Commit();

        var result = new PerformMinimallyRequiredMigrationsResult(performedMigrations);
        return Result.Success(result);
    }
}
