namespace Estudos.MongoDb.Domain.Data;

public class PagedResult<T> : PagedResultBase
{
    public IEnumerable<T> Items { get; }

    public bool IsEmpty => !Items.Any();

    protected PagedResult() => Items = Array.Empty<T>();

    public static PagedResult<T> Empty() => new();

    protected PagedResult(IEnumerable<T> items,
        int currentPage, int resultsPerPage,
        int totalPages, int totalItems, long total) : base(currentPage, resultsPerPage, totalPages, totalItems, total)
    {
        Items = items;
    }

    public static PagedResult<T> Create(IEnumerable<T> items,
        int currentPage, int resultsPerPage, int totalPages,
        int totalItems, long total)
    {
        var pagedResult = new PagedResult<T>(items, currentPage, resultsPerPage, totalPages, totalItems, total);

        return pagedResult;
    }
}