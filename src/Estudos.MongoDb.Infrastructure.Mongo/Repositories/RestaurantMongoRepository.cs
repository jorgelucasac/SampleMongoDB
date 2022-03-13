using AutoMapper;
using Estudos.MongoDb.Domain.Data;
using Estudos.MongoDb.Domain.Data.Interfaces;
using Estudos.MongoDb.Domain.Entities;
using Estudos.MongoDb.Infrastructure.Mongo.Interfaces;
using Estudos.MongoDb.Infrastructure.Mongo.Schemas;
using MongoDB.Driver;

namespace Estudos.MongoDb.Infrastructure.Mongo.Repositories;

public class RestaurantMongoRepository : MongoRepositoryBase<RestaurantSchema>, IRestaurantRepository
{
    protected override string CollectionName => nameof(Restaurant);
    private readonly IMapper _mapper;

    public RestaurantMongoRepository(IMongoClientDatabase mongoClientDatabase, IMapper mapper) : base(mongoClientDatabase)
    {
        _mapper = mapper;
    }

    public async Task<string> Create(Restaurant restaurant, CancellationToken cancellationToken)
    {
        var restaurantSchema = _mapper.Map<RestaurantSchema>(restaurant);
        await Collection.InsertOneAsync(restaurantSchema, new InsertOneOptions(), cancellationToken);

        return restaurantSchema.Id;
    }

    public async Task<PagedResult<Restaurant>> GetAll(IPagedQuery query, CancellationToken cancellationToken)
    {
        var resultCount = await Collection.CountDocumentsAsync(a => true, cancellationToken: cancellationToken);
        if (resultCount == 0) return PagedResult<Restaurant>.Empty();

        var filter = GetFilter(query.Filter);

        var pageFilter = PageQueryFilter.Of(query, (int)resultCount);
        var restaurants = new List<Restaurant>();

        await Collection.Find(filter)
            .Sort(GetSort(query.SortOrder, query.OrderBy))
            .Skip(pageFilter.Skip)
            .Limit(pageFilter.ResultCountPerPage)
            .ForEachAsync(schema =>
            {
                restaurants.Add(_mapper.Map<Restaurant>(schema));
            }, cancellationToken);

        return PagedResult<Restaurant>.Create(restaurants, pageFilter.Page, pageFilter.ResultCountPerPage,
            pageFilter.PageCount, pageFilter.ResultCount);
    }

    private FilterDefinition<RestaurantSchema> GetFilter(string filter)
    {
        return string.IsNullOrEmpty(filter) ?
            Builders<RestaurantSchema>.Filter.Empty :
            Builders<RestaurantSchema>.Filter.ElemMatch(x => x.Name, filter);
    }
}