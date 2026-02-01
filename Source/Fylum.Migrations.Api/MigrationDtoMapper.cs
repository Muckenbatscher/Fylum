using Fylum.Migrations.Api.Models;
using Fylum.Migrations.Domain;
using Fylum.Migrations.Domain.Providing;

namespace Fylum.Migrations.Api;

public class MigrationDtoMapper : IMapper<Migration, MigrationDto>
{
    private readonly IMapper<MigrationScript, MigrationScriptDto> _migrationScriptMapper;

    public MigrationDtoMapper(IMapper<MigrationScript, MigrationScriptDto> migrationScriptMapper)
    {
        _migrationScriptMapper = migrationScriptMapper;
    }

    public MigrationDto Map(Migration input)
    {
        var scripts = input.ProvidedMigration.MigrationScripts
            .Select(_migrationScriptMapper.Map);
        return new MigrationDto(
            Id: input.ProvidedMigration.Id,
            Name: input.ProvidedMigration.Name,
            Scripts: scripts,
            IsPerformed: input.IsPerformed,
            PerformedUtc: input.PerformedState?.TimestampPerformed.UtcDateTime
            );
    }
}
