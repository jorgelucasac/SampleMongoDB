using Estudos.MongoDb.Domain.Data.Interfaces;
using Estudos.MongoDb.Infrastructure.Mongo.DataBase;
using Estudos.MongoDb.Infrastructure.Mongo.Interfaces;
using Estudos.MongoDb.Infrastructure.Mongo.Mappings;
using Estudos.MongoDb.Infrastructure.Mongo.Profiles;
using Estudos.MongoDb.Infrastructure.Mongo.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Estudos.MongoDb.Infrastructure.Mongo.Extensions;

public static class MongoDbExtension
{
    public static IServiceCollection AddMongoServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMongoDbOptions(configuration);
        services.AddAutoMapperToInfrastructure();
        services.AddRepositories();
        AddSchemaMappings();
        return services;
    }

    private static void AddMongoDbOptions(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(nameof(MongoDbOptions));
        services.Configure<MongoDbOptions>(section);
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IMongoClientDatabase, MongoClientDatabase>();
        services.AddScoped<IRestaurantRepository, RestaurantMongoRepository>();
    }

    private static void AddAutoMapperToInfrastructure(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(RestauranteProfile));
    }

    private static void AddSchemaMappings()
    {
        RestauranteSchemaMapping.Configure();
    }
}