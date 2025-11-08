using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migrations.Domain.Perform
{
    public class PerformedMigration
    {
        public Guid Id { get; }
        public Migration Migration { get; }
        public DateTimeOffset Timestamp { get; }

        private PerformedMigration(Guid id, DateTimeOffset timestamp, Migration migration)
        {
            Id = id;
            Timestamp = timestamp;
            Migration = migration;
        }

        public static PerformedMigration CreateNew(Migration migration)
            => new PerformedMigration(Guid.NewGuid(), DateTimeOffset.UtcNow, migration);
        
        public static PerformedMigration Create(Guid id, DateTimeOffset timestamp, Migration migration)
            => new PerformedMigration(id, timestamp, migration);
    }
}
