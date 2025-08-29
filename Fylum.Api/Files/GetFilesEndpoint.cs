using FastEndpoints;

namespace Fylum.Files
{
    public class GetFilesEndpoint : EndpointWithoutRequest<IEnumerable<FileResponse>>
    {
        public override void Configure()
        {
            Get("api/files");
            AllowAnonymous();
        }

        public override Task HandleAsync(CancellationToken ct)
        {
            var file = new FileResponse() { Id = Guid.NewGuid(), Name = "File1.txt" };
            Response = new List<FileResponse> { file };
            return Task.CompletedTask;
        }
    }
}
