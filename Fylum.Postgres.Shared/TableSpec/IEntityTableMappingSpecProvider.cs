using Fylum.Domain;

namespace Fylum.Postgres.Shared.TableSpec;

public interface IEntityTableMappingSpecProvider<T, K> : ITableMappingSpecProvider
    where T : IdentifiableEntity<K>
    where K : struct
{
}