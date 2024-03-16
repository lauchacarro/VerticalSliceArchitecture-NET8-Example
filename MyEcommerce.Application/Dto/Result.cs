namespace MyEcommerce.Application.Dto
{
    public class Result
    {

        public Result(bool succeeded, List<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors;
        }

        public Result()
        {
        }

        public bool Succeeded { get; set; }

        public List<string> Errors { get; set; } = new();

        public static Result Success
            => new Result(true, new List<string>());

        public static Result Failure(IEnumerable<string> errors)
            => new Result(false, errors.ToList());

        public static implicit operator Result(string error)
            => Failure(new List<string> { error });

        public static implicit operator Result(List<string> errors)
            => Failure(errors.ToList());

        public static implicit operator Result(bool success)
            => success ? Success : Failure(new[] { "Unsuccessful operation." });

        public static implicit operator bool(Result result)
            => result.Succeeded;
    }

    public class Result<TData> : Result
    {

        public Result()
        {
        }


        public Result(bool succeeded, TData? data, List<string> errors)
            : base(succeeded, errors)
            => Data = data;

        public TData? Data { get; set; }

        public static Result<TData> SuccessWith(TData data)
            => new Result<TData>(true, data, new List<string>());

        public new static Result<TData> Failure(IEnumerable<string> errors)
            => new Result<TData>(false, default, errors.ToList());

        public static implicit operator Result<TData>(string error)
            => Failure(new List<string> { error });

        public static implicit operator Result<TData>(List<string> errors)
            => Failure(errors);

        public static implicit operator Result<TData>(TData data)
            => SuccessWith(data);

        public static implicit operator bool(Result<TData> result)
            => result.Succeeded;
    }
}
