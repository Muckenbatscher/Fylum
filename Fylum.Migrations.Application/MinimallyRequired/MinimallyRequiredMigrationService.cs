using Fylum.Migrations.Application.Perform;
using Fylum.Migrations.Application.WithAppliedState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migrations.Application.MinimallyRequired
{
    public class MinimallyRequiredMigrationService : IMinimallyRequiredMigrationService
    {
        private readonly IMigrationWithAppliedStateService _migrationWithAppliedStateService;
        private readonly IMigrationPerformingService _migrationPerformingService;

        public MinimallyRequiredMigrationService(IMigrationWithAppliedStateService migrationWithAppliedStateService, 
            IMigrationPerformingService migrationPerformingService)
        {
            _migrationWithAppliedStateService = migrationWithAppliedStateService;
            _migrationPerformingService = migrationPerformingService;
        }

        public IEnumerable<Domain.Migration> GetMinimallyRequiredUnappliedMigrations()
        { 
            var allMigrationsWithState = _migrationWithAppliedStateService.GetMigrationsWithAppliedState();
            var unappliedMigrations = allMigrationsWithState.Where(m => !m.IsApplied).ToList();
            var lastMinimallyRequiredIndex = unappliedMigrations.FindLastIndex(um => um.Migration.IsMinimallyRequired);
            if (lastMinimallyRequiredIndex < 0)
                return Enumerable.Empty<Domain.Migration>();

            return unappliedMigrations.Take(lastMinimallyRequiredIndex + 1).Select(mas => mas.Migration)
                .ToList().AsReadOnly();
        }

        public void EnusreMinimallyRequiredMigrationsApplied()
        {
            var requiredUnappliedMigrations = GetMinimallyRequiredUnappliedMigrations();
            foreach (var migration in requiredUnappliedMigrations)
                _migrationPerformingService.Perform(migration);
        }
    }
}
