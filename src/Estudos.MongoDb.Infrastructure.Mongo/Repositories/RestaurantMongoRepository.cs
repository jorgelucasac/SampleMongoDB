using AutoMapper;
using Estudos.MongoDb.Domain.Data;
using Estudos.MongoDb.Domain.Data.Interfaces;
using Estudos.MongoDb.Domain.Entities;
using Estudos.MongoDb.Infrastructure.Mongo.Interfaces;
using Estudos.MongoDb.Infrastructure.Mongo.Schemas;
using MongoDB.Driver;

namespace Estudos.MongoDb.Infrastructure.Mongo.Repositories;

public class RestaurantMongoRepository : MongoRepositoryBase<RestauranteSchema>, IRestaurantRepository
{
    protected override string CollectionName => nameof(Restaurant);
    private readonly IMapper _mapper;

    public RestaurantMongoRepository(IMongoClientDatabase mongoClientDatabase, IMapper mapper) : base(mongoClientDatabase)
    {
        _mapper = mapper;
    }

    public async Task<string> Create(Restaurant restaurant, CancellationToken cancellationToken)
    {
        var restauranteSchema = _mapper.Map<RestauranteSchema>(restaurant);
        await Collection.InsertOneAsync(restauranteSchema, new InsertOneOptions(), cancellationToken);

        return restauranteSchema.Id;
    }

    public async Task<PagedResult<Restaurant>> GetAll(IPagedQuery query, CancellationToken cancellationToken)
    {
        var resultCount = await Collection.CountDocumentsAsync(a => true, cancellationToken: cancellationToken);
        if (resultCount == 0) return PagedResult<Restaurant>.Empty();

        var filter = GetFilter(query.Filter);

        var pageFilter = PageQueryFilter.Of(query, (int)resultCount);
        var restaurantes = new List<Restaurant>();

        await Collection.Find(filter)
            .Sort(GetSort(query.SortOrder, query.OrderBy))
            .Skip(pageFilter.Skip)
            .Limit(pageFilter.ResultCountPerPage)
            .ForEachAsync(schema =>
            {
                restaurantes.Add(_mapper.Map<Restaurant>(schema));
            }, cancellationToken);

        return PagedResult<Restaurant>.Create(restaurantes, pageFilter.Page, pageFilter.ResultCountPerPage,
            pageFilter.PageCount, pageFilter.ResultCount);
    }

    private FilterDefinition<RestauranteSchema> GetFilter(string filter)
    {
        return string.IsNullOrEmpty(filter) ?
            Builders<RestauranteSchema>.Filter.Empty :
            Builders<RestauranteSchema>.Filter.ElemMatch(x => x.Nome, filter);
    }
}