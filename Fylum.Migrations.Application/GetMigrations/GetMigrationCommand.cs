using Fylum.Application;

namespace Fylum.Migrations.Application.GetMigrations;

public record GetMigrationCommand(Guid UserId, Guid MigrationId) : ICommand<GetMigrationCommandResult>;