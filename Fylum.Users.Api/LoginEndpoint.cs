using FastEndpoints;
using Fylum.Api.Shared.ErrorResult;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Users.Api.Shared;
using Fylum.Users.Application.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fylum.Users.Api;

public class LoginEndpoint : Endpoint<LoginRequest, Results<Ok<LoginResponse>, UnauthorizedHttpResult>>
{
    private readonly IUserLoginCommandHandler _commandHandler;
    private readonly IJwtTokenBuilder _jwtTokenBuilder;

    public LoginEndpoint(IUserLoginCommandHandler commandHandler,
        IJwtTokenBuilder jwtTokenBuilder)
    {
        _commandHandler = commandHandler;
        _jwtTokenBuilder = jwtTokenBuilder;
    }

    public override void Configure()
    {
        string baseRoute = EndpointRoutes.LoginRoute;
        Post(baseRoute);
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        var command = new UserLoginCommand(req.Username, req.Password);
        var loginResult = _commandHandler.Handle(command);

        var errorHanding = await Send.EnsureErrorResultHandled(loginResult);
        if (errorHanding.ErrorResultHandlingRequired)
            return;

        var result = loginResult.Value;
        var accessToken = _jwtTokenBuilder.BuildAccessToken(result.UserId);
        var refreshToken = _jwtTokenBuilder.BuildRefreshToken(
            result.UserId, result.RefreshTokenId, result.RefreshTokenExpiration);
        var response = new LoginResponse(accessToken, refreshToken);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}