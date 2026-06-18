using FastEndpoints;
using Fylum.Core.Presentation.Api.ErrorResult;
using Fylum.Core.Presentation.Api.JwtAuthentication;
using Fylum.Folders.SharedModels;
using Fylum.Folders.SharedModels.GetRootFolder;
using Microsoft.AspNetCore.Http;

namespace Fylum.Folders.Api.Features.GetRootFolder;

public class GetRootFolderEndpoint : EndpointWithoutRequest<GetRootFolderResponse>
{
    private readonly IGetRootFolderQueryHandler _handler;

    public GetRootFolderEndpoint(IGetRootFolderQueryHandler queryHandler)
    {
        _handler = queryHandler;
    }

    public override void Configure()
    {
        var route = $"{EndpointRoutes.FolderBaseRoute}/{EndpointRoutes.RootFolderRoute}";
        Get(route);
        Claims(JwtAuthConstants.UserIdClaim);
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetRootFolderQuery();
        var getFolderResult = _handler.Handle(query);
        var errorHandling = await Send.EnsureErrorResultHandled(getFolderResult);
        if (errorHandling.ErrorResultHandlingRequired)
            return;

        var result = getFolderResult.Value!;
        var response = new GetRootFolderResponse(result);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}