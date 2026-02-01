namespace Fylum.Migrations.Api.Models;

public record MigrationDto(
    Guid Id,
    string Name,
    IEnumerable<MigrationScriptDto> Scripts,
    bool IsPerformed,
    DateTime? PerformedUtc);
