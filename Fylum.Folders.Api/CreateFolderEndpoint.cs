using Fylum.Api.Shared.ErrorResult;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Application;
using Fylum.Folders.Api.Shared;
using Fylum.Folders.Application.CreateFolder;
using Microsoft.AspNetCore.Http;

namespace Fylum.Folders.Api;

public class CreateFolderEndpoint : FastEndpoints.Endpoint<CreateFolderRequest, CreateFolderResponse>
{
    private readonly ICommandHandler<CreateFolderCommand, CreateFolderResult> _commandHandler;

    public CreateFolderEndpoint(ICommandHandler<CreateFolderCommand, CreateFolderResult> commandHandler)
    {
        _commandHandler = commandHandler;
    }


    public override void Configure()
    {
        Post(EndpointRoutes.CreateFolderRoute);
        Claims(JwtAuthConstants.UserIdClaim);
    }

    public override async Task HandleAsync(CreateFolderRequest req, CancellationToken ct)
    {
        var command = new CreateFolderCommand(req.Name, req.ParentFolderId);
        var createFolderResult = _commandHandler.Handle(command);
        var errorHandling = await Send.EnsureErrorResultHandled(createFolderResult);
        if (errorHandling.ErrorResultHandlingRequired)
            return;

        var result = createFolderResult.Value!;
        var response = new CreateFolderResponse(result.Id, result.Name, result.ParentFolderId);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}
