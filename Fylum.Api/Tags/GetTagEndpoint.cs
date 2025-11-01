using FastEndpoints;
using Fylum.Api.JwtAuthentication;
using Fylum.Shared;
using Fylum.Shared.Tags;
using Microsoft.Extensions.Options;

namespace Fylum.Api.Tags
{
    public class GetTagEndpoint : EndpointWithoutRequest<TagResponse>
    {
        private const string IdParamName = "id";

        private readonly JwtAuthOptions _jwtAuthOptions;

        public GetTagEndpoint(IOptions<JwtAuthOptions> jwtAuthOptions)
        {
            _jwtAuthOptions = jwtAuthOptions.Value;
        }

        public override void Configure()
        {
            string baseRoute = EndpointRoutes.TagsBaseRoute;
            Get($"{baseRoute}/{{{IdParamName}}}");
            Claims(_jwtAuthOptions.UserIdClaim);
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var id = Route<Guid>("id");
            var tag = new TagResponse
            {
                Id = id,
                Name = $"Tag {id}",
                Type = "none"
            };
            Response = tag;
        }
    }
}
