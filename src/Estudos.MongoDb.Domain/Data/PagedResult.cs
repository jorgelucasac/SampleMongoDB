namespace Estudos.MongoDb.Domain.Data;

public class PagedResult<T> : PagedResultBase
{
    public IEnumerable<T> Items { get; }

    public bool IsEmpty => !Items.Any();

    protected PagedResult() => Items = Array.Empty<T>();

    public static PagedResult<T> Empty() => new();

    protected PagedResult(IEnumerable<T> items,
        int currentPage, int resultsPerPage,
        int totalPages, long totalResults) : base(currentPage, resultsPerPage, totalPages, totalResults)
    {
        Items = items;
    }

    public static PagedResult<T> Create(IEnumerable<T> items,
        int currentPage, int resultsPerPage,
        int totalPages, long totalResults)
    {
        var pagedResult = new PagedResult<T>(items, currentPage, resultsPerPage, totalPages, totalResults);

        return pagedResult;
    }

    public static PagedResult<T> From(PagedResultBase result, IEnumerable<T> items)
    {
        var pagedResult = new PagedResult<T>(items, result.CurrentPage, result.ResultsPerPage,
            result.TotalPages, result.TotalResults);

        return pagedResult;
    }
}