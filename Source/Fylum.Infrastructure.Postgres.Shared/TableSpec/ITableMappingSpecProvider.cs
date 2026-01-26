namespace Fylum.Infrastructure.Postgres.Shared.TableSpec;

public interface ITableMappingSpecProvider
{
    TableMappingSpec GetTableSpec();
}