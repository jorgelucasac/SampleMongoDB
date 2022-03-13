using AutoMapper;
using Estudos.MongoDb.Application.UseCases.CreateRestaurant;
using Estudos.MongoDb.Application.UseCases.GetAllRestaurants;
using Estudos.MongoDb.Domain.Entities;
using Estudos.MongoDb.Domain.Enums;
using Estudos.MongoDb.Domain.ValueObjects;

namespace Estudos.MongoDb.Application.Profiles;

public class CreateRestaurantProfile : Profile
{
    public CreateRestaurantProfile()
    {
        CreateMap<CreateRestaurantInput, Restaurant>()
            .ConstructUsing(src => new Restaurant(src.Name, (Country)src.Country))
            .AfterMap((src, dest) => dest
                    .SetAddress(new Address(src.PublicPlace, src.Number, src.City, src.State, src.ZipCode)));

        CreateMap<Restaurant, CreateRestaurantOutput>()
            .ForMember(dest => dest.PublicPlace, opt => opt.MapFrom(src => src.Address.PublicPlace))
            .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Address.Number))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
            .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode));

        CreateMap<Restaurant, GetAllRestaurantsOutput>()
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City));
    }
}