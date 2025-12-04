using FastEndpoints;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Shared;
using Fylum.Shared.Tags;

namespace Fylum.Api.Tags;

public class GetTagsEndpoint : EndpointWithoutRequest<IEnumerable<TagResponse>>
{
    public override void Configure()
    {
        Get(EndpointRoutes.TagsBaseRoute);
        Claims(JwtAuthConstants.UserIdClaim);
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