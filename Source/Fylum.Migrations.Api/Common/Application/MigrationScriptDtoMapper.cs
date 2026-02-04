using Fylum.Core.Application.Mapping;
using Fylum.Migrations.Api.Common.Domain.Providing;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Common.Application;

public class MigrationScriptDtoMapper : IMapper<MigrationScript, MigrationScriptDto>
{
    public MigrationScriptDto Map(MigrationScript input)
    {
        return new MigrationScriptDto(
            Command: input.ScriptCommandText);
    }
}
