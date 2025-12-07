using FastEndpoints;
using Fylum.Api.Shared;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Domain.Files;
using Fylum.Shared;
using Fylum.Shared.Files;
using Microsoft.AspNetCore.Http.HttpResults;
using File = Fylum.Domain.Files.File;

namespace Fylum.Api.Files;

public class GetFileEndpoint : Endpoint<UserClaimRequest, Results<
    Ok<FileResponse>,
    NotFound>>
{
    private readonly IFileRepository _fileRepository;

    private const string IdParamName = "id";

    public GetFileEndpoint(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    public override void Configure()
    {
        string baseRoute = EndpointRoutes.FileBaseRoute;
        Get($"{baseRoute}/{{{IdParamName}}}");
        Claims(JwtAuthConstants.UserIdClaim);
    }
    public override async Task HandleAsync(UserClaimRequest request, CancellationToken ct)
    {
        var newFile = new File(Guid.NewGuid())
        {
            Name = "ExampleFile.txt",
            ParentFolderId = Guid.NewGuid()
        };
        _fileRepository.Create(newFile);

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