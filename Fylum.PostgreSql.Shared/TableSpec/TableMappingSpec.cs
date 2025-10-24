using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.TableSpec
{
    public class TableMappingSpec
    {
        public string TableName { get; set; }
        public IEnumerable<ColumnMappingSpec> ColumnMappings { get; set; }
        public ColumnMappingSpec IdentityColumnSpec { get; set; }

        public TableMappingSpec(string tableName, IEnumerable<ColumnMappingSpec> columnMappings, ColumnMappingSpec identityColumnSpec)
        {
            TableName = tableName;
            ColumnMappings = columnMappings;
            IdentityColumnSpec = identityColumnSpec;
        }
        public TableMappingSpec(string tableName, IEnumerable<ColumnMappingSpec> columnMappings)
        {
            TableName = tableName;
            ColumnMappings = columnMappings;
            IdentityColumnSpec = columnMappings.First();
        }
        public TableMappingSpec(string tableName, IEnumerable<ColumnMappingSpec> columnMappings, string identityColumnName)
        {
            TableName = tableName;
            ColumnMappings = columnMappings;
            IdentityColumnSpec = columnMappings.First(x => x.ColumnName == identityColumnName);
        }
    }
}
