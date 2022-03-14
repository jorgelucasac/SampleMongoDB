namespace Estudos.MongoDb.Domain.Data;

public abstract class PagedResultBase
{
    public int CurrentPage { get; set; }

    public int ResultsPerPage { get; set; }

    public int TotalPages { get; set; }

    public long TotalItems { get; set; }

    public long Total { get; set; }

    protected PagedResultBase()
    {
    }

    protected PagedResultBase(int currentPage, int resultsPerPage,
        int totalPages, int totalItems, long total)
    {
        CurrentPage = currentPage > totalPages ? totalPages : currentPage;
        ResultsPerPage = resultsPerPage;
        TotalPages = totalPages;
        Total = total;
        TotalItems = totalItems;
    }
}