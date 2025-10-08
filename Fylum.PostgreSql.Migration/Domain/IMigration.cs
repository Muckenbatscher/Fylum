using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Domain
{
    public interface IMigration
    {
        Guid Id { get; }
        string Name { get; }
        IEnumerable<FileInfo> MigrationFiles { get; }
    }
}
