using AutoMapper;
using Estudos.MongoDb.Api.Transports.Requests;
using Estudos.MongoDb.Application.UseCases.CreateRestaurant;
using Estudos.MongoDb.Application.UseCases.GetAllRestaurants;
using Estudos.MongoDb.Application.UseCases.PatchRestaurant;
using Estudos.MongoDb.Application.UseCases.PostReviewRestaurant;
using Estudos.MongoDb.Application.UseCases.UpdateRestaurant;

namespace Estudos.MongoDb.Api.Profiles;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<CreateRestaurantRequest, CreateRestaurantInput>();
        CreateMap<GetAllRestaurantsRequest, GetAllRestaurantsInput>()
            .ConstructUsing(src =>
                new GetAllRestaurantsInput(src.Page, src.PageSize, src.OrderBy, src.Name, src.SortOrder));

        CreateMap<UpdateRestaurantRequest, UpdateRestaurantInput>()
            .ConstructUsing(src =>
                new UpdateRestaurantInput(src.Name, src.Country, src.PublicPlace, src.Number, src.City, src.State, src.ZipCode));

        CreateMap<PatchRestaurantRequest, PatchRestaurantInput>()
            .ConstructUsing(src =>
                new PatchRestaurantInput(src.Name, src.Country));

        CreateMap<CreateReviewRequest, PostReviewRestaurantInput>()
            .ConstructUsing(src =>
                new PostReviewRestaurantInput(src.Stars, src.Comment));
    }
}