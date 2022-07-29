using System.Text.Json;
using MikyM.Common.Utilities.Results;

namespace MikyM.Common.ApplicationLayer.Pagination;

/// <summary>
/// Represents a response without data.
/// </summary>
[PublicAPI]
public record Response
{

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="errors">Errors if any.</param>
    public Response(IEnumerable<IResultError>? errors = null) : this(null, errors)
    {
    }
    
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="errors">Errors if any.</param>
    public Response(params IResultError[] errors) : this(null, errors)
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">Message if any.</param>
    /// <param name="errors">Errors if any.</param>
    public Response(string? message = null, IEnumerable<IResultError>? errors = null)
    {
        Message = message;
        Errors = errors;
    }
    
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">Message if any.</param>
    /// <param name="errors">Errors if any.</param>
    public Response(string? message = null, params IResultError[] errors)
    {
        Message = message;
        Errors = errors;
    }

    /// <summary>
    /// Whether the request was successful.
    /// </summary>
    public bool IsSuccess => Errors is null;
    /// <summary>
    /// Errors if any.
    /// </summary>
    public IEnumerable<IResultError>? Errors { get; set; }
    /// <summary>
    /// Message if any.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Returns a JSON string representation of current instance.
    /// </summary>
    /// <returns>JSON string representation of current instance.</returns>
    public override string ToString()
        => JsonSerializer.Serialize(this);
}

/// <summary>
/// Represents a response with data.
/// </summary>
/// <typeparam name="T">Type of data.</typeparam>
[PublicAPI]
public record Response<T> : Response
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="data">Data.</param>
    /// <param name="errors">Errors if any.</param>
    public Response(T? data, IEnumerable<IResultError>? errors = null) : this(data, null, errors)
    {
    }
    
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="data">Data.</param>
    /// <param name="errors">Errors if any.</param>
    public Response(T? data, params IResultError[] errors) : this(data, null, errors)
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="data">Data.</param>
    /// <param name="errors">Errors if any.</param>
    /// <param name="message">Message if any.</param>
    public Response(T? data, string? message = null, IEnumerable<IResultError>? errors = null) : base(message, errors)
    {
        Data = data;
    }
    
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="data">Data.</param>
    /// <param name="errors">Errors if any.</param>
    /// <param name="message">Message if any.</param>
    public Response(T? data, string? message = null, params IResultError[] errors) : base(message, errors)
    {
        Data = data;
    }

    /// <summary>
    /// Data.
    /// </summary>
    public T? Data { get; set; }
}
