using Fylum.Api.Shared.ErrorResult;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Application;
using Fylum.Folders.Api.Shared;
using Fylum.Folders.Application;
using Fylum.Folders.Application.GetFolder;
using Microsoft.AspNetCore.Http;

namespace Fylum.Folders.Api.GetRootFolder;

public class GetRootFolderEndpoint : FastEndpoints.EndpointWithoutRequest<GetFolderResponse>
{
    private readonly IQueryHandler<GetFolderQuery, FolderDto> _queryHandler;
    private const string RootFolderId = "120A803B-2924-4519-811C-1E3ABA90FD52";

    public GetRootFolderEndpoint(IQueryHandler<GetFolderQuery, FolderDto> queryHandler)
    {
        _queryHandler = queryHandler;
    }

    public override void Configure()
    {
        var route = $"{EndpointRoutes.FolderBaseRoute}/{EndpointRoutes.RootFolderRoute}";
        Get(route);
        Claims(JwtAuthConstants.UserIdClaim);
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var rootFolderGuid = Guid.Parse(RootFolderId);
        var query = new GetFolderQuery(rootFolderGuid);
        var getFolderResult = _queryHandler.Handle(query);
        var errorHandling = await Send.EnsureErrorResultHandled(getFolderResult);
        if (errorHandling.ErrorResultHandlingRequired)
            return;

        var result = getFolderResult.Value!;
        var response = new GetFolderResponse(result.Id, result.Name, result.ParentFolderId);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}