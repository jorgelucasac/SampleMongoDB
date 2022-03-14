using Estudos.MongoDb.Domain.Enums;
using Estudos.MongoDb.Domain.ValueObjects;

namespace Estudos.MongoDb.Domain.Data.Interfaces;

public interface IRestaurantRepository : IRepository
{
    Task<bool> UpdateCountryAndName(string id, Country? country, string name, CancellationToken cancellationToken);

    Task AddReview(Review review, CancellationToken cancellationToken);
}