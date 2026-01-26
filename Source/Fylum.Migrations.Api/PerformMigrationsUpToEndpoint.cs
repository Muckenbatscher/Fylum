using FastEndpoints;
using Fylum.Api.Shared.ErrorResult;
using Fylum.Migrations.Api.PerformingAuthentication;
using Fylum.Migrations.Api.Shared;
using Fylum.Migrations.Application.Perform.UpTo;
using Fylum.Migrations.Domain;

namespace Fylum.Migrations.Api;

public class PerformMigrationsUpToEndpoint : EndpointWithoutRequest<PerformMigrationsResponse>
{
    private const string MigrationIdParamName = "id";

    private readonly IPerformMigrationsUpToCommandHandler _handler;

    public PerformMigrationsUpToEndpoint(IPerformMigrationsUpToCommandHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        var route = $"{EndpointRoutes.MigrationsPerformUpToRoute}/{{{MigrationIdParamName}}}";
        Post(route);
        AuthSchemes(AuthSchemeConstants.MigrationPerformingKeyScheme);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var migrationId = Route<Guid>(MigrationIdParamName);
        var command = new PerformMigrationsUpToCommand(migrationId);

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