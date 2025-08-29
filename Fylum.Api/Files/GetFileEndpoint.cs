using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fylum.Files
{
    public class GetFileEndpoint : EndpointWithoutRequest<Results<
        Ok<FileResponse>, 
        NotFound>>
    {
        public override void Configure()
        {
            Get("/api/files/{id}");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
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

            await Send.ResponseAsync(TypedResults.Ok(file), cancellation: ct);
        }
    }
}
