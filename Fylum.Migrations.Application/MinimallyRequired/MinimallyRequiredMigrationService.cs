using Fylum.Migrations.Domain.Perform;
using Fylum.Migrations.Domain.WithPerformedState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migrations.Application.MinimallyRequired
{
    public class MinimallyRequiredMigrationService : IMinimallyRequiredMigrationService
    {
        private readonly IMigrationWithPerformedStateService _migrationWithPerformedStateService;
        private readonly IMigrationPerformingService _migrationPerformingService;

        public MinimallyRequiredMigrationService(IMigrationWithPerformedStateService migrationWithPeformedStateService, 
            IMigrationPerformingService migrationPerformingService)
        {
            _migrationWithPerformedStateService = migrationWithPeformedStateService;
            _migrationPerformingService = migrationPerformingService;
        }

        public IEnumerable<Domain.Migration> GetMinimallyRequiredUnperformedMigrations()
        { 
            var allMigrationsWithState = _migrationWithPerformedStateService.GetMigrationsWithPerformedState();
            var unperformedMigrations = allMigrationsWithState.Where(m => !m.IsPerformed).ToList();
            var lastMinimallyRequiredIndex = unperformedMigrations.FindLastIndex(um => um.Migration.IsMinimallyRequired);
            if (lastMinimallyRequiredIndex < 0)
                return Enumerable.Empty<Domain.Migration>();

            return unperformedMigrations.Take(lastMinimallyRequiredIndex + 1).Select(mas => mas.Migration)
                .ToList().AsReadOnly();
        }

        public void EnusreMinimallyRequiredMigrationsPerformed()
        {
            var requiredUnperformedMigrations = GetMinimallyRequiredUnperformedMigrations();
            foreach (var migration in requiredUnperformedMigrations)
                _migrationPerformingService.Perform(migration);
        }
    }
}
