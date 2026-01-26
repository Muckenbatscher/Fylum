using Fylum.Application;

namespace Fylum.Migrations.Application.GetMigrations;

public record GetMigrationCommand(Guid MigrationId) : ICommand<GetMigrationCommandResult>;