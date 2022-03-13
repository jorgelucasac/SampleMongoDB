namespace Estudos.MongoDb.Infrastructure.Mongo.Extensions;

public sealed class MongoDbOptions
{
    public string DatabaseName { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
}