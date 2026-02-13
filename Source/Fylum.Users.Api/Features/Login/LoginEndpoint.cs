using FastEndpoints;
using Fylum.Core.Presentation.Api.ErrorResult;
using Fylum.Core.Presentation.Api.JwtAuthentication;
using Fylum.Users.SharedModels;
using Fylum.Users.SharedModels.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fylum.Users.Api.Features.Login;

public class LoginEndpoint : Endpoint<LoginRequest, Results<Ok<LoginResponse>, UnauthorizedHttpResult>>
{
    private readonly IUserLoginCommandHandler _handler;
    private readonly IJwtTokenBuilder _jwtTokenBuilder;

    public LoginEndpoint(IUserLoginCommandHandler commandHandler,
        IJwtTokenBuilder jwtTokenBuilder)
    {
        _handler = commandHandler;
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
        var loginResult = _handler.Handle(command);

        var errorHanding = await Send.EnsureErrorResultHandled(loginResult);
        if (errorHanding.ErrorResultHandlingRequired)
            return;

        var result = loginResult.Value;
        var accessToken = _jwtTokenBuilder.BuildAccessToken(result.User.Id);
        var refreshToken = _jwtTokenBuilder.BuildRefreshToken(
            result.User.Id, result.RefreshTokenId, result.RefreshTokenExpiration);

        var tokenPairDto = new TokenPairDto(accessToken, refreshToken);
        var response = new LoginResponse(tokenPairDto);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}