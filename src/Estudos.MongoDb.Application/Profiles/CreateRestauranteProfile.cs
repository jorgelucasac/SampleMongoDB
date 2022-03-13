using AutoMapper;
using Estudos.MongoDb.Application.UseCases.CreateRestaurant;
using Estudos.MongoDb.Application.UseCases.GetAllRestaurants;
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

        CreateMap<Restaurante, CreateRestauranteOutput>()
            .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Endereco.Logradouro))
            .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Endereco.Numero))
            .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Endereco.Cidade))
            .ForMember(dest => dest.UF, opt => opt.MapFrom(src => src.Endereco.UF))
            .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Endereco.Cep));

        CreateMap<Restaurante, GetAllRestaurantsOutput>()
            .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Endereco.Cidade));
    }
}