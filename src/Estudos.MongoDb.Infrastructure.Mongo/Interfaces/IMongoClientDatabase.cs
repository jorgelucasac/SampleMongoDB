using MongoDB.Driver;

namespace Estudos.MongoDb.Infrastructure.Mongo.Interfaces;

public interface IMongoClientDatabase
{
    IMongoDatabase Database { get; }

    IMongoClient MongoClient { get; }
}