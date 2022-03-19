using Estudos.MongoDb.Application.UseCases.Shared;

namespace Estudos.MongoDb.Application.UseCases.GetTopRatedRestaurants;

public class GetTopRatedRestaurantsInput : BaseInput
{
    public int Limit { get; }

    public GetTopRatedRestaurantsInput(int limit = 10)
    {
        Limit = limit;
    }
}