namespace Fylum.Migrations.Api.Models;

public record MigrationResponse(Guid MigrationId, string Name,
    bool IsAlreadyPerformed, DateTime? PerformedUtc);