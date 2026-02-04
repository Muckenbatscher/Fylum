using FastEndpoints;
using Fylum.Api.Shared.ErrorResult;
using Fylum.Migrations.SharedModels;
using Fylum.Migrations.SharedModels.GetMigrations;

namespace Fylum.Migrations.Api.Features.GetMigrations;

public class GetMigrationsEndpoint : EndpointWithoutRequest<GetMigrationsResponse>
{
    private readonly IGetMigrationsCommandHandler _handler;

    public GetMigrationsEndpoint(IGetMigrationsCommandHandler handler)
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
        var command = new GetMigrationsCommand();
        var commandResult = _handler.Handle(command);

        var errorHanding = await Send.EnsureErrorResultHandled(commandResult);
        if (errorHanding.ErrorResultHandlingRequired)
            return;

        var migrations = commandResult.Value;
        var response = new GetMigrationsResponse(migrations);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}