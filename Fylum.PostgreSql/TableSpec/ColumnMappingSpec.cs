using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.TableSpec
{
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
}
