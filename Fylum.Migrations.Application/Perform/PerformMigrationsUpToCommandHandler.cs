using Fylum.Application;
using Fylum.Migrations.Domain.Perform;
using Fylum.Migrations.Domain.WithPerformedState;

namespace Fylum.Migrations.Application.Perform
{
    public class PerformMigrationsUpToCommandHandler : IPerformMigrationsUpToCommandHandler
    {
        private readonly IPerformMigrationUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IMigrationWithPerformedStateService _migrationService;

        public PerformMigrationsUpToCommandHandler(IPerformMigrationUnitOfWorkFactory unitOfWorkFactory, 
            IMigrationWithPerformedStateService migrationService)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _migrationService = migrationService;
        }

        public Result<PerformMigrationsUpToResult> Handle(PerformMigrationsUpToCommand command)
        {
            var allMigrations = _migrationService.GetMigrationsWithPerformedState().ToList();
            var upToMigration = allMigrations.FirstOrDefault(m => m.Migration.Id == command.UpToMigrationId);
            if (upToMigration == null)
                return Result.Failure(Error.NotFound);

            var upToMigrationIndex = allMigrations.IndexOf(upToMigration);
            if (upToMigration.IsPerformed)
            {
                var followingMigrations = allMigrations.Skip(upToMigrationIndex + 1);
                var anyFollowingAlreadyPerformed = followingMigrations.Any(m => m.IsPerformed);
                if (anyFollowingAlreadyPerformed)
                    return Result.Failure(Error.Validation);
                else
                    return Result.Success(new PerformMigrationsUpToResult([]));
            }

            var migrationsToPerform = allMigrations
                .Take(upToMigrationIndex + 1)
                .Where(m => !m.IsPerformed)
                .ToList();

            var performedMigrations = new List<MigrationWithPerformedState>();
            using var unitOfWork = _unitOfWorkFactory.Create();
            foreach (var migration in migrationsToPerform)
            {
                var performed = unitOfWork.MigrationPerformingService.Perform(migration.Migration);
                performedMigrations.Add(performed);
            }

            unitOfWork.Commit();

            var result = new PerformMigrationsUpToResult(performedMigrations);
            return Result.Success(result);
        }
    }
}
