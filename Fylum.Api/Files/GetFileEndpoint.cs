using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fylum.Files
{
    public class GetFileEndpoint : EndpointWithoutRequest<Results<
        Ok<FileResponse>, 
        NotFound>>
    {
        private readonly IFileEndpointRouteDefinitionProvider _routeProvider;

        public GetFileEndpoint(IFileEndpointRouteDefinitionProvider fileEndpointRouteDefinitionProvider)
        {
            _routeProvider = fileEndpointRouteDefinitionProvider;
        }

        public override void Configure()
        {
            string baseRoute = _routeProvider.BaseEndpointRoute;
            Get($"{baseRoute}/{{id}}");
            Claims(Config["JwtAuth:UserIdClaim"]!);
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            var userIdClaim = User.Claims.SingleOrDefault(c => c.Type == "UserId");
            if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out var userId))
            {
                await Send.ResultAsync(TypedResults.Unauthorized());
                return;
            }

            var id = Route<Guid>("id");
            var file = new FileResponse()
            {
                Id = id,
                Name = "ExampleFile.txt",
                ParentFolderId = Guid.NewGuid(),
                LatestRevisionId = Guid.NewGuid()
            };
            if (id == new Guid("2F6CDA9C-DB86-47C1-89D0-CD8EAACE6D87"))
            {
                await Send.ResultAsync(TypedResults.NotFound());
                return;
            }

            await Send.ResultAsync(TypedResults.Ok(file));
        }
    }
}
