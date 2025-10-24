using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.TableSpec
{
    public interface ITableMappingSpecProvider
    {
        TableMappingSpec GetTableSpec();
    }
}
