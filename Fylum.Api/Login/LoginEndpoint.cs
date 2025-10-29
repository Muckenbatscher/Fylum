using FastEndpoints;
using Fylum.Shared.Login;
using Fylum.Users.Application.Login;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fylum.Api.Login
{
    public class LoginEndpoint : Endpoint<LoginRequest, Results<Ok<LoginResponse>, UnauthorizedHttpResult>>
    {
        private readonly ILoginEndpointRouteDefinitionProvider _routeProvider;
        private readonly IUserLoginCommandHandler _userLoginCommandHandler;
        private readonly IJwtAuthService _jwtAuthService;

        public LoginEndpoint(ILoginEndpointRouteDefinitionProvider routeProvider,
            IUserLoginCommandHandler userLoginCommandHandler,
            IJwtAuthService jwtAuthService)
        {
            _routeProvider = routeProvider;
            _userLoginCommandHandler = userLoginCommandHandler;
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
            var command = new UserLoginCommand(req.Username, req.Password);
            var loginResult = _userLoginCommandHandler.Handle(command);

            if (!loginResult.Successful)
            {
                await Send.ResultAsync(TypedResults.Unauthorized());
                return;
            }

            var token = _jwtAuthService.BuildToken(loginResult.UserId!.Value);

            var response = new LoginResponse
            {
                Token = token,
            };
            await Send.ResultAsync(TypedResults.Ok(response));
        }
    }
}
