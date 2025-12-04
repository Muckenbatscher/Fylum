namespace Fylum.Postgres.Shared.TableSpec;

public interface ITableMappingSpecProvider
{
    TableMappingSpec GetTableSpec();
}