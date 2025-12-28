using FastEndpoints;
using Fylum.Api.Shared.ErrorResult;
using Fylum.Migrations.Api.PerformingAuthentication;
using Fylum.Migrations.Api.Shared;
using Fylum.Migrations.Application.Perform.All;
using Fylum.Migrations.Domain;

namespace Fylum.Migrations.Api;

public class PerformAllMigrationsEndpoint : EndpointWithoutRequest<PerformMigrationsResponse>
{
    private readonly IPerformAllMigrationsCommandHandler _handler;

    public PerformAllMigrationsEndpoint(IPerformAllMigrationsCommandHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        Post(EndpointRoutes.MigrationsPerformAllRoute);
        AuthSchemes(AuthSchemeConstants.MigrationPerformingKeyScheme);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var command = new PerformAllMigrationsCommand();

        var result = _handler.Handle(command);
        var error = await Send.EnsureErrorResultHandled(result);
        if (error.ErrorResultHandlingRequired)
            return;

        var performed = result.Value.PerformedMigrations.Select(MapToResponse);
        var response = new PerformMigrationsResponse(performed);
        await Send.ResultAsync(TypedResults.Ok(response));
    }

    private MigrationResponse MapToResponse(Migration migrationResult)
        => new(migrationResult.ProvidedMigration.Id,
            migrationResult.ProvidedMigration.Name,
            migrationResult.IsPerformed,
            migrationResult.PerformedState?.TimestampPerformed.UtcDateTime);

}