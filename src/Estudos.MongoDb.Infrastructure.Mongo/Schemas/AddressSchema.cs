namespace Estudos.MongoDb.Infrastructure.Mongo.Schemas;

public class AddressSchema
{
    public string PublicPlace { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
}