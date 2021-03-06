namespace Estudos.MongoDb.Application.UseCases.CreateRestaurant;

public class CreateRestaurantOutput
{
    public string Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; }
    public string PublicPlace { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
}