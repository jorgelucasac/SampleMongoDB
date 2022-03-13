using AutoMapper;
using Estudos.MongoDb.Domain.Entities;
using Estudos.MongoDb.Domain.Repositories;
using Estudos.MongoDb.Infrastructure.Mongo.Interfaces;
using Estudos.MongoDb.Infrastructure.Mongo.Schemas;
using MongoDB.Driver;

namespace Estudos.MongoDb.Infrastructure.Mongo.Repositories;

public class RestauranteRepository : RepositoryBase<RestauranteSchema>, IRestauranteRepository
{
    protected override string CollectionName => nameof(Restaurante);
    private readonly IMapper _mapper;

    public RestauranteRepository(IMongoClientDatabase mongoClientDatabase, IMapper mapper) : base(mongoClientDatabase)
    {
        _mapper = mapper;
    }

    public async Task<string> Create(Restaurante restaurante, CancellationToken cancellationToken)
    {
        var restauranteSchema = _mapper.Map<RestauranteSchema>(restaurante);
        await Collection.InsertOneAsync(restauranteSchema, new InsertOneOptions(), cancellationToken);

        return restauranteSchema.Id;
    }

    public async Task<Restaurante> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}