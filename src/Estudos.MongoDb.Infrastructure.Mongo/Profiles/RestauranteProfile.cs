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
        CreateMap<Restaurante, RestauranteSchema>();
        CreateMap<Endereco, EnderecoSchema>();

        CreateMap<RestauranteSchema, Restaurante>()
            .ForMember(dest => dest.Endereco, opt => opt.Ignore())
            .ConstructUsing(src => new Restaurante(src.Nome, (Cozinha)src.Cozinha))
            .AfterMap((src, dest) => dest
                .AtribuirEndereco(new Endereco(src.Endereco.Logradouro, src.Endereco.Numero, src.Endereco.Cidade, src.Endereco.UF, src.Endereco.Cep)));
    }
}