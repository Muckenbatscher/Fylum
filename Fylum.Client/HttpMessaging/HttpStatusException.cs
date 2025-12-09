using System.Net;

namespace Fylum.Client.HttpMessaging;

internal class HttpStatusException : Exception
{
    public HttpStatusException(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
    }

    public HttpStatusException(HttpStatusCode statusCode, string? message) : base(message)
    {
        StatusCode = statusCode;
    }
    public HttpStatusCode StatusCode { get; }
}
