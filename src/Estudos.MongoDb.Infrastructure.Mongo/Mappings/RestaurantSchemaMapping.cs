using Estudos.MongoDb.Domain.Enums;
using Estudos.MongoDb.Infrastructure.Mongo.Schemas;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Estudos.MongoDb.Infrastructure.Mongo.Mappings;

internal static class RestaurantSchemaMapping
{
    public static void Configure()
    {
        BsonClassMap.RegisterClassMap<RestaurantSchema>(map =>
        {
            map.AutoMap();
            map.SetIgnoreExtraElements(true);
            map.MapIdMember(x => x.Id);

            map.MapMember(x => x.Name)
                .SetIsRequired(true);

            map.MapMember(c => c.Country)
                .SetSerializer(new EnumSerializer<Country>(BsonType.String));
        });
    }
}