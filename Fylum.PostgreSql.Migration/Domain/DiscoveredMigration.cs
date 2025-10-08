using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Domain
{
    public abstract class DiscoveredMigration : IDiscoveredMigration
    {
        private readonly IMigration _migration;

        public DiscoveredMigration(IMigration migration)
        {
            _migration = migration;
        }

        public abstract int ExecutionOrderPosition { get; }
        public IMigration Migration => _migration;
    }
}
