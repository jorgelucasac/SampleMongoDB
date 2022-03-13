using Estudos.MongoDb.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Estudos.MongoDb.Infrastructure.Mongo.Schemas;

public class RestauranteSchema
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Nome { get; set; }
    public Cozinha Cozinha { get; set; }
    public EnderecoSchema Endereco { get; set; }
}