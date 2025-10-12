using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Winforms.MainWindow
{
    public interface IMigrationMainWindow
    {
        IEnumerable<MigrationRow> AllMigrations { get; set; }
        MigrationRow? SelectedMigration { get; }
        bool ApplyUntilSelectedEnabled { get; set; }

        EventHandler? ViewLoaded { get; set; }
        EventHandler? ApplyAllClicked { get; set; }
        EventHandler? ApplyUntilSelectedClicked { get; set; }

        void UnselectAllMigrations();
    }
}
