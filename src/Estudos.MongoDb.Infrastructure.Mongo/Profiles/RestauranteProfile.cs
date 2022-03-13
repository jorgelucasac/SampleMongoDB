using AutoMapper;
using Estudos.MongoDb.Domain.Entities;
using Estudos.MongoDb.Domain.ValueObjects;
using Estudos.MongoDb.Infrastructure.Mongo.Schemas;

namespace Estudos.MongoDb.Infrastructure.Mongo.Profiles;

public class RestauranteProfile : Profile
{
    public RestauranteProfile()
    {
        CreateMap<Restaurante, RestauranteSchema>();
        CreateMap<Endereco, EnderecoSchema>();
    }
}