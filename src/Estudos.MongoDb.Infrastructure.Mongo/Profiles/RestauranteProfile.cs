using AutoMapper;
using Estudos.MongoDb.Domain.Entities;
using Estudos.MongoDb.Domain.Enums;
using Estudos.MongoDb.Domain.ValueObjects;
using Estudos.MongoDb.Infrastructure.Mongo.Schemas;

namespace Estudos.MongoDb.Infrastructure.Mongo.Profiles;

public class RestauranteProfile : Profile
{
    public RestauranteProfile()
    {
        CreateMap<Restaurant, RestauranteSchema>();
        CreateMap<Address, EnderecoSchema>();

        CreateMap<RestauranteSchema, Restaurant>()
            .ForMember(dest => dest.Address, opt => opt.Ignore())
            .ConstructUsing(src => new Restaurant(src.Nome, (Country)src.Country))
            .AfterMap((src, dest) => dest
                .SetAddress(new Address(src.Endereco.Logradouro, src.Endereco.Numero, src.Endereco.Cidade, src.Endereco.UF, src.Endereco.Cep)));
    }
}