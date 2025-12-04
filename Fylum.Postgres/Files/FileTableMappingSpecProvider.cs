using Fylum.Postgres.Shared.TableSpec;
using File = Fylum.Domain.Files.File;

namespace Fylum.Postgres.Files;

public class FileTableMappingSpecProvider : EntityTableMappingSpecProvider<File, Guid>
{
    public FileTableMappingSpecProvider(IPostgresColumnNameTranslator columnNameTranslator) : base(columnNameTranslator)
    {
    }

    protected override string TableName => "Files";
}