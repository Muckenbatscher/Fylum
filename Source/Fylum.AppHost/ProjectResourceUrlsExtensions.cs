namespace Fylum.AppHost;

public static class ProjectResourceUrlsExtensions
{
    public static IResourceBuilder<ProjectResource> WithScalarDisplayNameUrls(this IResourceBuilder<ProjectResource> project,
        string scalarUrlIdentifier = "scalar",
        Func<EndpointReference?, bool>? isHttpsEndpoint = null)
    {
        return project.WithUrls(context =>
        {
            foreach (var url in context.Urls)
            {
                var isScalarUrl = url.Url.EndsWith($"/{scalarUrlIdentifier}");
                if (!isScalarUrl)
                    continue;
                Func<EndpointReference?, bool> isHttpsEndpointDetermination =
                    isHttpsEndpoint ?? ((endpoint) => url.Endpoint?.Scheme == "https");

                bool isHttps = isHttpsEndpointDetermination(url.Endpoint);
                url.DisplayText = isHttps ? "Scalar" : "Scalar (HTTP)";
                url.DisplayLocation = UrlDisplayLocation.SummaryAndDetails;
            }
        });
    }

    public static IResourceBuilder<ProjectResource> WithOpenApiSpecUrl(this IResourceBuilder<ProjectResource> project,
        string openApiSpecPath = "/openapi/v1.json",
        string displayText = "Open API Spec",
        string endpointName = "https",
        UrlDisplayLocation displayLocation = UrlDisplayLocation.DetailsOnly)
    {
        return project.WithUrls(context =>
        {
            var endpoint = context.GetEndpoint(endpointName);
            if (endpoint == null)
                return;
            context.Urls.Add(new ResourceUrlAnnotation()
            {
                Url = endpoint.Url + openApiSpecPath,
                DisplayText = displayText,
                DisplayLocation = displayLocation
            });
        });
    }
}