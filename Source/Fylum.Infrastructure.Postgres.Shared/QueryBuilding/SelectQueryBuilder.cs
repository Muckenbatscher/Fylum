using Fylum.Infrastructure.Postgres.Shared.TableSpec;

namespace Fylum.Infrastructure.Postgres.Shared.QueryBuilding;

internal class SelectQueryBuilder
{
    private readonly ITableMappingSpecProvider _tableMappingSpecProvider;

    public SelectQueryBuilder(ITableMappingSpecProvider tableMappingSpecProvider)
    {
        _tableMappingSpecProvider = tableMappingSpecProvider;
    }

}