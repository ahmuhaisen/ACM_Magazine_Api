namespace Magazine.Api.Shared;

public class ApiResult<T> : ApiResponse
{
    public T? Data { get; set; }

    public static ApiResult<T> Success(T data) => new ApiResult<T>
    {
        IsSuccess = true,
        Data = data
    };
}

