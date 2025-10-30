using FastEndpoints;
using Fylum.Shared.Login;
using Fylum.Shared.Register;
using Fylum.Users.Application.Register;
using Fylum.Users.Domain;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fylum.Api.Register
{
    public class RegisterEndpoint : Endpoint<LoginRequest, Results<Ok<LoginResponse>, BadRequest>>
    {
        private readonly IRegisterEndpointRouteDefinitionProvider _routeProvider;
        private readonly IUserRegisterCommandHandler _commandHandler;
        private readonly IJwtAuthService _jwtAuthService;

        public RegisterEndpoint(IRegisterEndpointRouteDefinitionProvider routeProvider, 
            IUserRegisterCommandHandler commandHandler, 
            IJwtAuthService jwtAuthService)
        {
            _routeProvider = routeProvider;
            _commandHandler = commandHandler;
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
            UserRegisterResult registerResult;
            try
            {
                registerResult = _commandHandler.Handle(command);
            }
            catch (UsernameAlreadyExistsException ex)
            {
                await Send.ResultAsync(TypedResults.BadRequest());
                return;
            }

            var token = _jwtAuthService.BuildToken(registerResult.UserId);
            var response = new RegisterResponse(registerResult.UserId, token);
            await Send.ResultAsync(TypedResults.Ok(response));
        }
    }
}
