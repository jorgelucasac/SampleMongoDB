namespace Estudos.MongoDb.Api.Transports.Requests;

public class PatchRestaurantRequest
{
    public string Name { get; set; } = string.Empty;
    public int? Country { get; set; }
}