using Fylum.Migrations.Domain;
using Fylum.Migrations.Domain.Perform;
using Fylum.Migrations.Domain.WithPerformedState;

namespace Fylum.Migrations.Application.WithPerformedState
{
    public class MigrationWithPerformedStateService : IMigrationWithPerformedStateService
    {
        private readonly IMigrationsProvider _migrationsProvider;
        private readonly IPerformedMigrationsRepository _performedMigrationsRepository;

        public MigrationWithPerformedStateService(IMigrationsProvider migrationsProvider,
            IPerformedMigrationsRepository performedMigrationsRepository)
        {
            _migrationsProvider = migrationsProvider;
            _performedMigrationsRepository = performedMigrationsRepository;
        }

        public IEnumerable<MigrationWithPerformedState> GetMigrationsWithPerformedState()
        {
            var allMigrations = _migrationsProvider.GetMigrations();
            var performedMigrations = _performedMigrationsRepository.GetPerformedMigrations();

            return allMigrations.Select(m => GetMigrationWithAppliedStateFromMatchingPerformed(m, performedMigrations));
        }

        public MigrationWithPerformedState? GetMigrationWithPerformedState(Guid id)
        {
            var migration = _migrationsProvider.GetMigrationById(id);
            if (migration == null)
                return null;

            var performedMigration = _performedMigrationsRepository.GetPerformedMigrationById(id);
            return GetMigrationWithAppliedStateFromPerformed(migration, performedMigration);
        }

        private static MigrationWithPerformedState GetMigrationWithAppliedStateFromMatchingPerformed(Migration migration, 
            IEnumerable<PerformedMigration> performedMigrations)
        {
            var matchingPerformed = performedMigrations
                .FirstOrDefault(pm => pm.Migration.Id == migration.Id);
            return GetMigrationWithAppliedStateFromPerformed(migration, matchingPerformed);
        }
        private static MigrationWithPerformedState GetMigrationWithAppliedStateFromPerformed(Migration migration,
            PerformedMigration? performedMigration)
        {
            var appliedState = performedMigration != null
                ? new MigrationPeformedState(performedMigration.Timestamp)
                : null;
            return MigrationWithPerformedState.Create(migration, appliedState?.TimestampPerformed);
        }
    }
}
