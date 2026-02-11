using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Core.Application.Query;
using Fylum.Core.Presentation.Api.ErrorResult;
using Fylum.Users.Api.Common.Domain;
using Fylum.Users.SharedModels;
using Microsoft.AspNetCore.Http;

namespace Fylum.Users.Api.Features.GetUserById;

public class GetUserByIdEndpoint : FastEndpoints.EndpointWithoutRequest<UserResponse>
{
    private const string IdParamName = "id";

    private readonly IQueryHandler<GetUserByIdQuery, User> _handler;

    public GetUserByIdEndpoint(IQueryHandler<GetUserByIdQuery, User> handler)
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
        var userResult = _handler.Handle(command);

        var handling = await Send.EnsureErrorResultHandled(userResult);
        if (handling.ErrorResultHandlingRequired)
            return;

        var user = userResult.Value!;
        var userResponse = new UserResponse(user.Id, user.Username, user.IsActive);
        await Send.ResultAsync(TypedResults.Ok(userResponse));
    }
}