using Estudos.MongoDb.Domain.Enums;

namespace Estudos.MongoDb.Domain.Data.Interfaces;

public interface IRestaurantRepository : IRepository
{
    Task<bool> UpdateCountry(string id, Country country, CancellationToken cancellationToken);
}