namespace Fylum.Application;

public class Result<T>
{
    private Result(T? value, bool success, Error? error)
    {
        _value = value;
        IsSuccess = success;
        Error = error;
    }

    private T? _value;
    public T Value => IsSuccess ?
        _value! :
        throw new InvalidOperationException($"Cannot access {nameof(Value)} when the result is not successful.");
    public bool IsSuccess { get; }
    public Error? Error { get; }

    public static Result<T> Success(T value)
        => new Result<T>(value, true, null);

    public static Result<Value> Failure<Value>(Error error)
        => new Result<Value>(default, false, error);
    public static Result Failure(Error error)
        => Result.Failure(error);


    public static implicit operator Result<T>(T value) =>
        value is not null ? Success(value) : Failure<T>(Error.Internal);

    public static implicit operator Result<T>(Result errorResult) =>
        errorResult is not null && !errorResult.IsSuccess
        ? Failure<T>(errorResult.Error!)
        : throw new InvalidOperationException("Cannot convert a successful untyped Result to a typed Result.");
}