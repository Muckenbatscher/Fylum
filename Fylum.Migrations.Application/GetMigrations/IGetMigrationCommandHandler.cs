using Fylum.Application;

namespace Fylum.Migrations.Application.GetMigrations;

public interface IGetMigrationCommandHandler : ICommandHandler<GetMigrationCommand, GetMigrationCommandResult>
{
}