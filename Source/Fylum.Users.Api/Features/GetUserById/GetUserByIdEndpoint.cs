using Fylum.Core.Presentation.Api.ErrorResult;
using Fylum.Core.Presentation.Api.JwtAuthentication;
using Fylum.Users.SharedModels;
using Fylum.Users.SharedModels.GetUserById;
using Microsoft.AspNetCore.Http;

namespace Fylum.Users.Api.Features.GetUserById;

public class GetUserByIdEndpoint : FastEndpoints.EndpointWithoutRequest<GetUserByIdResponse>
{
    private const string IdParamName = "id";

    private readonly IGetUserByIdQueryHandler _handler;

    public GetUserByIdEndpoint(IGetUserByIdQueryHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        string baseRoute = EndpointRoutes.UsersBaseRoute;
        Get($"{baseRoute}/{{{IdParamName}}}");
        Claims(JwtAuthConstants.UserIdClaim);
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<Guid>(IdParamName);
        var command = new GetUserByIdQuery(id);
        var result = _handler.Handle(command);

        var handling = await Send.EnsureErrorResultHandled(result);
        if (handling.ErrorResultHandlingRequired)
            return;

        var userResult = result.Value!;
        var userResponse = new GetUserByIdResponse(userResult);
        await Send.ResultAsync(TypedResults.Ok(userResponse));
    }
}