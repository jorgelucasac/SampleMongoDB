using Estudos.MongoDb.Infrastructure.Mongo.Extensions;
using Estudos.MongoDb.Infrastructure.Mongo.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Estudos.MongoDb.Infrastructure.Mongo.DataBase;

public class MongoClientDatabase : IMongoClientDatabase
{
    public MongoClientDatabase(IOptions<MongoDbOptions> settings)
    {
        if (settings is null)
        {
            throw new ArgumentNullException(nameof(settings));
        }

        MongoClient = new MongoClient(settings.Value.ConnectionString);
        Database = MongoClient.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoDatabase Database { get; }
    public IMongoClient MongoClient { get; }
}