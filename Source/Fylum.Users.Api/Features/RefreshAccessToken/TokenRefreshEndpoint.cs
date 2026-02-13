using Fylum.Core.Application.Command;
using Fylum.Core.Presentation.Api.ErrorResult;
using Fylum.Core.Presentation.Api.JwtAuthentication;
using Fylum.Users.SharedModels;
using Fylum.Users.SharedModels.RefreshAccessToken;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fylum.Users.Api.Features.RefreshAccessToken;

public class TokenRefreshEndpoint : FastEndpoints.Endpoint<TokenRefreshClaimRequest, Results<Ok<TokenRefreshResponse>, UnauthorizedHttpResult, NotFound>>
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
        ClaimsAll(JwtAuthConstants.RefreshIdClaim, JwtAuthConstants.RefreshUserIdClaim);
    }

    public override async Task HandleAsync(TokenRefreshClaimRequest req, CancellationToken ct)
    {
        var command = new TokenRefreshCommand(req.UserId, req.RefreshId);
        var refreshResult = _commandHandler.Handle(command);

        var errorHanding = await Send.EnsureErrorResultHandled(refreshResult);
        if (errorHanding.ErrorResultHandlingRequired)
            return;

        var result = refreshResult.Value;
        var accessToken = _jwtTokenBuilder.BuildAccessToken(result.User.Id);
        var refreshToken = _jwtTokenBuilder.BuildRefreshToken(
            result.User.Id, result.TokenRefreshId, result.RefreshTokenExpiration);

        var tokenPair = new TokenPairDto(accessToken, refreshToken);
        var response = new TokenRefreshResponse(tokenPair);
        await Send.ResultAsync(TypedResults.Ok(response));
    }
}