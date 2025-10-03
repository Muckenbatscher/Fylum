using Fylum.TableSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Files
{
    public class FileTableMappingSpecProvider : EntityTableMappingSpecProvider<File, Guid>
    {
        public FileTableMappingSpecProvider(IPostgresColumnNameTranslator columnNameTranslator) : base(columnNameTranslator)
        {
        }

        protected override string TableName => "Files";
    }
}
