namespace Fylum.PostgreSql.Shared.TableSpec
{
    public interface IPostgresColumnNameTranslator
    {
        string GetNormalizedPostgresColumnName(string propertyName);
    }
}