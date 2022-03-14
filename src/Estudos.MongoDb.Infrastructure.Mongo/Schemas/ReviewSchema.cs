using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Estudos.MongoDb.Infrastructure.Mongo.Schemas;

public class ReviewSchema
{
    public ObjectId Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string RestaurantId { get; set; }

    public int Stars { get; set; }
    public string Comment { get; set; }
}