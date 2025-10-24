using Fylum.Migration.Application;
using Fylum.Migration.Application.PerformMigration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Winforms.MainWindow
{
    public class MigrationMainWindowPresenter
    {
        private readonly IMigrationService _migrationService;
        private readonly IMigrationPerformingService _performingService;

        public MigrationMainWindowPresenter(IMigrationMainWindow view,
            IMigrationService migrationService,
            IMigrationPerformingService performingService)
        {
            View = view;
            _migrationService = migrationService;
            _performingService = performingService;

            View.ViewLoaded += View_LoadEvent;
            View.ApplyAllClicked += View_ApplyAllClicked;
        }


        public IMigrationMainWindow View { get; private set; }

        private void View_LoadEvent(object? sender, EventArgs e)
        {
            View.ApplyUntilSelectedEnabled = false;
            PresentAppliedMigrations();
        }

        private void PresentAppliedMigrations()
        {
            var migrations = _migrationService.GetMigrationsWithAppliedState();
            View.AllMigrations = migrations.Select(CreateMigrationRow);
            View.UnselectAllMigrations();
        }
        private MigrationRow CreateMigrationRow(MigrationWithAppliedState migrationWithAppliedState)
        {
            return new MigrationRow(
                migrationWithAppliedState.Migration,
                migrationWithAppliedState.IsApplied,
                migrationWithAppliedState.AppliedState?.TimestampApplied);
        }

        private void View_ApplyAllClicked(object? sender, EventArgs e)
        {
            foreach (var migrationRow in View.AllMigrations.Where(m => !m.IsApplied))
                _performingService.Perform(migrationRow.Migration);

            PresentAppliedMigrations();
        }
    }
}
