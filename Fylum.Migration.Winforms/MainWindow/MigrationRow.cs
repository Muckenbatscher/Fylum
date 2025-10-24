using Fylum.PostgreSql.Migration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Winforms.MainWindow
{
    public class MigrationRow
    {
        public MigrationRow(Domain.Migration migration, bool isApplied, DateTimeOffset? appliedTimestamp)
        {
            Migration = migration;
            IsApplied = isApplied;
            AppliedTimestamp = appliedTimestamp;
        }

        public Domain.Migration Migration { get; set; }
        public string Name
            => Migration.Name;
        public int ScriptCount 
            => Migration.MigrationScripts.Count();

        public bool IsApplied { get; }
        public DateTimeOffset? AppliedTimestamp { get; }

        public DateTime? LocalAppliedTimestamp 
            => AppliedTimestamp?.ToLocalTime().DateTime;
    }
}
