using Estudos.MongoDb.Domain.Enums;

namespace Estudos.MongoDb.Domain.Data;

public static class OderExpressionExtension
{
    public static IQueryable<T> OrderByPropertyName<T>(this IQueryable<T> queryable, string propertyName, SortOrder order) where T : class
    {
        var propertyInfo = typeof(T).GetProperty(propertyName);
        if (propertyInfo is null) return queryable;

        return order == SortOrder.Asc ? queryable.OrderBy(x => propertyInfo) : queryable.OrderByDescending(x => propertyInfo);
    }
}