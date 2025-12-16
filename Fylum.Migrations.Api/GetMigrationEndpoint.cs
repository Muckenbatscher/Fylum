using FastEndpoints;
using Fylum.Api.Shared.ErrorResult;
using Fylum.Migrations.Api.Shared;
using Fylum.Migrations.Application.GetMigrations;

namespace Fylum.Migrations.Api;

public class GetMigrationEndpoint : EndpointWithoutRequest<MigrationResponse>
{
    private const string IdParamName = "id";

    private readonly IGetMigrationCommandHandler _handler;

    public GetMigrationEndpoint(IGetMigrationCommandHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        var route = $"{EndpointRoutes.MigrationsBaseRoute}/{{{IdParamName}}}";
        Get(route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<Guid>(IdParamName);
        var command = new GetMigrationCommand(id);
        var commandResult = _handler.Handle(command);

        var errorHanding = await Send.EnsureErrorResultHandled(commandResult);
        if (errorHanding.ErrorResultHandlingRequired)
            return;

        var migration = commandResult.Value;
        var response = MapToResponse(migration);
        await Send.ResultAsync(TypedResults.Ok(response));
    }

    private MigrationResponse MapToResponse(GetMigrationCommandResult migrationResult)
        => new(migrationResult.Id,
            migrationResult.Name,
            migrationResult.IsPerformed,
            migrationResult.PerformedTimestamp?.UtcDateTime);
}