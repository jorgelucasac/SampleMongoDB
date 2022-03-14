using Estudos.MongoDb.Application.UseCases.Shared;
using MediatR;

namespace Estudos.MongoDb.Application.UseCases.CreateRestaurant;

public interface ICreateRestaurantUseCase : IRequestHandler<CreateRestaurantInput, Output>
{
}