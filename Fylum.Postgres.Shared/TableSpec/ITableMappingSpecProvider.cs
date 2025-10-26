using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Postgres.Shared.TableSpec
{
    public interface ITableMappingSpecProvider
    {
        TableMappingSpec GetTableSpec();
    }
}
