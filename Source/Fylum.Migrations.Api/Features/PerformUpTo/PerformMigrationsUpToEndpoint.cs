using FastEndpoints;
using Fylum.Core.Presentation.Api.ErrorResult;
using Fylum.Migrations.Api.Authentication;
using Fylum.Migrations.SharedModels;
using Fylum.Migrations.SharedModels.PerformMigrationsUpTo;

namespace Fylum.Migrations.Api.Features.PerformUpTo;

public class PerformMigrationsUpToEndpoint : EndpointWithoutRequest<PerformMigrationsUpToResponse>
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

        var performedMigrations = result.Value;
        var response = new PerformMigrationsUpToResponse(performedMigrations);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}