using Fylum.Migrations.Domain;
using Fylum.Migrations.Domain.Perform;
using Fylum.Migrations.Domain.WithPerformedState;

namespace Fylum.Migrations.Application.MinimallyRequired;

public class MinimallyRequiredMigrationService : IMinimallyRequiredMigrationService
{
    private readonly IPerformMigrationUnitOfWorkFactory _unitOfWorkFactory;

    private readonly IMigrationWithPerformedStateService _migrationWithPerformedStateService;

    public MinimallyRequiredMigrationService(IMigrationWithPerformedStateService migrationWithPeformedStateService,
        IPerformMigrationUnitOfWorkFactory unitOfWorkFactory)
    {
        _migrationWithPerformedStateService = migrationWithPeformedStateService;
        _unitOfWorkFactory = unitOfWorkFactory;
    }

    public IEnumerable<Migration> GetMinimallyRequiredUnperformedMigrations()
    { 
        var allMigrationsWithState = _migrationWithPerformedStateService.GetMigrationsWithPerformedState();
        var unperformedMigrations = allMigrationsWithState.Where(m => !m.IsPerformed).ToList();
        var lastMinimallyRequiredIndex = unperformedMigrations.FindLastIndex(um => um.Migration.IsMinimallyRequired);
        if (lastMinimallyRequiredIndex < 0)
            return Enumerable.Empty<Migration>();

        return unperformedMigrations.Take(lastMinimallyRequiredIndex + 1).Select(mas => mas.Migration)
            .ToList().AsReadOnly();
    }

    public void EnusreMinimallyRequiredMigrationsPerformed()
    {
        using var unitOfWork = _unitOfWorkFactory.Create();

        var requiredUnperformedMigrations = GetMinimallyRequiredUnperformedMigrations();
        foreach (var migration in requiredUnperformedMigrations)
            unitOfWork.MigrationPerformingService.Perform(migration);

        unitOfWork.Commit();
    }
}
