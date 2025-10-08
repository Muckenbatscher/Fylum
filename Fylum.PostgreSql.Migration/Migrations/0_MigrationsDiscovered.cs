using Fylum.PostgreSql.Migration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Migrations
{
    internal class MigrationsDiscovered : DiscoveredMigration, IDiscoveredMigration
    {
        public MigrationsDiscovered() : base(new MigrationsMigration())
        {
        }

        public override int ExecutionOrderPosition => 0;
    }
}
