using FastEndpoints;
using Fylum.Api.Shared.ErrorResult;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Shared;
using Fylum.Shared.Users;
using Fylum.Users.Application.Register;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fylum.Api.Register
{
    public class RegisterEndpoint : Endpoint<RegisterRequest, Results<Created<RegisterResponse>, Conflict>>
    {
        private readonly IUserRegisterCommandHandler _registerCommandHandler;
        private readonly IJwtAuthService _jwtAuthService;

        public RegisterEndpoint(IUserRegisterCommandHandler commandHandler, 
            IJwtAuthService jwtAuthService)
        {
            _registerCommandHandler = commandHandler;
            _jwtAuthService = jwtAuthService;
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
            var token = _jwtAuthService.BuildToken(resultValue.UserId);
            var response = new RegisterResponse(resultValue.UserId, token);
            var newUserUri = $"{EndpointRoutes.UsersBaseRoute}/{resultValue.UserId}";
            await Send.ResultAsync(TypedResults.Created(newUserUri, response));
        }
    }
}
