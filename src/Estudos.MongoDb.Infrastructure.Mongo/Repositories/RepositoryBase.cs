using Estudos.MongoDb.Infrastructure.Mongo.Interfaces;
using MongoDB.Driver;

namespace Estudos.MongoDb.Infrastructure.Mongo.Repositories;

public abstract class RepositoryBase<T> where T : class
{
    protected IMongoCollection<T> Collection;
    protected IMongoClientDatabase MongoClientDatabase;
    protected abstract string CollectionName { get; }

    protected RepositoryBase(IMongoClientDatabase mongoClientDatabase)
    {
        MongoClientDatabase = mongoClientDatabase;
        Collection = mongoClientDatabase.Database.GetCollection<T>(CollectionName);
    }
}