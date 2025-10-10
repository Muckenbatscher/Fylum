using Fylum.PostgreSql.Shared.TableSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Shared.QueryBuilding
{
    internal class SelectQueryBuilder
    {
        private readonly ITableMappingSpecProvider _tableMappingSpecProvider;

        public SelectQueryBuilder(ITableMappingSpecProvider tableMappingSpecProvider)
        {
            _tableMappingSpecProvider = tableMappingSpecProvider;
        }

    }
}
