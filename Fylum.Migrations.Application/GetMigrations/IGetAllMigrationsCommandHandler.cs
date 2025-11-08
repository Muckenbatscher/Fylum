using Fylum.Application;

namespace Fylum.Migrations.Application.GetMigrations;

public interface IGetAllMigrationsCommandHandler : ICommandHandler<GetAllMigrationsCommand, IEnumerable<GetMigrationCommandResult>>
{
}