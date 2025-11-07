using FastEndpoints;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Migration.Application;
using Fylum.Migrations.Api.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Fylum.Migrations.Api
{
    public class GetMigrationsEndpoint : EndpointWithoutRequest<MultipleMigrationsResponse>
    {
        private readonly JwtAuthOptions _jwtAuthOptions;
        private readonly IMigrationWithAppliedStateService _migrationService;

        public GetMigrationsEndpoint(IOptions<JwtAuthOptions> jwtAuthOptions, 
            IMigrationWithAppliedStateService migrationService)
        {
            _jwtAuthOptions = jwtAuthOptions.Value;
            _migrationService = migrationService;
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

            var migrations = _migrationService.GetMigrationsWithAppliedState();
            var migrationResponses = migrations.Select(MapToResponse).ToList();
            var response = new MultipleMigrationsResponse(migrationResponses);
            await Send.ResultAsync(TypedResults.Ok(response));
        }

        private MigrationResponse MapToResponse(MigrationWithAppliedState m)
            => new MigrationResponse(m.Migration.Id, 
                m.Migration.Name, 
                m.IsApplied, 
                m.Migration.IsMinimallyRequired);
    }
}
