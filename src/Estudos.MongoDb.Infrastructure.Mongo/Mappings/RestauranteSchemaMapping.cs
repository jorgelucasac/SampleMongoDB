using Estudos.MongoDb.Domain.Enums;
using Estudos.MongoDb.Infrastructure.Mongo.Schemas;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Estudos.MongoDb.Infrastructure.Mongo.Mappings;

internal static class RestauranteSchemaMapping
{
    public static void Configure()
    {
        BsonClassMap.RegisterClassMap<RestauranteSchema>(map =>
        {
            map.AutoMap();
            map.SetIgnoreExtraElements(true);
            map.MapIdMember(x => x.Id);

            map.MapMember(x => x.Nome)
                .SetIsRequired(true);

            map.MapMember(c => c.Country)
                .SetSerializer(new EnumSerializer<Country>(BsonType.String));
        });
    }
}