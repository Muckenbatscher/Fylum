using FastEndpoints;
using Fylum.Api.Shared.ErrorResult;
using Fylum.Migrations.Api.PerformingAuthentication;
using Fylum.Migrations.Api.Shared;
using Fylum.Migrations.Application.Perform.MinimallyRequired;
using Fylum.Migrations.Domain;
using Microsoft.AspNetCore.Http;

namespace Fylum.Migrations.Api;

public class PerformMinimallyRequiredMigrationsEndpoint : Endpoint<UserClaimOrMigrationPerformingKeyRequest, PerformMigrationsResponse>
{
    private readonly IPerformMinimallyRequiredMigrationsCommandHandler _handler;

    public PerformMinimallyRequiredMigrationsEndpoint(IPerformMinimallyRequiredMigrationsCommandHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        Post(EndpointRoutes.MigrationsPerformMinimallyRequiredRoute);
        AllowAnonymous();
    }

    public override async Task HandleAsync(UserClaimOrMigrationPerformingKeyRequest request, CancellationToken ct)
    {
        if (!request.IsAuthenticated)
        {
            await Send.ResultAsync(TypedResults.Unauthorized());
            return;
        }

        var command = new PerformMinimallyRequiredMigrationsCommand();

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
            migrationResult.ProvidedMigration.IsMinimallyRequired);

}
