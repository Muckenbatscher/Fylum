using FastEndpoints;
using Fylum.Authentication;
using Microsoft.Extensions.Options;

namespace Fylum.Files
{
    public class GetFilesEndpoint : EndpointWithoutRequest<IEnumerable<FileResponse>>
    {
        private readonly IFileEndpointRouteDefinitionProvider _routeProvider;
        private readonly JwtAuthOptions _jwtAuthOptions;

        public GetFilesEndpoint(IFileEndpointRouteDefinitionProvider fileEndpointRouteDefinitionProvider,
            IOptions<JwtAuthOptions> jwtAuthOptions)
        {
            _routeProvider = fileEndpointRouteDefinitionProvider;
            _jwtAuthOptions = jwtAuthOptions.Value;
        }

        public override void Configure()
        {
            string baseRoute = _routeProvider.BaseEndpointRoute;
            Get(baseRoute);
            Claims(_jwtAuthOptions.UserIdClaim);
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var file = new FileResponse() { Id = Guid.NewGuid(), Name = "File1.txt" };
            Response = new List<FileResponse> { file };
        }
    }
}
