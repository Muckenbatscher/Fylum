using Fylum.Application;

namespace Fylum.Migrations.Application.GetMigrations;

public record GetAllMigrationsCommand(Guid UserId) : ICommand<IEnumerable<GetMigrationCommandResult>>;