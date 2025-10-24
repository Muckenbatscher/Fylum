using Fylum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.TableSpec
{
    public abstract class EntityTableMappingSpecProvider<T, K> : IEntityTableMappingSpecProvider<T, K>
        where T : IdentifiableEntity<K>
        where K : struct
    {
        private readonly IPostgresColumnNameTranslator _columnNameTranslator;

        protected EntityTableMappingSpecProvider(IPostgresColumnNameTranslator columnNameTranslator)
        {
            _columnNameTranslator = columnNameTranslator;
        }

        protected abstract string TableName { get; }

        public TableMappingSpec GetTableSpec()
        {
            var allPropertyMappings = typeof(T).GetProperties()
                .Select(CreateColumnMappingSpec)
                .ToList();
            var idPropertyMapping = allPropertyMappings
                .First(p => p.MappedPropertyName == nameof(IdentifiableEntity<K>.Id));

            return new TableMappingSpec(TableName, allPropertyMappings, idPropertyMapping);
        }

        private ColumnMappingSpec CreateColumnMappingSpec(PropertyInfo property)
            => new ColumnMappingSpec(_columnNameTranslator.GetNormalizedPostgresColumnName(property.Name), property.Name);
    }
}
