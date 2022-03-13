using Estudos.MongoDb.Domain.Data.Interfaces;

namespace Estudos.MongoDb.Domain.Data;

public sealed class PageQueryFilter
{
    public PageQueryFilter(int resultCount, int resultCountPerPage, int pageCount, int page, int skip)
    {
        ResultCount = resultCount;
        ResultCountPerPage = resultCountPerPage;
        PageCount = pageCount;
        Page = page;
        Skip = skip;
    }

    public int ResultCount { get; }
    public int ResultCountPerPage { get; }
    public int PageCount { get; }
    public int Page { get; }
    public int Skip { get; }

    public static PageQueryFilter Of(IPagedQuery query, int resultCount)
    {
        var resultsPerPage = query.Results > 0 ? query.Results : 10;
        var page = query.Page > 0 ? query.Page : 1;

        return new PageQueryFilter(
            resultCount,
            resultsPerPage,
            (int)Math.Ceiling((decimal)resultCount / resultsPerPage),
            page,
            (page - 1) * resultsPerPage
        );
    }
}