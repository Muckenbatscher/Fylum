namespace Fylum.Migrations.Api.Models;

public record MultipleMigrationsResponse(IEnumerable<MigrationDto> Migrations);