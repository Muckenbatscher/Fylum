using FastEndpoints;
using Fylum.Api.Shared.ErrorResult;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Migrations.Api.Shared;
using Fylum.Migrations.Application.Perform;
using Fylum.Migrations.Domain.WithPerformedState;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Fylum.Migrations.Api;

public class PerformMigrationsUpToEndpoint : EndpointWithoutRequest<PerformMigrationsResponse>
{
    private const string MigrationIdParamName = "id";

    private readonly JwtAuthOptions _jwtAuthOptions;
    private readonly IPerformMigrationsUpToCommandHandler _handler;

    public PerformMigrationsUpToEndpoint(IOptions<JwtAuthOptions> jwtAuthOptions,
        IPerformMigrationsUpToCommandHandler handler)
    {
        _jwtAuthOptions = jwtAuthOptions.Value;
        _handler = handler;
    }

    public override void Configure()
    {
        var route = $"{EndpointRoutes.MigrationsPerformUpToRoute}/{{{MigrationIdParamName}}}";
        Post(route);
        Claims(_jwtAuthOptions.UserIdClaim);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var migrationId = Route<Guid>(MigrationIdParamName);
        var command = new PerformMigrationsUpToCommand(migrationId);

        var result = _handler.Handle(command);
        await Send.EnsureErrorResultHandled(result);

        var performed = result.Value.PerformedMigrations.Select(MapToResponse);
        var response = new PerformMigrationsResponse(performed);
        await Send.ResultAsync(TypedResults.Ok(response));
    }


    private MigrationResponse MapToResponse(MigrationWithPerformedState migrationResult)
        => new(migrationResult.Migration.Id,
            migrationResult.Migration.Name,
            migrationResult.IsPerformed,
            migrationResult.Migration.IsMinimallyRequired);
}
