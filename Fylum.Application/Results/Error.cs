namespace Fylum.Application;

public class Error
{
    private Error(ErrorType type)
    {
        Type = type;
    }

    public ErrorType Type { get; }

    public static Error NotFound => new(ErrorType.NotFound);
    public static Error Validation => new(ErrorType.Validation);
    public static Error Unauthorized => new(ErrorType.Unauthorized);
    public static Error Conflict => new(ErrorType.Conflict);
    public static Error Internal => new(ErrorType.Internal);
}