using FastEndpoints;
using Fylum.Core.Presentation.Api.ErrorResult;
using Fylum.Core.Presentation.Api.JwtAuthentication;
using Fylum.Users.SharedModels;
using Fylum.Users.SharedModels.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fylum.Users.Api.Features.Register;

public class RegisterEndpoint : Endpoint<RegisterRequest, Results<Created<RegisterResponse>, Conflict>>
{
    private readonly IUserRegisterCommandHandler _commandHandler;
    private readonly IJwtTokenBuilder _jwtTokenBuilder;

    public RegisterEndpoint(IUserRegisterCommandHandler commandHandler,
        IJwtTokenBuilder jwtTokenBuilder)
    {
        _commandHandler = commandHandler;
        _jwtTokenBuilder = jwtTokenBuilder;
    }

    public override void Configure()
    {
        Post(EndpointRoutes.RegisterRoute);
        AllowAnonymous();
    }
    public override async Task HandleAsync(RegisterRequest req, CancellationToken ct)
    {
        var command = new UserRegisterCommand(req.Username, req.Password);
        var registerResult = _commandHandler.Handle(command);

        var errorHandling = await Send.EnsureErrorResultHandled(registerResult);
        if (errorHandling.ErrorResultHandlingRequired)
            return;

        var resultValue = registerResult.Value;
        var accessToken = _jwtTokenBuilder.BuildAccessToken(resultValue.User.Id);
        var refreshToken = _jwtTokenBuilder.BuildRefreshToken(
            resultValue.User.Id, resultValue.RefreshTokenId, resultValue.RefreshTokenExpiration);
        var tokenPairDto = new TokenPairDto(accessToken, refreshToken);

        var response = new RegisterResponse(resultValue.User, tokenPairDto);
        var newUserUri = $"{EndpointRoutes.UsersBaseRoute}/{resultValue.User.Id}";
        await Send.ResultAsync(TypedResults.Created(newUserUri, response));
    }
}