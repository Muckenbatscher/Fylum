using System.Net;

namespace Fylum.Client.HttpMessaging;

internal class UnauthorizedException : HttpStatusException
{
    public UnauthorizedException() : base(HttpStatusCode.Unauthorized) 
    { 
    }

    public UnauthorizedException(string? message) : base(HttpStatusCode.Unauthorized, message) 
    { 
    }
}
