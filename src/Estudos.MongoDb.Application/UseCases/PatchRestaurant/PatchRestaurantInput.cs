using Estudos.MongoDb.Application.UseCases.Shared;
using Estudos.MongoDb.Domain.Enums;
using MediatR;

namespace Estudos.MongoDb.Application.UseCases.PatchRestaurant;

public class PatchRestaurantInput : IRequest<Output>
{
    public PatchRestaurantInput(string name, int? country)
    {
        Name = name;
        Country = country;
    }

    public string Id { get; private set; } = string.Empty;
    public string Name { get; private set; }
    public int? Country { get; private set; }

    public void SetId(string id)
    {
        Id = id;
    }

    internal Country? GetCountryEnum()
    {
        return Country.HasValue ? (Country)Country : null;
    }
}