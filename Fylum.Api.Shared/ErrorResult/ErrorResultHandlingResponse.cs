namespace Fylum.Api.Shared.ErrorResult;

public class ErrorResultHandlingResponse
{
    public ErrorResultHandlingResponse(bool errorResultHandlingRequired)
    {
        ErrorResultHandlingRequired = errorResultHandlingRequired;
    }
    public bool ErrorResultHandlingRequired { get; }


    public static implicit operator ErrorResultHandlingResponse(bool errorResultHandlingRequired) 
        => new ErrorResultHandlingResponse(errorResultHandlingRequired);
}
