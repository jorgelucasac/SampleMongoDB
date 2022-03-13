namespace Estudos.MongoDb.Application.UseCases.GetRestaurantById;

public class GetRestaurantByIdOutput
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string PublicPlace { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
}