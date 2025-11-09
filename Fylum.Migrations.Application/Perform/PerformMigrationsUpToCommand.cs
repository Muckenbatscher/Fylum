using Fylum.Application;

namespace Fylum.Migrations.Application.Perform;

public record PerformMigrationsUpToCommand(Guid UpToMigrationId) : ICommand<PerformMigrationsUpToResult>;
