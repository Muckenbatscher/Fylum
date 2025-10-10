using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Shared.TableSpec
{
    public interface IEntityTableMappingSpecProvider<T, K> : ITableMappingSpecProvider
        where T : IdentifiableEntity<K>
        where K : struct
    {
    }
}
