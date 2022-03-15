using Estudos.MongoDb.Domain.Entities;

namespace Estudos.MongoDb.Domain.Data.Interfaces;

public interface IRepository
{
    Task<string> CreateAsync(Restaurant restaurant, CancellationToken cancellationToken);

    Task<PagedResult<Restaurant>> GetAllAsync(IPagedQuery query, CancellationToken cancellationToken);

    Task<Restaurant> GetByIdAsync(string id, CancellationToken cancellationToken);

    Task<bool> ExistsAsync(string id, CancellationToken cancellationToken);

    Task<bool> UpdateAsync(Restaurant restaurant, CancellationToken cancellationToken);
}