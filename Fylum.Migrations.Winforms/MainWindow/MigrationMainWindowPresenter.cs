using Fylum.Migrations.Domain.Perform;
using Fylum.Migrations.Domain.WithPerformedState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migrations.Winforms.MainWindow
{
    public class MigrationMainWindowPresenter
    {
        private readonly IMigrationWithPerformedStateService _migrationService;
        private readonly IMigrationPerformingService _performingService;

        public MigrationMainWindowPresenter(IMigrationMainWindow view,
            IMigrationWithPerformedStateService migrationService,
            IMigrationPerformingService performingService)
        {
            View = view;
            _migrationService = migrationService;
            _performingService = performingService;

            View.ViewLoaded += View_LoadEvent;
            View.PerformAllClicked += View_PerformAllClicked;
            View.SelectedMigrationChanged += View_SelectedMigrationChanged;
        }


        public IMigrationMainWindow View { get; private set; }

        private void View_LoadEvent(object? sender, EventArgs e)
        {
            View.PerformUntilSelectedEnabled = false;
            PresentPerformedMigrations();
        }

        private void PresentPerformedMigrations()
        {
            var migrations = _migrationService.GetMigrationsWithPerformedState();
            View.AllMigrations = migrations.Select(CreateMigrationRow);
            View.UnselectAllMigrations();
        }
        private MigrationRow CreateMigrationRow(MigrationWithPerformedState migrationWithPerformedState)
        {
            return new MigrationRow(
                migrationWithPerformedState.Migration,
                migrationWithPerformedState.IsPerformed,
                migrationWithPerformedState.PerformedState?.TimestampPerformed);
        }

        private void View_PerformAllClicked(object? sender, EventArgs e)
        {
            foreach (var migrationRow in View.AllMigrations.Where(m => !m.IsPerformed))
                _performingService.Perform(migrationRow.Migration);

            PresentPerformedMigrations();
        }

        private void View_SelectedMigrationChanged(object? sender, EventArgs e)
        {
            var selectedMigration = View.SelectedMigration;
            View.ClearSelectedMigrationDetails();

            if (selectedMigration is not null)
                View.DisplaySelectedMigrationDetails(selectedMigration);
        }
    }
}
