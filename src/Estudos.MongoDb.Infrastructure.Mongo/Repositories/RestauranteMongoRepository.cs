using AutoMapper;
using Estudos.MongoDb.Domain.Data;
using Estudos.MongoDb.Domain.Data.Interfaces;
using Estudos.MongoDb.Domain.Entities;
using Estudos.MongoDb.Infrastructure.Mongo.Interfaces;
using Estudos.MongoDb.Infrastructure.Mongo.Schemas;
using MongoDB.Driver;

namespace Estudos.MongoDb.Infrastructure.Mongo.Repositories;

public class RestauranteMongoRepository : MongoRepositoryBase<RestauranteSchema>, IRestauranteRepository
{
    protected override string CollectionName => nameof(Restaurante);
    private readonly IMapper _mapper;

    public RestauranteMongoRepository(IMongoClientDatabase mongoClientDatabase, IMapper mapper) : base(mongoClientDatabase)
    {
        _mapper = mapper;
    }

    public async Task<string> Create(Restaurante restaurante, CancellationToken cancellationToken)
    {
        var restauranteSchema = _mapper.Map<RestauranteSchema>(restaurante);
        await Collection.InsertOneAsync(restauranteSchema, new InsertOneOptions(), cancellationToken);

        return restauranteSchema.Id;
    }

    public async Task<PagedResult<Restaurante>> GetAll(IPagedQuery query, CancellationToken cancellationToken)
    {
        var resultCount = await Collection.CountDocumentsAsync(a => true, cancellationToken: cancellationToken);
        if (resultCount == 0) return PagedResult<Restaurante>.Empty();

        var filter = GetFilter(query.Filter);

        var pageFilter = PageQueryFilter.Of(query, (int)resultCount);
        var restaurantes = new List<Restaurante>();

        await Collection.Find(filter)
            .Sort(GetSort(query.SortOrder, query.OrderBy))
            .Skip(pageFilter.Skip)
            .Limit(pageFilter.ResultCountPerPage)
            .ForEachAsync(schema =>
            {
                restaurantes.Add(_mapper.Map<Restaurante>(schema));
            }, cancellationToken);

        return PagedResult<Restaurante>.Create(restaurantes, pageFilter.Page, pageFilter.ResultCountPerPage,
            pageFilter.PageCount, pageFilter.ResultCount);
    }

    private FilterDefinition<RestauranteSchema> GetFilter(string filter)
    {
        return string.IsNullOrEmpty(filter) ?
            Builders<RestauranteSchema>.Filter.Empty :
            Builders<RestauranteSchema>.Filter.ElemMatch(x => x.Nome, filter);
    }
}