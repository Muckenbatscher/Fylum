using FastEndpoints;

namespace Fylum.Tags
{
    public class GetTagsEndpoint : EndpointWithoutRequest<IEnumerable<TagResponse>>
    {
        private readonly ITagEndpointRouteDefinitionProvider _routeProvider;

        public GetTagsEndpoint(ITagEndpointRouteDefinitionProvider tagEndpointRouteDefinitionProvider)
        {
            _routeProvider = tagEndpointRouteDefinitionProvider;
        }

        public override void Configure()
        {
            string baseRoute = _routeProvider.BaseEndpointRoute;
            Get(baseRoute);
            Claims(Config["JwtAuth:UserIdClaim"]!);
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
