namespace Fylum.Infrastructure.Postgres.Shared.TableSpec;

public interface IPostgresColumnNameTranslator
{
    string GetNormalizedPostgresColumnName(string propertyName);
}