namespace Fylum.TableSpec
{
    public interface IPostgresColumnNameTranslator
    {
        string GetNormalizedPostgresColumnName(string propertyName);
    }
}