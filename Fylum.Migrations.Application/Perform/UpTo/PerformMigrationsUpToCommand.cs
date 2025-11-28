using Fylum.Application;

namespace Fylum.Migrations.Application.Perform.UpTo;

public record PerformMigrationsUpToCommand(Guid UpToMigrationId) : ICommand<PerformMigrationsUpToResult>;
