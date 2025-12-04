namespace Fylum.Postgres.Shared.TableSpec;

public class ColumnMappingSpec
{
    public string ColumnName { get; set; }
    public string MappedPropertyName { get; set; }

    public ColumnMappingSpec(string columnName, string mappedPropertyName)
    {
        ColumnName = columnName;
        MappedPropertyName = mappedPropertyName;
    }
}