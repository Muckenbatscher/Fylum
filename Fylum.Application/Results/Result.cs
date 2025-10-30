using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Application
{
    public class Result
    {
        private Result(bool success, Error? error)
        {
            IsSuccess = success;
            Error = error;
        }

        public bool IsSuccess { get; }
        public Error? Error { get; }

        public static Result Success() 
            => new Result(true, null);
        public static Result<T> Success<T>(T value)
            => Result<T>.Success(value);

        public static Result Failure(Error error)
            => new Result(false, error);
        public static Result<T> Failure<T>(Error error)
            => Result<T>.Failure<T>(error);

    }
}
