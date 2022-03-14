using Estudos.MongoDb.Domain.Enums;

namespace Estudos.MongoDb.Domain.Data.Interfaces;

public interface IRestaurantRepository : IRepository
{
    Task<bool> UpdateCountryAndName(string id, Country? country, string? name, CancellationToken cancellationToken);
}