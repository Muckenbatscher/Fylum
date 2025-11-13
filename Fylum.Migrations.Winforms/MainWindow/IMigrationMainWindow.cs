using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migrations.Winforms.MainWindow
{
    public interface IMigrationMainWindow
    {
        IEnumerable<MigrationRow> AllMigrations { get; set; }
        MigrationRow? SelectedMigration { get; }
        bool PerformUntilSelectedEnabled { get; set; }

        EventHandler? ViewLoaded { get; set; }
        EventHandler? PerformAllClicked { get; set; }
        EventHandler? PerformUntilSelectedClicked { get; set; }
        EventHandler? SelectedMigrationChanged { get; set; }

        void UnselectAllMigrations();
        void DisplaySelectedMigrationDetails(MigrationRow migrationRow);
        void ClearSelectedMigrationDetails();
    }
}
