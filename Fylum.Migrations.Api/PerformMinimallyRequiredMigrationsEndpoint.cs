using FastEndpoints;
using Fylum.Api.Shared.ErrorResult;
using Fylum.Migrations.Api.PerformingAuthentication;
using Fylum.Migrations.Api.Shared;
using Fylum.Migrations.Application.Perform.MinimallyRequired;
using Fylum.Migrations.Domain;

namespace Fylum.Migrations.Api;

public class PerformMinimallyRequiredMigrationsEndpoint : Endpoint<PerformingKeyRequest, PerformMigrationsResponse>
{
    private readonly IPerformingKeyRequestValidator _requestValidator;
    private readonly IPerformMinimallyRequiredMigrationsCommandHandler _handler;

    public PerformMinimallyRequiredMigrationsEndpoint(
        IPerformingKeyRequestValidator requestValidator,
        IPerformMinimallyRequiredMigrationsCommandHandler handler)
    {
        _requestValidator = requestValidator;
        _handler = handler;
    }

    public override void Configure()
    {
        Post(EndpointRoutes.MigrationsPerformMinimallyRequiredRoute);
        AllowAnonymous();
    }

    public override async Task HandleAsync(PerformingKeyRequest request, CancellationToken ct)
    {
        if (!_requestValidator.IsAuthenticated(request))
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
