using FastEndpoints;
using Fylum.Application;
using Microsoft.AspNetCore.Http;

namespace Fylum.Api.Shared.ErrorResult;

public static class ErrorResultHandler
{
    public static ErrorResultHandlingResponse EnsureErrorResultHandled<TRequest, TResponse, TResultValue>(
        this ResponseSender<TRequest, TResponse> send, 
        Result<TResultValue> result) 
        where TRequest : notnull
    {
        if (result.IsSuccess)
            return false;

        var error = result.Error!;

        switch (error.Type)
        {
            case ErrorType.NotFound:
                send.ResultAsync(TypedResults.NotFound());
                return true;
            case ErrorType.Validation:
                send.ResultAsync(TypedResults.BadRequest());
                return true;
            case ErrorType.Unauthorized:
                send.ResultAsync(TypedResults.Unauthorized());
                return true;
            case ErrorType.Conflict:
                send.ResultAsync(TypedResults.Conflict());
                return true;
            case ErrorType.Internal:
            default:
                send.ResultAsync(TypedResults.StatusCode(StatusCodes.Status500InternalServerError));
                return true;
        }
    }
}
