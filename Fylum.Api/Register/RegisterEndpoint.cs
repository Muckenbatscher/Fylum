using FastEndpoints;
using Fylum.Shared.Login;
using Fylum.Shared.Register;
using Fylum.Users.Application.Register;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fylum.Api.Register
{
    public class RegisterEndpoint : Endpoint<LoginRequest, Results<Ok<LoginResponse>, BadRequest>>
    {
        private readonly IRegisterEndpointRouteDefinitionProvider _routeProvider;
        private readonly IUserRegisterCommandHandler _registerCommandHandler;
        private readonly IJwtAuthService _jwtAuthService;

        public RegisterEndpoint(IRegisterEndpointRouteDefinitionProvider routeProvider, 
            IUserRegisterCommandHandler commandHandler, 
            IJwtAuthService jwtAuthService)
        {
            _routeProvider = routeProvider;
            _registerCommandHandler = commandHandler;
            _jwtAuthService = jwtAuthService;
        }

        public override void Configure()
        {
            string baseRoute = _routeProvider.BaseEndpointRoute;
            Post(baseRoute);
            AllowAnonymous();
        }
        public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
        {
            var command = new UserRegisterCommand(req.Username, req.Password);
            var registerResult = _registerCommandHandler.Handle(command);

            var errorHandling = Send.EnsureErrorResultHandled(registerResult);
            if (errorHandling.ErrorResultHandled)
                return;

            var resultValue = registerResult.Value;
            var token = _jwtAuthService.BuildToken(resultValue.UserId);
            var response = new RegisterResponse(resultValue.UserId, token);
            await Send.ResultAsync(TypedResults.Ok(response));
        }
    }
}
