using FastEndpoints;
using FastEndpoints.Security;
using Fylum.Api.Authentication;
using Fylum.Api.Login;
using Fylum.Shared.Login;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;

namespace Fylum.Api.Register
{
    public class RegisterEndpoint : Endpoint<LoginRequest, Results<Ok<LoginResponse>, UnauthorizedHttpResult>>
    {
        private readonly IRegisterEndpointRouteDefinitionProvider _routeProvider;
        private readonly JwtAuthOptions _jwtAuthOptions;

        public RegisterEndpoint(IRegisterEndpointRouteDefinitionProvider routeProvider, IOptions<JwtAuthOptions> jwtAuthOptions)
        {
            _routeProvider = routeProvider;
            _jwtAuthOptions = jwtAuthOptions.Value;
        }

        public override void Configure()
        {
            string baseRoute = _routeProvider.BaseEndpointRoute;
            Post(baseRoute);
            AllowAnonymous();
        }
        public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
        {
            // Simulate user authentication (replace with real authentication logic)
            bool valid = ValidateUser(req.Username, req.Password);
            if (!valid)
            {
                await Send.ResultAsync(TypedResults.Unauthorized());
                return;
            }

            var signingKey = Config["JwtAuth:SigningKey"]!;
            var userIdClaim = Config["JwtAuth:UserIdClaim"]!;
            var expirationMinutes = int.Parse(Config["JwtAuth:ExpirationMinutes"]!);

            var userId = Guid.NewGuid();
            var jwtToken = JwtBearer.CreateToken(o =>
            {
                o.SigningKey = signingKey;
                o.SigningAlgorithm = "HS256";
                o.ExpireAt = DateTime.UtcNow.AddMinutes(expirationMinutes);
                o.User.Claims.Add((userIdClaim, userId.ToString()));
            });

            var response = new LoginResponse
            {
                Token = jwtToken
            };
            await Send.ResultAsync(TypedResults.Ok(response));
        }

        private bool ValidateUser(string username, string password)
        {
            // Replace with actual user validation logic
            return username == "user" && password == "password";
        }
    }
}
