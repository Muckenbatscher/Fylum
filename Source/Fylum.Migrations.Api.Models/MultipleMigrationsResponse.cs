namespace Fylum.Migrations.Api.Shared;

public record MultipleMigrationsResponse(IEnumerable<MigrationResponse> Migrations);