using FastEndpoints;
using Fylum.Core.Presentation.Api.ErrorResult;
using Fylum.Core.Presentation.Api.JwtAuthentication;
using Fylum.Folders.SharedModels;
using Fylum.Folders.SharedModels.GetChildFolders;
using Fylum.Folders.SharedModels.GetFolderById;
using Microsoft.AspNetCore.Http;

namespace Fylum.Folders.Api.Features.GetChildFolders;

public class GetChildFoldersEndpoint : Endpoint<GetChildFoldersByParentIdRequest, GetChildFoldersResponse>
{
    private readonly IGetChildFoldersQueryHandler _handler;

    public GetChildFoldersEndpoint(IGetChildFoldersQueryHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        var route = $"{EndpointRoutes.FolderBaseRoute}/{{{nameof(GetChildFoldersByParentIdRequest.ParentId)}}}/{EndpointRoutes.ChildFoldersRoute}";
        Get(route);
        Claims(JwtAuthConstants.UserIdClaim);
    }
    public override async Task HandleAsync(GetChildFoldersByParentIdRequest req, CancellationToken ct)
    {
        var query = new GetChildFoldersQuery(req.ParentId);
        var getFoldersResult = _handler.Handle(query);
        var errorHandling = await Send.EnsureErrorResultHandled(getFoldersResult);
        if (errorHandling.ErrorResultHandlingRequired)
            return;

        var result = getFoldersResult.Value!;
        var response = new GetChildFoldersResponse(result);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}
