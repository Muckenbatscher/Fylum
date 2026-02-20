using FastEndpoints;
using Fylum.Core.Presentation.Api.ErrorResult;
using Fylum.Core.Presentation.Api.JwtAuthentication;
using Fylum.Folders.SharedModels;
using Fylum.Folders.SharedModels.CreateFolder;
using Microsoft.AspNetCore.Http;

namespace Fylum.Folders.Api.Features.CreateFolder;

public class CreateFolderEndpoint : Endpoint<CreateFolderRequest, CreateFolderResponse>
{
    private readonly ICreateFolderCommandHandler _handler;

    public CreateFolderEndpoint(ICreateFolderCommandHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        Post(EndpointRoutes.FolderBaseRoute);
        Claims(JwtAuthConstants.UserIdClaim);
    }

    public override async Task HandleAsync(CreateFolderRequest req, CancellationToken ct)
    {
        var command = new CreateFolderCommand(req.Name, req.ParentFolderId);
        var createFolderResult = _handler.Handle(command);
        var errorHandling = await Send.EnsureErrorResultHandled(createFolderResult);
        if (errorHandling.ErrorResultHandlingRequired)
            return;

        var result = createFolderResult.Value!;
        var response = new CreateFolderResponse(result);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}
