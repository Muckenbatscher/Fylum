using FastEndpoints;
using Fylum.Api.Authentication;
using Fylum.Shared.Tags;
using Microsoft.Extensions.Options;

namespace Fylum.Api.Tags
{
    public class GetTagsEndpoint : EndpointWithoutRequest<IEnumerable<TagResponse>>
    {
        private readonly ITagEndpointRouteDefinitionProvider _routeProvider;
        private readonly JwtAuthOptions _jwtAuthOptions;

        public GetTagsEndpoint(ITagEndpointRouteDefinitionProvider tagEndpointRouteDefinitionProvider,
            IOptions<JwtAuthOptions> jwtAuthOptions)
        {
            _routeProvider = tagEndpointRouteDefinitionProvider;
            _jwtAuthOptions = jwtAuthOptions.Value;
        }

        public override void Configure()
        {
            string baseRoute = _routeProvider.BaseEndpointRoute;
            Get(baseRoute);
            Claims(_jwtAuthOptions.UserIdClaim);
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var tag1 = new TagResponse
            {
                Id = Guid.NewGuid(),
                Name = "Tag 1",
                Type = "string"
            };
            var tag2 = new TagResponse
            {
                Id = Guid.NewGuid(),
                Name = "Tag 2",
                Type = "number"
            };
            Response = new[] { tag1, tag2 };
        }
    }
}
