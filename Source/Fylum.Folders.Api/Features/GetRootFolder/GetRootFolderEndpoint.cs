using Fylum.Core.Application.Query;
using Fylum.Core.Presentation.Api.ErrorResult;
using Fylum.Core.Presentation.Api.JwtAuthentication;
using Fylum.Folders.Api.Common.Application;
using Fylum.Folders.Api.Features.GetFolderById;
using Fylum.Folders.SharedModels;
using Microsoft.AspNetCore.Http;

namespace Fylum.Folders.Api.Features.GetRootFolder;

public class GetRootFolderEndpoint : FastEndpoints.EndpointWithoutRequest<GetFolderResponse>
{
    private readonly IQueryHandler<GetFolderByIdQuery, FolderDto> _queryHandler;
    private const string RootFolderId = "120A803B-2924-4519-811C-1E3ABA90FD52";

    public GetRootFolderEndpoint(IQueryHandler<GetFolderByIdQuery, FolderDto> queryHandler)
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
        var query = new GetFolderByIdQuery(rootFolderGuid);
        var getFolderResult = _queryHandler.Handle(query);
        var errorHandling = await Send.EnsureErrorResultHandled(getFolderResult);
        if (errorHandling.ErrorResultHandlingRequired)
            return;

        var result = getFolderResult.Value!;
        var response = new GetFolderResponse(result.Id, result.Name, result.ParentFolderId);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}