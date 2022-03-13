using AutoMapper;
using Estudos.MongoDb.Application.UseCases.CreateRestaurant;
using Estudos.MongoDb.Domain.Entities;
using Estudos.MongoDb.Domain.Enums;
using Estudos.MongoDb.Domain.ValueObjects;

namespace Estudos.MongoDb.Application.Profiles;

public class CreateRestauranteProfile : Profile
{
    public CreateRestauranteProfile()
    {
        CreateMap<CreateRestauranteInput, Restaurante>()
            .ConstructUsing(src => new Restaurante(src.Nome, (Cozinha)src.Cozinha))
            .AfterMap((src, dest) => dest
                    .AtribuirEndereco(new Endereco(src.Logradouro, src.Numero, src.Cidade, src.UF, src.Cep)));
    }
}