using Fylum.Migrations.Domain;
using Fylum.Migrations.Domain.Perform;

namespace Fylum.Migrations.Winforms.MainWindow;

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
        var migrations = _migrationService.GetMigrations();
        View.AllMigrations = migrations.Select(CreateMigrationRow);
        View.UnselectAllMigrations();
    }
    private MigrationRow CreateMigrationRow(Migration migrationWithPerformedState)
    {
        return new MigrationRow(
            migrationWithPerformedState.ProvidedMigration,
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