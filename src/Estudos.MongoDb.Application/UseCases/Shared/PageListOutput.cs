namespace Estudos.MongoDb.Application.UseCases.Shared;

public class PageListOutput<T>
{
    public int CurrentPage { get; }
    public int TotalPages { get; }
    public int PageSize { get; }
    public int TotalCount { get; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
    public IEnumerable<T> Items { get; }

    public PageListOutput(IEnumerable<T> items, int count, int pageNumber, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = CalculateTotalPages(count, pageSize);
        Items = items;
    }

    private int CalculateTotalPages(int count, double pageSize)
    {
        var result = (int)Math.Ceiling(count / pageSize);

        return result < 0 ? 0 : result;
    }
}