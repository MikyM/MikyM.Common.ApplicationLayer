namespace MikyM.Common.ApplicationLayer.Pagination;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class PagedResponse<T> : Response<T>
{
    public PagedResponse(T data, int pageNumber, int pageSize, IEnumerable<string>? errors = null) : base(data,
        errors)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public Uri? FirstPage { get; set; }
    public Uri? LastPage { get; set; }
    public int TotalPages { get; set; }
    public long TotalRecords { get; set; }
    public Uri? NextPage { get; set; }
    public Uri? PreviousPage { get; set; }
}