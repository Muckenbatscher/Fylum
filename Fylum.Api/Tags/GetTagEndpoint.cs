using FastEndpoints;
using Fylum.Authentication;
using Microsoft.Extensions.Options;

namespace Fylum.Tags
{
    public class GetTagEndpoint : EndpointWithoutRequest<TagResponse>
    {
        private readonly ITagEndpointRouteDefinitionProvider _routeProvider;
        private readonly JwtAuthOptions _jwtAuthOptions;

        public GetTagEndpoint(ITagEndpointRouteDefinitionProvider tagEndpointRouteDefinitionProvider, 
            IOptions<JwtAuthOptions> jwtAuthOptions)
        {
            _routeProvider = tagEndpointRouteDefinitionProvider;
            _jwtAuthOptions = jwtAuthOptions.Value;
        }

        public override void Configure()
        {
            string baseRoute = _routeProvider.BaseEndpointRoute;
            Get($"{baseRoute}/{{id}}");
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
