using Fylum.Core.Application.Query;
using Fylum.Core.Presentation.Api.ErrorResult;
using Fylum.Core.Presentation.Api.JwtAuthentication;
using Fylum.Folders.Api.Common.Application;
using Fylum.Folders.SharedModels;
using Microsoft.AspNetCore.Http;

namespace Fylum.Folders.Api.Features.GetFolderById;

public class GetFolderByIdEndpoint : FastEndpoints.Endpoint<GetFolderByIdRequest, GetFolderResponse>
{
    private readonly IQueryHandler<GetFolderByIdQuery, FolderDto> _queryHandler;

    public GetFolderByIdEndpoint(IQueryHandler<GetFolderByIdQuery, FolderDto> queryHandler)
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
        var query = new GetFolderByIdQuery(req.Id);
        var getFolderResult = _queryHandler.Handle(query);
        var errorHandling = await Send.EnsureErrorResultHandled(getFolderResult);
        if (errorHandling.ErrorResultHandlingRequired)
            return;

        var result = getFolderResult.Value!;
        var response = new GetFolderResponse(result.Id, result.Name, result.ParentFolderId);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}
