using Fylum.Migrations.Domain.Providing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migrations.Winforms.MainWindow
{
    public class MigrationRow
    {
        public MigrationRow(ProvidedMigration migration, bool isPerformed, DateTimeOffset? performedTimestamp)
        {
            Migration = migration;
            IsPerformed = isPerformed;
            PerformedTimestamp = performedTimestamp;
        }

        public ProvidedMigration Migration { get; set; }
        public string Name
            => Migration.Name;
        public int ScriptCount 
            => Migration.MigrationScripts.Count();

        public bool IsPerformed { get; }
        public DateTimeOffset? PerformedTimestamp { get; }

        public DateTime? LocalPerformedTimestamp 
            => PerformedTimestamp?.ToLocalTime().DateTime;
    }
}
