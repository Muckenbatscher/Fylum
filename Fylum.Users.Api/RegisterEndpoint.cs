using FastEndpoints;
using Fylum.Api.Shared.ErrorResult;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Users.Api.Shared;
using Fylum.Users.Application.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fylum.Users.Api;

public class RegisterEndpoint : Endpoint<RegisterRequest, Results<Created<RegisterResponse>, Conflict>>
{
    private readonly IUserRegisterCommandHandler _registerCommandHandler;
    private readonly IJwtTokenBuilder _jwtTokenBuilder;

    public RegisterEndpoint(IUserRegisterCommandHandler commandHandler,
        IJwtTokenBuilder jwtTokenBuilder)
    {
        _registerCommandHandler = commandHandler;
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
        var registerResult = _registerCommandHandler.Handle(command);

        var errorHandling = await Send.EnsureErrorResultHandled(registerResult);
        if (errorHandling.ErrorResultHandlingRequired)
            return;

        var resultValue = registerResult.Value;
        var token = _jwtTokenBuilder.BuildAccessToken(resultValue.UserId);
        var response = new RegisterResponse(resultValue.UserId, token);
        var newUserUri = $"{EndpointRoutes.UsersBaseRoute}/{resultValue.UserId}";
        await Send.ResultAsync(TypedResults.Created(newUserUri, response));
    }
}