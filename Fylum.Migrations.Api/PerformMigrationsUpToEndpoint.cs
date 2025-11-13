using FastEndpoints;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Migrations.Api.Shared;
using Fylum.Migrations.Application.GetMigrations;
using Microsoft.Extensions.Options;

namespace Fylum.Migrations.Api;

public class PerformMigrationsUpToEndpoint : Endpoint<PerformMigrationsUpToRequest, PerformMigrationsUpToResponse>
{
    private readonly JwtAuthOptions _jwtAuthOptions;
    private readonly IGetAllMigrationsCommandHandler _handler;

    public PerformMigrationsUpToEndpoint(IOptions<JwtAuthOptions> jwtAuthOptions,
        IGetAllMigrationsCommandHandler handler)
    {
        _jwtAuthOptions = jwtAuthOptions.Value;
        _handler = handler;
    }

    public override void Configure()
    {
        Post(EndpointRoutes.MigrationsPerformRoute);
        Claims(_jwtAuthOptions.UserIdClaim);
    }

    public override async Task HandleAsync(PerformMigrationsUpToRequest req, CancellationToken ct)
    {

    }
}
