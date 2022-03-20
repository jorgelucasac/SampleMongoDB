namespace Estudos.MongoDb.Application.UseCases.Shared;

public class PageListOutput<T>
{
    public int CurrentPage { get; }
    public int TotalPages { get; }
    public int PageSize { get; }
    public int TotalItemsInCurrentPage { get; }
    public int Total { get; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
    public IEnumerable<T> Items { get; }

    public PageListOutput(IEnumerable<T> items, int totalItemsInCurrentPage, int total, int pageNumber, int pageSize)
    {
        TotalItemsInCurrentPage = totalItemsInCurrentPage;
        Total = total;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = CalculateTotalPages(total, pageSize);
        Items = items;
    }

    private int CalculateTotalPages(int count, double pageSize)
    {
        var result = (int)Math.Ceiling(count / pageSize);

        return result < 0 ? 0 : result;
    }
}