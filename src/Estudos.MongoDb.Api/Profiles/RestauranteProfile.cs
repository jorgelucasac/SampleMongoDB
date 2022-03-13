using AutoMapper;
using Estudos.MongoDb.Api.Transports.Requests;
using Estudos.MongoDb.Application.UseCases.CreateRestaurant;

namespace Estudos.MongoDb.Api.Profiles;

public class RestauranteProfile : Profile
{
    public RestauranteProfile()
    {
        CreateMap<CreateRestauranteRequest, CreateRestauranteInput>();
    }
}