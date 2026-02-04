using Fylum.Application;
using Fylum.Core.Application.Mapping;
using Fylum.Migrations.Api.Common.Domain;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Features.GetMigrationById;

public class GetMigrationByIdCommandHandler : ICommandHandler<GetMigrationByIdCommand, MigrationDto>
{
    private readonly IMigrationService _migrationService;
    private readonly IMapper<Migration, MigrationDto> _mapper;

    public GetMigrationByIdCommandHandler(IMigrationService migrationService, 
        IMapper<Migration, MigrationDto> mapper)
    {
        _migrationService = migrationService;
        _mapper = mapper;
    }

    public Result<MigrationDto> Handle(GetMigrationByIdCommand command)
    {
        var migration = _migrationService.GetMigration(command.MigrationId);
        if (migration == null)
            return Result.Failure(Error.NotFound);

        return _mapper.Map(migration);
    }
}