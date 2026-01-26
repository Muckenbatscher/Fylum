using Fylum.Postgres.Shared.TableSpec;

namespace Fylum.Postgres.Shared.QueryBuilding;

internal class SelectQueryBuilder
{
    private readonly ITableMappingSpecProvider _tableMappingSpecProvider;

    public SelectQueryBuilder(ITableMappingSpecProvider tableMappingSpecProvider)
    {
        _tableMappingSpecProvider = tableMappingSpecProvider;
    }

}