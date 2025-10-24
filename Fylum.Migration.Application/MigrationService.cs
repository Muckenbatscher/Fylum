using Fylum.Migration.Domain;
using Fylum.Migration.Domain.PerformedMigrations;
using Fylum.PostgreSql.Migration.Application.PerformMigration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Application
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

        public IEnumerable<MigrationWithAppliedState> GetMigrationsWithAppliedState()
        {
            var allMigrations = _migrationsProvider.GetMigrations();
            var performedMigrations = _performedMigrationsRepository.GetPerformedMigrations();

            return allMigrations.Select(m => GetMigrationWithAppliedStateFromPerformed(m, performedMigrations));
        }

        private static MigrationWithAppliedState GetMigrationWithAppliedStateFromPerformed(Domain.Migration migration, 
            IEnumerable<PerformedMigration> performedMigrations)
        {
            var matchingPerformed = performedMigrations
                .FirstOrDefault(pm => pm.Migration.Id == migration.Id);
            var appliedState = matchingPerformed != null
                ? new MigrationAppliedState(matchingPerformed.Timestamp)
                : null;
            return new MigrationWithAppliedState(migration, appliedState);
        }
    }
}
