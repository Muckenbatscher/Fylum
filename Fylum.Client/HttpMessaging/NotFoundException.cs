using System.Net;

namespace Fylum.Client.HttpMessaging;

internal class NotFoundException : HttpStatusException
{
    public NotFoundException() : base(HttpStatusCode.NotFound)
    {
    }

    public NotFoundException(string? message) : base(HttpStatusCode.NotFound, message)
    {
    }
}
