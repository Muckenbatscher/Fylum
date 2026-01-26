using Fylum.Api.Shared.ErrorResult;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Application;
using Fylum.Users.Api.Shared;
using Fylum.Users.Application.GetUser;
using Fylum.Users.Domain;
using Microsoft.AspNetCore.Http;

namespace Fylum.Users.Api;

public class GetUserEndpoint : FastEndpoints.EndpointWithoutRequest<UserResponse>
{
    private const string IdParamName = "id";

    private readonly ICommandHandler<GetUserCommand, User> _commandHandler;

    public GetUserEndpoint(ICommandHandler<GetUserCommand, User> commandHandler)
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
        var userResponse = new UserResponse(user.Id, user.Username, user.IsActive);
        await Send.ResultAsync(TypedResults.Ok(userResponse));
    }
}