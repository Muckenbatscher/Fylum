using FastEndpoints;
using Fylum.Core.Application.Results;
using Microsoft.AspNetCore.Http;

namespace Fylum.Core.Presentation.Api.ErrorResult;

public static class ErrorResultHandler
{
    public static async Task<ErrorResultHandlingResponse> EnsureErrorResultHandled<TRequest, TResponse, TResultValue>(
        this ResponseSender<TRequest, TResponse> send,
        Result<TResultValue> result)
        where TRequest : notnull
    {
        if (result.IsSuccess)
            return false;

        await SendErrorResult(send, result.Error!);
        return true;
    }

    public static async Task<ErrorResultHandlingResponse> EnsureErrorResultHandled<TRequest, TResponse>(
        this ResponseSender<TRequest, TResponse> send,
        Result result)
        where TRequest : notnull
    {
        if (result.IsSuccess)
            return false;

        await SendErrorResult(send, result.Error!);
        return true;
    }

    private static async Task SendErrorResult<TRequest, TResponse>(
        ResponseSender<TRequest, TResponse> send,
        Error error)
        where TRequest : notnull
    {
        IResult result = error.Type switch
        {
            ErrorType.NotFound => TypedResults.NotFound(),
            ErrorType.Validation => TypedResults.BadRequest(),
            ErrorType.Unauthorized => TypedResults.Unauthorized(),
            ErrorType.Forbidden => TypedResults.Forbid(),
            ErrorType.Conflict => TypedResults.Conflict(),
            _ => TypedResults.InternalServerError()
        };

        await send.ResultAsync(result);
    }
}