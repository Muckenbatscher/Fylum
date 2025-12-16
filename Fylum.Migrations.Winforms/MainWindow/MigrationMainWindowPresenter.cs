using Fylum.Migrations.Api.Shared;
using Fylum.Migrations.Client.Listing;
using Fylum.Migrations.Client.Performing;

namespace Fylum.Migrations.Winforms.MainWindow;

public class MigrationMainWindowPresenter
{
    private readonly IMigrationsClient _migrationsClient;
    private readonly IPerformingClient _performingClient;

    public MigrationMainWindowPresenter(IMigrationMainWindow view,
        IMigrationsClient migrationsClient,
        IPerformingClient performingClient)
    {
        View = view;
        _migrationsClient = migrationsClient;
        _performingClient = performingClient;

        View.ViewLoaded += View_LoadEvent;
        View.PerformAllClicked += View_PerformAllClicked;
        View.SelectedMigrationChanged += View_SelectedMigrationChanged;
    }

    public IMigrationMainWindow View { get; private set; }

    private async void View_LoadEvent(object? sender, EventArgs e)
    {
        View.PerformUntilSelectedEnabled = false;
        try
        {
            await PresentPerformedMigrations(CancellationToken.None);
        }
        catch (Exception ex)
        {
            _ = ex;
        }
    }

    private async Task PresentPerformedMigrations(CancellationToken cancellationToken)
    {
        var migrations = await _migrationsClient.GetMigrationsAsync(cancellationToken);
        View.AllMigrations = migrations.Migrations.Select(CreateMigrationRow).ToList();
        View.UnselectAllMigrations();
    }
    private MigrationRow CreateMigrationRow(MigrationResponse migrationWithPerformedState)
    {
        DateTimeOffset? performed = migrationWithPerformedState.PerformedUtc.HasValue
            ? new DateTimeOffset(migrationWithPerformedState.PerformedUtc.Value)
            : null;
        return new MigrationRow(
            migrationWithPerformedState.MigrationId,
            migrationWithPerformedState.Name,
            migrationWithPerformedState.IsAlreadyPerformed,
            performed);
    }

    private async void View_PerformAllClicked(object? sender, EventArgs e)
    {
        View.PerformAllEnabled = false;
        try
        {
            foreach (var migrationRow in View.AllMigrations.Where(m => !m.IsPerformed))
                await _performingClient.PerformMigrationsUpToAsync(migrationRow.Id, CancellationToken.None);

            await PresentPerformedMigrations(CancellationToken.None);
        }
        catch (Exception)
        {
        }
        finally
        {
            View.PerformAllEnabled = true;
        }
    }

    private void View_SelectedMigrationChanged(object? sender, EventArgs e)
    {
        var selectedMigration = View.SelectedMigration;
        View.ClearSelectedMigrationDetails();

        if (selectedMigration is not null)
            View.DisplaySelectedMigrationDetails(selectedMigration);
    }
}