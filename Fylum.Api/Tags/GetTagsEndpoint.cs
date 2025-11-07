using FastEndpoints;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Shared;
using Fylum.Shared.Tags;
using Microsoft.Extensions.Options;

namespace Fylum.Api.Tags
{
    public class GetTagsEndpoint : EndpointWithoutRequest<IEnumerable<TagResponse>>
    {
        private readonly JwtAuthOptions _jwtAuthOptions;

        public GetTagsEndpoint(IOptions<JwtAuthOptions> jwtAuthOptions)
        {
            _jwtAuthOptions = jwtAuthOptions.Value;
        }

        public override void Configure()
        {
            Get(EndpointRoutes.TagsBaseRoute);
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
            Response = [tag1, tag2];
        }
    }
}
