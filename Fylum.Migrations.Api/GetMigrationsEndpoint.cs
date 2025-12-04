using FastEndpoints;
using Fylum.Api.Shared.ErrorResult;
using Fylum.Migrations.Api.Shared;
using Fylum.Migrations.Application.GetMigrations;

namespace Fylum.Migrations.Api;

public class GetMigrationsEndpoint : EndpointWithoutRequest<MultipleMigrationsResponse>
{
    private readonly IGetAllMigrationsCommandHandler _handler;

    public GetMigrationsEndpoint(IGetAllMigrationsCommandHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        Get(EndpointRoutes.MigrationsBaseRoute);
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var command = new GetAllMigrationsCommand();
        var commandResult = _handler.Handle(command);

        var errorHanding = await Send.EnsureErrorResultHandled(commandResult);
        if (errorHanding.ErrorResultHandlingRequired)
            return;

        var migrations = commandResult.Value;
        var migrationResponses = migrations.Select(MapToResponse).ToList();
        var response = new MultipleMigrationsResponse(migrationResponses);
        await Send.ResultAsync(TypedResults.Ok(response));
    }

    private MigrationResponse MapToResponse(GetMigrationCommandResult migrationResult)
        => new(migrationResult.Id,
            migrationResult.Name,
            migrationResult.IsPerformed);
}