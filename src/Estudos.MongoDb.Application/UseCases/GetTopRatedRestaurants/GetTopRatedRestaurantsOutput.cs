namespace Estudos.MongoDb.Application.UseCases.GetTopRatedRestaurants;

public class GetTopRatedRestaurantsOutput
{
    public string Id { get; set; }
    public string Name { get; set; }
    public double Stars { get; set; }
}