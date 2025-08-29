using FastEndpoints;

namespace Fylum.Tags
{
    public class GetTagEndpoint : EndpointWithoutRequest<TagResponse>
    {
        private readonly ITagEndpointRouteDefinitionProvider _routeProvider;

        public GetTagEndpoint(ITagEndpointRouteDefinitionProvider tagEndpointRouteDefinitionProvider)
        {
            _routeProvider = tagEndpointRouteDefinitionProvider;
        }

        public override void Configure()
        {
            string baseRoute = _routeProvider.BaseEndpointRoute;
            Get($"{baseRoute}/{{id}}");
            AllowAnonymous();
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
