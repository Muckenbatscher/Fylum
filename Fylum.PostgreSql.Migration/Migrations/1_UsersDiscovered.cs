using Fylum.PostgreSql.Migration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Migrations
{
    internal class UsersDiscovered : DiscoveredMigration, IDiscoveredMigration
    {
        public UsersDiscovered() : base(new UsersMigration())
        {
        }

        public override int ExecutionOrderPosition => 1;
    }
}
