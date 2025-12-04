using FastEndpoints;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Shared;
using Fylum.Shared.Files;

namespace Fylum.Api.Files;

public class GetFilesEndpoint : EndpointWithoutRequest<IEnumerable<FileResponse>>
{
    public override void Configure()
    {
        Get(EndpointRoutes.FileBaseRoute);
        Claims(JwtAuthConstants.UserIdClaim);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var file = new FileResponse() { Id = Guid.NewGuid(), Name = "File1.txt" };
        Response = new List<FileResponse> { file };
    }
}