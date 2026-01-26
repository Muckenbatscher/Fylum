using Fylum.Api.Shared.ErrorResult;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Application;
using Fylum.Users.Api.Shared;
using Fylum.Users.Application.Logout;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fylum.Users.Api;

public class LogoutEndpoint : FastEndpoints.Endpoint<LogoutClaimRequest, Results<Ok, UnauthorizedHttpResult>>
{
    private readonly ICommandHandler<LogoutCommand> _commandHandler;

    public LogoutEndpoint(ICommandHandler<LogoutCommand> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public override void Configure()
    {
        string baseRoute = EndpointRoutes.LogoutRoute;
        Post(baseRoute);
        ClaimsAll(JwtAuthConstants.RefreshIdClaim, JwtAuthConstants.RefreshUserIdClaim);
    }

    public override async Task HandleAsync(LogoutClaimRequest req, CancellationToken ct)
    {
        var command = new LogoutCommand(req.RefreshId, req.UserId);
        var logoutResult = _commandHandler.Handle(command);

        var errorHanding = await Send.EnsureErrorResultHandled(logoutResult);
        if (errorHanding.ErrorResultHandlingRequired)
            return;

        await Send.ResultAsync(TypedResults.Ok());
    }
}