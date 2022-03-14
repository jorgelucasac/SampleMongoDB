using Estudos.MongoDb.Application.UseCases.Shared;
using MediatR;

namespace Estudos.MongoDb.Application.UseCases.UpdateRestaurant;

public interface IUpdateRestaurantUseCase : IRequestHandler<UpdateRestaurantInput, Output>
{
}