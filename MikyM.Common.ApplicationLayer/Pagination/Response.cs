namespace MikyM.Common.ApplicationLayer.Pagination;

/// <summary>
/// Response.
/// </summary>
[PublicAPI]
public class Response
{

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="errors">Errors if any.</param>
    public Response(IEnumerable<string>? errors = null) : this(null, errors)
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">Message if any.</param>
    /// <param name="errors">Errors if any.</param>
    public Response(string? message = null, IEnumerable<string>? errors = null)
    {
        Message = message ?? string.Empty;
        Errors = errors?.ToArray();
    }

    /// <summary>
    /// Whether the request was successful.
    /// </summary>
    public bool IsSuccess => Errors is null;
    /// <summary>
    /// Errors if any.
    /// </summary>
    public string[]? Errors { get; set; }
    /// <summary>
    /// Message if any.
    /// </summary>
    public string? Message { get; set; }
}

/// <summary>
/// Response of T.
/// </summary>
/// <typeparam name="T">Type of data.</typeparam>
[PublicAPI]
public class Response<T> : Response
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="data">Data.</param>
    /// <param name="errors">Errors if any.</param>
    public Response(T? data, IEnumerable<string>? errors = null) : this(data, null, errors)
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="data">Data.</param>
    /// <param name="errors">Errors if any.</param>
    /// <param name="message">Message if any.</param>
    public Response(T? data, string? message = null, IEnumerable<string>? errors = null) : base(message, errors)
    {
        Data = data;
    }

    /// <summary>
    /// Data.
    /// </summary>
    public T? Data { get; set; }
}
