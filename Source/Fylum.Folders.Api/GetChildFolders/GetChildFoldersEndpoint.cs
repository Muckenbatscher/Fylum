using Fylum.Api.Shared.ErrorResult;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Application;
using Fylum.Folders.Api.Shared;
using Fylum.Folders.Application;
using Fylum.Folders.Application.GetChildFolders;
using Microsoft.AspNetCore.Http;

namespace Fylum.Folders.Api.GetChildFolders;

public class GetChildFoldersEndpoint : FastEndpoints.Endpoint<GetChildFoldersByParentIdRequest, GetFoldersResponse>
{
    private readonly IQueryHandler<GetChildFoldersQuery, IList<FolderDto>> _queryHandler;

    public GetChildFoldersEndpoint(IQueryHandler<GetChildFoldersQuery, IList<FolderDto>> queryHandler)
    {
        _queryHandler = queryHandler;
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
        var getFoldersResult = _queryHandler.Handle(query);
        var errorHandling = await Send.EnsureErrorResultHandled(getFoldersResult);
        if (errorHandling.ErrorResultHandlingRequired)
            return;

        var result = GetFolderResponses(getFoldersResult.Value!);
        var response = new GetFoldersResponse(result);
        await Send.ResultAsync(TypedResults.Ok(response));
    }

    private IList<GetFolderResponse> GetFolderResponses(IList<FolderDto> folderDtos)
    {
        return folderDtos.Select(dto => new GetFolderResponse(dto.Id, dto.Name, dto.ParentFolderId)).ToList();
    }
}
