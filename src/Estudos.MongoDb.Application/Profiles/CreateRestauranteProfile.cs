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
        CreateMap<CreateRestauranteInput, Restaurant>()
            .ConstructUsing(src => new Restaurant(src.Nome, (Country)src.Cozinha))
            .AfterMap((src, dest) => dest
                    .SetAddress(new Address(src.Logradouro, src.Numero, src.Cidade, src.UF, src.Cep)));

        CreateMap<Restaurant, CreateRestauranteOutput>()
            .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Address.PublicPlace))
            .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Address.Number))
            .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.UF, opt => opt.MapFrom(src => src.Address.State))
            .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Address.ZipCode));

        CreateMap<Restaurant, GetAllRestaurantsOutput>()
            .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Address.City));
    }
}