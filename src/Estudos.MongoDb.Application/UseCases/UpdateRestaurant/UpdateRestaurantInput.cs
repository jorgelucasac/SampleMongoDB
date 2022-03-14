using Estudos.MongoDb.Application.UseCases.Shared;
using MediatR;

namespace Estudos.MongoDb.Application.UseCases.UpdateRestaurant;

public class UpdateRestaurantInput : IRequest<Output>
{
    public UpdateRestaurantInput(string name, int country, string publicPlace, string number, string city, string state, string zipCode)
    {
        Name = name;
        Country = country;
        PublicPlace = publicPlace;
        Number = number;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public string Id { get; private set; } = string.Empty;
    public string Name { get; private set; }
    public int Country { get; private set; }
    public string PublicPlace { get; private set; }
    public string Number { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }

    public void SetId(string id)
    {
        Id = id;
    }
}