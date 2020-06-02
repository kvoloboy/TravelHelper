using System;

namespace BusinessLayer.Utils
{
    public class Result
    {
        public bool Success { get; private set; }
        public string Error { get; private set; }

        public bool Failure => !Success;

        protected Result(bool success, string error)
        {
            var isSucceedAndNonEmptyError = success && !string.IsNullOrEmpty(error);
            var isFailAndEmptyError = !success && string.IsNullOrEmpty(error);

            if (isSucceedAndNonEmptyError || isFailAndEmptyError)
            {
                throw new InvalidOperationException();
            }

            Success = success;
            Error = error;
        }

        public static Result Fail(string message)
        {
            return new Result(false, message);
        }

        public static Result<T> Fail<T>(string message)
        {
            return new Result<T>(default, false, message);
        }

        public static Result Ok()
        {
            return new Result(true, string.Empty);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, string.Empty);
        }

        public static Result Combine(params Result[] results)
        {
            foreach (var result in results)
            {
                if (result.Failure)
                    return result;
            }

            return Ok();
        }
    }

    public class Result<T> : Result
    {
        private T _value;

        public T Value
        {
            get
            {
                if (!Success)
                {
                    throw new InvalidOperationException();
                }

                return _value;
            }
            private set => _value = value;
        }

        protected internal Result(T value, bool success, string error)
            : base(success, error)
        {
            if (value == null && success)
            {
                throw new InvalidOperationException();
            }

            Value = value;
        }
    }
}

