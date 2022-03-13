namespace Estudos.MongoDb.Application.UseCases.GetAllRestaurants;

public class GetAllRestaurantsOutput
{
    public string Id { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Cozinha { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
}