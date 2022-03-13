using Estudos.MongoDb.Application.UseCases.Shared;
using MediatR;

namespace Estudos.MongoDb.Application.UseCases.GetAllRestaurants;

public interface IGetAllRestaurantsUseCase : IRequestHandler<GetAllRestaurantsInput, Output>
{
}