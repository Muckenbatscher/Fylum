using FastEndpoints;
using Fylum.Api.Shared.ErrorResult;
using Fylum.Migrations.SharedModels;
using Fylum.Migrations.SharedModels.GetMigrationById;

namespace Fylum.Migrations.Api.Features.GetMigrationById;

public class GetMigrationByIdEndpoint : EndpointWithoutRequest<GetMigrationByIdResponse>
{
    private const string IdParamName = "id";

    private readonly IGetMigrationByIdCommandHandler _handler;

    public GetMigrationByIdEndpoint(IGetMigrationByIdCommandHandler handler)
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
        var command = new GetMigrationByIdCommand(id);
        var commandResult = _handler.Handle(command);

        var errorHanding = await Send.EnsureErrorResultHandled(commandResult);
        if (errorHanding.ErrorResultHandlingRequired)
            return;

        var migration = commandResult.Value;
        var response = new GetMigrationByIdResponse(migration);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}