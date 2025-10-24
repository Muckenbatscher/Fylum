namespace Fylum.PostgreSql.TableSpec
{
    public interface IPostgresColumnNameTranslator
    {
        string GetNormalizedPostgresColumnName(string propertyName);
    }
}