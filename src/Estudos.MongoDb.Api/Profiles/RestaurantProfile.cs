﻿using AutoMapper;
using Estudos.MongoDb.Api.Transports.Requests;
using Estudos.MongoDb.Application.UseCases.CreateRestaurant;
using Estudos.MongoDb.Application.UseCases.GetAllRestaurants;

namespace Estudos.MongoDb.Api.Profiles;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<CreateRestaurantRequest, CreateRestaurantInput>();
        CreateMap<GetAllRestaurantsRequest, GetAllRestaurantsInput>()
            .ConstructUsing(src =>
                new GetAllRestaurantsInput(src.Page, src.PageSize, src.OrderBy, src.Name, src.SortOrder));
    }
}