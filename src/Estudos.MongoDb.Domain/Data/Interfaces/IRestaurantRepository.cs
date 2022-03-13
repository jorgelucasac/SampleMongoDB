using Estudos.MongoDb.Domain.Entities;

namespace Estudos.MongoDb.Domain.Data.Interfaces;

public interface IRestaurantRepository
{
    Task<string> Create(Restaurant restaurant, CancellationToken cancellationToken);

    Task<PagedResult<Restaurant>> GetAll(IPagedQuery query, CancellationToken cancellationToken);

    Task<Restaurant> GetById(string id, CancellationToken cancellationToken);
}