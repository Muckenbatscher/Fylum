using FastEndpoints;
using Fylum.Api.Shared.ErrorResult;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Users.Api.Shared;
using Fylum.Users.Application.RefreshTokens;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fylum.Users.Api;

public class TokenRefreshEndpoint : Endpoint<TokenRefreshClaimRequest, Results<Ok<TokenRefreshResponse>, UnauthorizedHttpResult, NotFound>>
{
    private readonly ITokenRefreshCommandHandler _commandHandler;
    private readonly IJwtTokenBuilder _jwtTokenBuilder;

    public TokenRefreshEndpoint(ITokenRefreshCommandHandler commandHandler,
        IJwtTokenBuilder jwtTokenBuilder)
    {
        _commandHandler = commandHandler;
        _jwtTokenBuilder = jwtTokenBuilder;
    }

    public override void Configure()
    {
        string baseRoute = EndpointRoutes.TokenRefreshRoute;
        Post(baseRoute);
        Claims(JwtAuthConstants.RefreshIdClaim, JwtAuthConstants.RefreshUserIdClaim);
    }

    public override async Task HandleAsync(TokenRefreshClaimRequest req, CancellationToken ct)
    {
        var command = new TokenRefreshCommand(req.UserId, req.RefreshId);
        var refreshResult = _commandHandler.Handle(command);

        var errorHanding = await Send.EnsureErrorResultHandled(refreshResult);
        if (errorHanding.ErrorResultHandlingRequired)
            return;

        var result = refreshResult.Value;
        var accessToken = _jwtTokenBuilder.BuildAccessToken(result.UserId);
        var refreshToken = _jwtTokenBuilder.BuildRefreshToken(
            result.UserId, result.TokenRefreshId, result.RefreshTokenExpiration);
        var response = new TokenRefreshResponse(accessToken, refreshToken);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}