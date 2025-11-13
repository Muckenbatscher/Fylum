using FastEndpoints;
using Fylum.Api.Shared.ErrorResult;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Migrations.Api.Shared;
using Fylum.Migrations.Application.GetMigrations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Fylum.Migrations.Api;

public class GetMigrationEndpoint : EndpointWithoutRequest<MigrationResponse>
{
    private const string IdParamName = "id";

    private readonly JwtAuthOptions _jwtAuthOptions;
    private readonly IGetMigrationCommandHandler _handler;

    public GetMigrationEndpoint(IOptions<JwtAuthOptions> jwtAuthOptions, 
        IGetMigrationCommandHandler handler)
    {
        _jwtAuthOptions = jwtAuthOptions.Value;
        _handler = handler;
    }

    public override void Configure()
    {
        var route = $"{EndpointRoutes.MigrationsBaseRoute}/{{{IdParamName}}}";
        Get(route);
        Claims(_jwtAuthOptions.UserIdClaim);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var userIdClaim = User.Claims.SingleOrDefault(c => c.Type == _jwtAuthOptions.UserIdClaim);
        if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out var userId))
        {
            await Send.ResultAsync(TypedResults.Unauthorized());
            return;
        }

        var id = Route<Guid>(IdParamName);
        var command = new GetMigrationCommand(userId, id);
        var commandResult = _handler.Handle(command);

        var errorHanding = await Send.EnsureErrorResultHandled(commandResult);
        if (errorHanding.ErrorResultHandlingRequired)
            return;

        var migration= commandResult.Value;
        var response = MapToResponse(migration);
        await Send.ResultAsync(TypedResults.Ok(response));
    }

    private MigrationResponse MapToResponse(GetMigrationCommandResult migrationResult)
        => new(migrationResult.Id,
            migrationResult.Name,
            migrationResult.IsPerformed,
            migrationResult.IsMinimallyRequired);
}
