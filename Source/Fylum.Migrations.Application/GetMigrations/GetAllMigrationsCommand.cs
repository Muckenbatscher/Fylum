using Fylum.Application;

namespace Fylum.Migrations.Application.GetMigrations;

public record GetAllMigrationsCommand() : ICommand<IEnumerable<GetMigrationCommandResult>>;