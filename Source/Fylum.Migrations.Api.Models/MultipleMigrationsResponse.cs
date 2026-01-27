namespace Fylum.Migrations.Api.Models;

public record MultipleMigrationsResponse(IEnumerable<MigrationResponse> Migrations);