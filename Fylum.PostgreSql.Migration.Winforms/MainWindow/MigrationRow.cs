using Fylum.PostgreSql.Migration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Winforms.MainWindow
{
    internal class MigrationRow
    {
        public MigrationRow(IMigration migration, bool isApplied, DateTimeOffset? appliedTimestamp)
        {
            Migration = migration;
            IsApplied = isApplied;
            AppliedTimestamp = appliedTimestamp;
        }

        public IMigration Migration { get; set; }
        public string Name
            => Migration.Name;
        public int ScriptCount 
            => Migration.MigrationFiles.Count();

        public bool IsApplied { get; }
        public DateTimeOffset? AppliedTimestamp { get; }
    }
}
