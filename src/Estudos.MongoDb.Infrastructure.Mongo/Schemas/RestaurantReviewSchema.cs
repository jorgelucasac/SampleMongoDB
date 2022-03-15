using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Estudos.MongoDb.Infrastructure.Mongo.Schemas;

public class RestaurantReviewSchema
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonId]
    public string Id { get; set; }

    public double AverageStars { get; set; }
    public List<RestaurantSchema> Restaurants { get; set; }
    public List<ReviewSchema> Reviews { get; set; }
}