using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migrations.Postgres.Perform
{
    internal class PerformedMigrationQueryModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public Guid MigrationId { get; set; }
        public string MigratioName { get; set; } = string.Empty;
    }
}
