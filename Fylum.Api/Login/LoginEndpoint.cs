using FastEndpoints;
using Fylum.Shared.Login;
using Fylum.Users.Application;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fylum.Api.Login
{
    public class LoginEndpoint : Endpoint<LoginRequest, Results<Ok<LoginResponse>, UnauthorizedHttpResult>>
    {
        private readonly ILoginEndpointRouteDefinitionProvider _routeProvider;
        private readonly IUserLoginCommandHandler _userLoginCommandHandler;

        public LoginEndpoint(ILoginEndpointRouteDefinitionProvider routeProvider,
            IUserLoginCommandHandler userLoginCommandHandler)
        {
            _routeProvider = routeProvider;
            _userLoginCommandHandler = userLoginCommandHandler;
        }

        public override void Configure()
        {
            string baseRoute = _routeProvider.BaseEndpointRoute;
            Post(baseRoute);
            AllowAnonymous();
        }

        public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
        {
            var commandParam = new UserLoginParameter(req.Username, req.Password);
            var command = new UserLoginCommand(commandParam);
            var loginResult = _userLoginCommandHandler.Handle(command);

            if (!loginResult.Successful)
            {
                await Send.ResultAsync(TypedResults.Unauthorized());
                return;
            }

            var response = new LoginResponse
            {
                Token = loginResult.Token!,
            };
            await Send.ResultAsync(TypedResults.Ok(response));
        }
    }
}
