using Estudos.MongoDb.Application.UseCases.Shared;

namespace Estudos.MongoDb.Application.UseCases.GetTopRatedRestaurants;

public class GetTopRatedRestaurantsInput : BaseInput
{
    public int Limit { get; } = 10;

    public GetTopRatedRestaurantsInput(int? limit = null)
    {
        Limit = limit ?? Limit;
    }
}