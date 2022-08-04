namespace WedoIT.NextGen.Api.Endpoints;

public class Response<T> where T:BaseResponse
{
    public List<string> ErrorMessages { get; } = new();

    public T Content { get; set; }
}