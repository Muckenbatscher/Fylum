using Fylum.Migrations.Domain;
using Fylum.Migrations.Domain.Perform;
using Fylum.Migrations.Domain.Providing;

namespace Fylum.Migrations.Application
{
    public class MigrationService : IMigrationService
    {
        private readonly IMigrationsProvider _migrationsProvider;
        private readonly IPerformedMigrationsRepository _performedMigrationsRepository;

        public MigrationService(IMigrationsProvider migrationsProvider,
            IPerformedMigrationsRepository performedMigrationsRepository)
        {
            _migrationsProvider = migrationsProvider;
            _performedMigrationsRepository = performedMigrationsRepository;
        }

        public IEnumerable<Migration> GetMigrations()
        {
            var allMigrations = _migrationsProvider.GetMigrations();
            var performedMigrations = _performedMigrationsRepository.GetPerformedMigrations();

            return allMigrations.Select(m => GetMigrationWithAppliedStateFromMatchingPerformed(m, performedMigrations));
        }
        public IEnumerable<Migration> GetUnperformedMigrations()
            => GetMigrations().Where(m => !m.IsPerformed);

        public Migration? GetMigration(Guid id)
        {
            var migration = _migrationsProvider.GetMigrationById(id);
            if (migration == null)
                return null;

            var performedMigration = _performedMigrationsRepository.GetPerformedMigrationById(id);
            return GetMigrationWithAppliedStateFromPerformed(migration, performedMigration);
        }

        private static Migration GetMigrationWithAppliedStateFromMatchingPerformed(ProvidedMigration migration, 
            IEnumerable<PerformedMigration> performedMigrations)
        {
            var matchingPerformed = performedMigrations
                .FirstOrDefault(pm => pm.Migration.Id == migration.Id);
            return GetMigrationWithAppliedStateFromPerformed(migration, matchingPerformed);
        }
        private static Migration GetMigrationWithAppliedStateFromPerformed(ProvidedMigration migration,
            PerformedMigration? performedMigration)
        {
            var appliedState = performedMigration != null
                ? new MigrationPeformedState(performedMigration.Timestamp)
                : null;
            return Migration.Create(migration, appliedState?.TimestampPerformed);
        }

    }
}
