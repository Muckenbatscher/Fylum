using FastEndpoints;
using Fylum.Core.Presentation.Api.ErrorResult;
using Fylum.Core.Presentation.Api.JwtAuthentication;
using Fylum.Folders.SharedModels;
using Fylum.Folders.SharedModels.GetFolderById;
using Microsoft.AspNetCore.Http;

namespace Fylum.Folders.Api.Features.GetFolderById;

public class GetFolderByIdEndpoint : Endpoint<GetFolderByIdRequest, GetFolderByResponse>
{
    private readonly IGetFolderByIdQueryHandler _queryHandler;

    public GetFolderByIdEndpoint(IGetFolderByIdQueryHandler queryHandler)
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
        var response = new GetFolderByResponse(result);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}
