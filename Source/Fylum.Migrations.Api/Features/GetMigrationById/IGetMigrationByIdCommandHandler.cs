using Fylum.Application;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Features.GetMigrationById;

public interface IGetMigrationByIdCommandHandler : ICommandHandler<GetMigrationByIdCommand, MigrationDto>
{
}
