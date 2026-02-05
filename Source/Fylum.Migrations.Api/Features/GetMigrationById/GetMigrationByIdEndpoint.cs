using FastEndpoints;
using Fylum.Core.Presentation.Api.ErrorResult;
using Fylum.Migrations.SharedModels;
using Fylum.Migrations.SharedModels.GetMigrationById;

namespace Fylum.Migrations.Api.Features.GetMigrationById;

public class GetMigrationByIdEndpoint : EndpointWithoutRequest<GetMigrationByIdResponse>
{
    private const string IdParamName = "id";

    private readonly IGetMigrationByIdQueryHandler _handler;

    public GetMigrationByIdEndpoint(IGetMigrationByIdQueryHandler handler)
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
        var command = new GetMigrationByIdQuery(id);
        var commandResult = _handler.Handle(command);

        var errorHanding = await Send.EnsureErrorResultHandled(commandResult);
        if (errorHanding.ErrorResultHandlingRequired)
            return;

        var migration = commandResult.Value;
        var response = new GetMigrationByIdResponse(migration);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}