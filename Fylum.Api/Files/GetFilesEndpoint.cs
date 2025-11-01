using FastEndpoints;
using Fylum.Api.JwtAuthentication;
using Fylum.Shared;
using Fylum.Shared.Files;
using Microsoft.Extensions.Options;

namespace Fylum.Api.Files
{
    public class GetFilesEndpoint : EndpointWithoutRequest<IEnumerable<FileResponse>>
    {
        private readonly JwtAuthOptions _jwtAuthOptions;

        public GetFilesEndpoint(IOptions<JwtAuthOptions> jwtAuthOptions)
        {
            _jwtAuthOptions = jwtAuthOptions.Value;
        }

        public override void Configure()
        {
            Get(EndpointRoutes.FileBaseRoute);
            Claims(_jwtAuthOptions.UserIdClaim);
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var file = new FileResponse() { Id = Guid.NewGuid(), Name = "File1.txt" };
            Response = new List<FileResponse> { file };
        }
    }
}
