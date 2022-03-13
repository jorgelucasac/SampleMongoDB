using Estudos.MongoDb.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Estudos.MongoDb.Infrastructure.Mongo.Schemas;

public class RestaurantSchema
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }
    public Country Country { get; set; }
    public AddressSchema Address { get; set; }
}