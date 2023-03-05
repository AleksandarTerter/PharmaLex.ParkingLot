namespace Core.Shared
{
    public class Result<T> : Result
    {
        public T? Value { get; private set; }
        protected internal Result(T value, string? error) : base(error) { Value = value; }
        public static new Result<T> Failure(string error) => new(value: default, error);
        public static implicit operator Result<T>(T value) => new(value, null);
    }

    public class Result
    {
        public bool IsSuccess { get; }
        public string? Error { get; }
        public static Result Success() => new(null);
        public static Result Failure(string error) => new(error);
        protected internal Result(string? error)
        {
            Error = error;
            IsSuccess = Error == null;
        }
    }
}
