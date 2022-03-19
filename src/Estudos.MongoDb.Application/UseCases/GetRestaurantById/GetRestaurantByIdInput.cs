using Estudos.MongoDb.Application.UseCases.Shared;

namespace Estudos.MongoDb.Application.UseCases.GetRestaurantById;

public class GetRestaurantByIdInput : BaseInput
{
    public GetRestaurantByIdInput(string id)
    {
        Id = id;
    }

    public string Id { get; }
}