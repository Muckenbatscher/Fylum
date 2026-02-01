using Fylum.Migrations.Api.Models;
using Fylum.Migrations.Domain.Providing;

namespace Fylum.Migrations.Api;

public class MigrationScriptDtoMapper : IMapper<MigrationScript, MigrationScriptDto>
{
    public MigrationScriptDto Map(MigrationScript input)
    {
        return new MigrationScriptDto(
            Command: input.ScriptCommandText);
    }
}
