namespace Fylum.Migrations.Api.Shared;

public record MigrationResponse(Guid MigrationId, string Name, bool IsAlreadyApplied, bool IsMinimallyRequired);
