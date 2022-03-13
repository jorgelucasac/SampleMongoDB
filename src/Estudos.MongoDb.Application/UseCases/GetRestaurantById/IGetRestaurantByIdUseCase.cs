using Estudos.MongoDb.Application.UseCases.Shared;
using MediatR;

namespace Estudos.MongoDb.Application.UseCases.GetRestaurantById;

public interface IGetRestaurantByIdUseCase : IRequestHandler<GetRestaurantByIdInput, Output>
{
}