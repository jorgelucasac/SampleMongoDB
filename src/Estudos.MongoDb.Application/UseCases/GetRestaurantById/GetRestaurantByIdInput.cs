using Estudos.MongoDb.Application.UseCases.Shared;
using MediatR;

namespace Estudos.MongoDb.Application.UseCases.GetRestaurantById;

public class GetRestaurantByIdInput : IRequest<Output>
{
    public GetRestaurantByIdInput(string id)
    {
        Id = id;
    }

    public string Id { get; }
}