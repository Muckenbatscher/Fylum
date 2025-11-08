using Fylum.Migrations.Domain;
using Fylum.Migrations.Domain.Perform;

namespace Fylum.Migrations.Application.WithAppliedState
{
    public class MigrationWithAppliedStateService : IMigrationWithAppliedStateService
    {
        private readonly IMigrationsProvider _migrationsProvider;
        private readonly IPerformedMigrationsRepository _performedMigrationsRepository;

        public MigrationWithAppliedStateService(IMigrationsProvider migrationsProvider,
            IPerformedMigrationsRepository performedMigrationsRepository)
        {
            _migrationsProvider = migrationsProvider;
            _performedMigrationsRepository = performedMigrationsRepository;
        }

        public IEnumerable<MigrationWithAppliedState> GetMigrationsWithAppliedState()
        {
            var allMigrations = _migrationsProvider.GetMigrations();
            var performedMigrations = _performedMigrationsRepository.GetPerformedMigrations();

            return allMigrations.Select(m => GetMigrationWithAppliedStateFromMatchingPerformed(m, performedMigrations));
        }

        public MigrationWithAppliedState? GetMigrationWithAppliedState(Guid id)
        {
            var migration = _migrationsProvider.GetMigrationById(id);
            if (migration == null)
                return null;

            var performedMigration = _performedMigrationsRepository.GetPerformedMigrationById(id);
            return GetMigrationWithAppliedStateFromPerformed(migration, performedMigration);
        }

        private static MigrationWithAppliedState GetMigrationWithAppliedStateFromMatchingPerformed(Migration migration, 
            IEnumerable<PerformedMigration> performedMigrations)
        {
            var matchingPerformed = performedMigrations
                .FirstOrDefault(pm => pm.Migration.Id == migration.Id);
            return GetMigrationWithAppliedStateFromPerformed(migration, matchingPerformed);
        }
        private static MigrationWithAppliedState GetMigrationWithAppliedStateFromPerformed(Migration migration,
            PerformedMigration? performedMigrations)
        {
            var appliedState = performedMigrations != null
                ? new MigrationAppliedState(performedMigrations.Timestamp)
                : null;
            return new MigrationWithAppliedState(migration, appliedState);
        }

    }
}
