using FastEndpoints;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Domain.Files;
using Fylum.Shared;
using Fylum.Shared.Files;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using File = Fylum.Domain.Files.File;

namespace Fylum.Api.Files
{
    public class GetFileEndpoint : EndpointWithoutRequest<Results<
        Ok<FileResponse>, 
        NotFound>>
    {
        private readonly IFileRepository _fileRepository;
        private readonly JwtAuthOptions _jwtAuthOptions;

        private const string IdParamName = "id";

        public GetFileEndpoint(IOptions<JwtAuthOptions> jwtAuthOptions,
            IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
            _jwtAuthOptions = jwtAuthOptions.Value;
        }

        public override void Configure()
        {
            string baseRoute = EndpointRoutes.FileBaseRoute;
            Get($"{baseRoute}/{{{IdParamName}}}");
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

            var id = Route<Guid>(IdParamName);
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
