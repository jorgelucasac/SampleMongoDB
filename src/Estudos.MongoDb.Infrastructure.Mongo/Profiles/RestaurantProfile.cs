using AutoMapper;
using Estudos.MongoDb.Domain.Entities;
using Estudos.MongoDb.Domain.Enums;
using Estudos.MongoDb.Domain.ValueObjects;
using Estudos.MongoDb.Infrastructure.Mongo.Schemas;

namespace Estudos.MongoDb.Infrastructure.Mongo.Profiles;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<Restaurant, RestaurantSchema>();
        CreateMap<Address, AddressSchema>();

        CreateMap<RestaurantSchema, Restaurant>()
            .ForMember(dest => dest.Address, opt => opt.Ignore())
            .ConstructUsing(src => new Restaurant(src.Name, (Country)src.Country))
            .AfterMap((src, dest) => dest
                .SetAddress(new Address(src.Address.PublicPlace, src.Address.Number, src.Address.City,
                    src.Address.State, src.Address.ZipCode)));

        CreateMap<Review, ReviewSchema>();
    }
}