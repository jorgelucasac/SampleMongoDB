using AutoMapper;
using Estudos.MongoDb.Application.UseCases.CreateRestaurant;
using Estudos.MongoDb.Application.UseCases.GetAllRestaurants;
using Estudos.MongoDb.Application.UseCases.GetRestaurantById;
using Estudos.MongoDb.Application.UseCases.PostReviewRestaurant;
using Estudos.MongoDb.Application.UseCases.UpdateRestaurant;
using Estudos.MongoDb.Domain.Entities;
using Estudos.MongoDb.Domain.Enums;
using Estudos.MongoDb.Domain.ValueObjects;

namespace Estudos.MongoDb.Application.Profiles;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
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

        CreateMap<Restaurant, GetRestaurantByIdOutput>()
            .ForMember(dest => dest.PublicPlace, opt => opt.MapFrom(src => src.Address.PublicPlace))
            .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Address.Number))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
            .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode));

        CreateMap<UpdateRestaurantInput, Restaurant>()
            .ConstructUsing(src => new Restaurant(src.Id, src.Name, (Country)src.Country))
            .AfterMap((src, dest) => dest
                .SetAddress(new Address(src.PublicPlace, src.Number, src.City, src.State, src.ZipCode)));

        CreateMap<PostReviewRestaurantInput, Review>()
            .ConstructUsing(src => new Review(src.RestaurantId, src.Stars, src.Comment));

        CreateMap<Review, PostReviewRestaurantOutput>();
    }
}