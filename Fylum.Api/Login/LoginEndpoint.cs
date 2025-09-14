using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fylum.Login
{
    public class LoginEndpoint : Endpoint<LoginRequest, Results<Ok<LoginResponse>, UnauthorizedHttpResult>>
    {
        private readonly ILoginEndpointRouteDefinitionProvider _routeProvider;

        public LoginEndpoint(ILoginEndpointRouteDefinitionProvider routeProvider)
        {
            _routeProvider = routeProvider;
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
            if (false)
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
                UserId = userId,
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
