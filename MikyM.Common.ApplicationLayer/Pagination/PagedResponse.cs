namespace MikyM.Common.ApplicationLayer.Pagination;

/// <summary>
/// Paged response.
/// </summary>
/// <typeparam name="T"></typeparam>
[PublicAPI]
public class PagedResponse<T> : Response<T>
{
    /// <summary>
    /// Base constructor.
    /// </summary>
    /// <param name="data">Data.</param>
    /// <param name="pageNumber">Page number.</param>
    /// <param name="pageSize">Page size.</param>
    /// <param name="errors">Errors if any,</param>
    public PagedResponse(T data, int pageNumber, int pageSize, IEnumerable<string>? errors = null) : base(data,
        errors)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    /// <summary>
    /// Page number.
    /// </summary>
    public int PageNumber { get; set; }
    /// <summary>
    /// Page size.
    /// </summary>
    public int PageSize { get; set; }
    /// <summary>
    /// First page's Uri.
    /// </summary>
    public Uri? FirstPage { get; set; }
    /// <summary>
    /// Last page's Uri.
    /// </summary>
    public Uri? LastPage { get; set; }
    /// <summary>
    /// Total count of pages.
    /// </summary>
    public int TotalPages { get; set; }
    /// <summary>
    /// Total number of records.
    /// </summary>
    public long TotalRecords { get; set; }
    /// <summary>
    /// Next page's Uri.
    /// </summary>
    public Uri? NextPage { get; set; }
    /// <summary>
    /// Previous page's Uri.
    /// </summary>
    public Uri? PreviousPage { get; set; }
}
