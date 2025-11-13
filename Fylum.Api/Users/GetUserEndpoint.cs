using FastEndpoints;
using Fylum.Api.Shared.ErrorResult;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Shared;
using Fylum.Shared.Users;
using Fylum.Users.Application.GetUser;
using Microsoft.Extensions.Options;

namespace Fylum.Api.Users
{
    public class GetUserEndpoint : EndpointWithoutRequest<UserResponse>
    {
        private const string IdParamName = "id";

        private readonly IGetUserCommandHandler _commandHandler;
        private readonly JwtAuthOptions _jwtAuthOptions;

        public GetUserEndpoint(IGetUserCommandHandler commandHandler, 
            IOptions<JwtAuthOptions> jwtAuthoptions)
        {
            _commandHandler = commandHandler;
            _jwtAuthOptions = jwtAuthoptions.Value;
        }

        public override void Configure()
        {
            string baseRoute = EndpointRoutes.UsersBaseRoute;
            Get($"{baseRoute}/{{{IdParamName}}}");
            Claims(_jwtAuthOptions.UserIdClaim);
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            var id = Route<Guid>(IdParamName);
            var command = new GetUserCommand(id);
            var userResult = _commandHandler.Handle(command);

            var handling = await Send.EnsureErrorResultHandled(userResult);
            if (handling.ErrorResultHandlingRequired)
                return;

            var user = userResult.Value!;
            var userResponse = new UserResponse
            {
                Id = user.Id,
                Username = user.Username,
                IsActive = user.IsActive
            };
            await Send.ResultAsync(TypedResults.Ok(userResponse));
        }
    }
}
