using FastEndpoints;
using Fylum.Api.Shared.ErrorResult;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Users.Api.Shared;
using Fylum.Users.Application.GetUser;
using Microsoft.AspNetCore.Http;

namespace Fylum.Users.Api;

public class GetUserEndpoint : EndpointWithoutRequest<UserResponse>
{
    private const string IdParamName = "id";

    private readonly IGetUserCommandHandler _commandHandler;

    public GetUserEndpoint(IGetUserCommandHandler commandHandler)
    {
        _commandHandler = commandHandler;
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
        var command = new GetUserCommand(id);
        var userResult = _commandHandler.Handle(command);

        var handling = await Send.EnsureErrorResultHandled(userResult);
        if (handling.ErrorResultHandlingRequired)
            return;

        var user = userResult.Value!;
        var userResponse = new UserResponse
        {
            Id = user.Id,
            Username = user.Username,
            IsActive = user.IsActive
        };
        await Send.ResultAsync(TypedResults.Ok(userResponse));
    }
}