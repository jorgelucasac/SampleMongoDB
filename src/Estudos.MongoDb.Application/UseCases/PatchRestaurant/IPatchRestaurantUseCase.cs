using Estudos.MongoDb.Application.UseCases.Shared;
using MediatR;

namespace Estudos.MongoDb.Application.UseCases.PatchRestaurant;

public interface IPatchRestaurantUseCase : IRequestHandler<PatchRestaurantInput, Output>
{
}