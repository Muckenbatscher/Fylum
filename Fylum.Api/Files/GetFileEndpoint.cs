using FastEndpoints;
using Fylum.Api.Authentication;
using Fylum.Domain.Files;
using Fylum.Files;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using File = Fylum.Domain.Files.File;

namespace Fylum.Api.Files
{
    public class GetFileEndpoint : EndpointWithoutRequest<Results<
        Ok<FileResponse>, 
        NotFound>>
    {
        private readonly IFileEndpointRouteDefinitionProvider _routeProvider;
        private readonly IFileRepository _fileRepository;
        private readonly JwtAuthOptions _jwtAuthOptions;

        public GetFileEndpoint(IFileEndpointRouteDefinitionProvider fileEndpointRouteDefinitionProvider, 
            IOptions<JwtAuthOptions> jwtAuthOptions,
            IFileRepository fileRepository)
        {
            _routeProvider = fileEndpointRouteDefinitionProvider;
            _fileRepository = fileRepository;
            _jwtAuthOptions = jwtAuthOptions.Value;
        }

        public override void Configure()
        {
            string baseRoute = _routeProvider.BaseEndpointRoute;
            Get($"{baseRoute}/{{id}}");
            Claims(_jwtAuthOptions.UserIdClaim);
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            var newFile = new File()
            {
                Id = Guid.NewGuid(),
                Name = "ExampleFile.txt",
                ParentFolderId = Guid.NewGuid()
            };
            _fileRepository.Create(newFile);

            var userIdClaim = User.Claims.SingleOrDefault(c => c.Type == _jwtAuthOptions.UserIdClaim);
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
