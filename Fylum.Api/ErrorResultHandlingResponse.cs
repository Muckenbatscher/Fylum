using Fylum.Application;

namespace Fylum.Api
{
    public class ErrorResultHandlingResponse
    {
        public ErrorResultHandlingResponse(bool errorResultHandled)
        {
            ErrorResultHandled = errorResultHandled;
        }
        public bool ErrorResultHandled { get; }


        public static implicit operator ErrorResultHandlingResponse(bool handled) 
            => new ErrorResultHandlingResponse(handled);
    }
}
