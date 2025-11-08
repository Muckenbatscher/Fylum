namespace Fylum.Migrations.Application.GetMigrations;

public record GetMigrationCommandResult(Guid Id, string Name, bool IsApplied, bool IsMinimallyRequired);