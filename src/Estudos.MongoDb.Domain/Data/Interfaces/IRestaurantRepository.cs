using Estudos.MongoDb.Domain.Entities;
using Estudos.MongoDb.Domain.Enums;
using Estudos.MongoDb.Domain.ValueObjects;

namespace Estudos.MongoDb.Domain.Data.Interfaces;

public interface IRestaurantRepository : IRepository
{
    Task<bool> UpdateCountryAndNameAsync(string id, Country? country, string name, CancellationToken cancellationToken);

    Task AddReviewAsync(Review review, CancellationToken cancellationToken);

    Task<PagedResult<Review>> GetReviewsAsync(string id, IPagedQuery query, CancellationToken cancellationToken);

    Task<Dictionary<Restaurant, double>> GetTopRatedRestaurantsAsync(int limit, CancellationToken cancellationToken);
}