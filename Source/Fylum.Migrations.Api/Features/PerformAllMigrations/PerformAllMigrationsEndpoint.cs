using FastEndpoints;
using Fylum.Core.Presentation.Api.ErrorResult;
using Fylum.Migrations.Api.Authentication;
using Fylum.Migrations.SharedModels;
using Fylum.Migrations.SharedModels.PerformAllMigrations;

namespace Fylum.Migrations.Api.Features.PerformAllMigrations;

public class PerformAllMigrationsEndpoint : EndpointWithoutRequest<PerformAllMigrationsResponse>
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

        var performedMigrations = result.Value;
        var response = new PerformAllMigrationsResponse(performedMigrations);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}