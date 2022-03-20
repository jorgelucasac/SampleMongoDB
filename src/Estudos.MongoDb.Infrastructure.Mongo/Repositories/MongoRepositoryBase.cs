using Estudos.MongoDb.Domain.Enums;
using Estudos.MongoDb.Infrastructure.Mongo.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;
using System.Reflection;

namespace Estudos.MongoDb.Infrastructure.Mongo.Repositories;

public abstract class MongoRepositoryBase<T> where T : class
{
    private const string DefaultSortField = "Id";

    protected IMongoCollection<T> Collection;
    protected IMongoClientDatabase MongoClientDatabase;
    protected abstract string CollectionName { get; }

    protected MongoRepositoryBase(IMongoClientDatabase mongoClientDatabase)
    {
        MongoClientDatabase = mongoClientDatabase;
        Collection = mongoClientDatabase.Database.GetCollection<T>(CollectionName);
    }

    protected bool IsObjectId(string id)
    {
        return ObjectId.TryParse(id, out _);
    }

    protected bool IsNotObjectId(string id)
    {
        return !IsObjectId(id);
    }

    protected SortDefinition<T> GetSort(SortOrder order, string propertyName)
    {
        propertyName = string.IsNullOrEmpty(propertyName) ? DefaultSortField : propertyName;
        var @type = typeof(T);

        var parameter = Expression.Parameter(@type);
        var property = Expression.Property(parameter,
            @type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance));
        var conversion = Expression.Convert(property, typeof(object));
        var lambda = Expression.Lambda<Func<T, object>>(conversion, parameter);

        return order == SortOrder.Asc ? Builders<T>.Sort.Ascending(lambda) : Builders<T>.Sort.Descending(lambda);
    }

    protected SortDefinition<T> GetSort2(SortOrder order, string propertyName)
    {
        propertyName = string.IsNullOrEmpty(propertyName) ? DefaultSortField : propertyName;

        var parameter = Expression.Parameter(typeof(T), "x");
        Expression property = Expression.Property(parameter, propertyName);
        var lambda = Expression.Lambda<Func<T, object>>(property, parameter);

        return order == SortOrder.Asc ? Builders<T>.Sort.Ascending(lambda) : Builders<T>.Sort.Descending(lambda);
    }
}

public class OrderExpressionInfo<T>
{
    private readonly Lazy<Func<T, object>> keySelectorFunc;

    public Expression<Func<T, object>> KeySelector { get; }

    public SortOrder OrderType { get; }

    public Func<T, object> KeySelectorFunc => keySelectorFunc.Value;

    public OrderExpressionInfo(Expression<Func<T, object>> keySelector, SortOrder orderType)
    {
        ArgumentNullException.ThrowIfNull(keySelector);

        KeySelector = keySelector;
        OrderType = orderType;
        keySelectorFunc = new Lazy<Func<T, object>>(new Func<Func<T, object>>(KeySelector.Compile));
    }
}