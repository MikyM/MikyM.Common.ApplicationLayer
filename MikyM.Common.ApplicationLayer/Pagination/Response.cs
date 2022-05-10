namespace MikyM.Common.ApplicationLayer.Pagination;

public class Response
{
    public Response(IEnumerable<string>? errors) : this(null, errors)
    {
    }

    public Response(string? message = null, IEnumerable<string>? errors = null)
    {
        Message = message ?? string.Empty;
        Errors = errors?.ToArray();
    }

    public bool IsSuccess => Errors is null;
    public string[]? Errors { get; set; }
    public string? Message { get; set; }
}

public class Response<T> : Response
{
    public Response(T? data, IEnumerable<string>? errors) : this(data, null, errors)
    {
    }

    public Response(T? data, string? message = null, IEnumerable<string>? errors = null) : base(message, errors)
    {
        Data = data;
    }

    public T? Data { get; set; }
}