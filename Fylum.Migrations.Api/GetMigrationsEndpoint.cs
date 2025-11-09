using FastEndpoints;
using Fylum.Api.Shared.ErrorResult;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Migrations.Api.Shared;
using Fylum.Migrations.Application.GetMigrations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Fylum.Migrations.Api
{
    public class GetMigrationsEndpoint : EndpointWithoutRequest<MultipleMigrationsResponse>
    {
        private readonly JwtAuthOptions _jwtAuthOptions;
        private readonly IGetAllMigrationsCommandHandler _handler;

        public GetMigrationsEndpoint(IOptions<JwtAuthOptions> jwtAuthOptions,
            IGetAllMigrationsCommandHandler handler)
        {
            _jwtAuthOptions = jwtAuthOptions.Value;
            _handler = handler;
        }

        public override void Configure()
        {
            Get(EndpointRoutes.MigrationsBaseRoute);
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

            var command = new GetAllMigrationsCommand(userId);
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
                migrationResult.IsPerformed, 
                migrationResult.IsMinimallyRequired);
    }
}
