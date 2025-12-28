using Fylum.Api.Shared.ErrorResult;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Application;
using Fylum.Folders.Api.Shared;
using Fylum.Folders.Application;
using Fylum.Folders.Application.GetFolder;
using Microsoft.AspNetCore.Http;

namespace Fylum.Folders.Api.GetFolderById;

public class GetFolderByIdEndpoint : FastEndpoints.Endpoint<GetFolderByIdRequest, GetFolderResponse>
{
    private readonly IQueryHandler<GetFolderQuery, FolderDto> _queryHandler;

    public GetFolderByIdEndpoint(IQueryHandler<GetFolderQuery, FolderDto> queryHandler)
    {
        _queryHandler = queryHandler;
    }

    public override void Configure()
    {
        var route = $"{EndpointRoutes.FolderBaseRoute}/{{{nameof(GetFolderByIdRequest.Id)}}}";
        Get(route);
        Claims(JwtAuthConstants.UserIdClaim);
    }
    public override async Task HandleAsync(GetFolderByIdRequest req, CancellationToken ct)
    {
        var query = new GetFolderQuery(req.Id);
        var getFolderResult = _queryHandler.Handle(query);
        var errorHandling = await Send.EnsureErrorResultHandled(getFolderResult);
        if (errorHandling.ErrorResultHandlingRequired)
            return;

        var result = getFolderResult.Value!;
        var response = new GetFolderResponse(result.Id, result.Name, result.ParentFolderId);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}
