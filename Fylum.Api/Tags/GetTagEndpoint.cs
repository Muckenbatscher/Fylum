using FastEndpoints;
using Fylum.Api.Shared.JwtAuthentication;
using Fylum.Shared;
using Fylum.Shared.Tags;

namespace Fylum.Api.Tags;

public class GetTagEndpoint : EndpointWithoutRequest<TagResponse>
{
    private const string IdParamName = "id";


    public override void Configure()
    {
        string baseRoute = EndpointRoutes.TagsBaseRoute;
        Get($"{baseRoute}/{{{IdParamName}}}");
        Claims(JwtAuthConstants.UserIdClaim);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<Guid>(IdParamName);
        var tag = new TagResponse
        {
            Id = id,
            Name = $"Tag {id}",
            Type = "none"
        };
        Response = tag;
    }
}