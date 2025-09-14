using FastEndpoints;

namespace Fylum.Files
{
    public class GetFilesEndpoint : EndpointWithoutRequest<IEnumerable<FileResponse>>
    {
        private readonly IFileEndpointRouteDefinitionProvider _routeProvider;

        public GetFilesEndpoint(IFileEndpointRouteDefinitionProvider fileEndpointRouteDefinitionProvider)
        {
            _routeProvider = fileEndpointRouteDefinitionProvider;
        }

        public override void Configure()
        {
            string baseRoute = _routeProvider.BaseEndpointRoute;
            Get(baseRoute);
            Claims(Config["JwtAuth:UserIdClaim"]!);
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var file = new FileResponse() { Id = Guid.NewGuid(), Name = "File1.txt" };
            Response = new List<FileResponse> { file };
        }
    }
}
