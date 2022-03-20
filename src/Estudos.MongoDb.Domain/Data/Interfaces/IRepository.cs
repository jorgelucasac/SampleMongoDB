namespace Estudos.MongoDb.Domain.Data.Interfaces;

public interface IWriteRepository<T> where T : class
{
    Task<string> CreateAsync(T entity, CancellationToken cancellationToken);

    Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken);

    Task<bool> DeleteAsync(string id, CancellationToken cancellationToken);
}

public interface IReadRepository<T> where T : class
{
    Task<PagedResult<T>> GetAllAsync(IPagedQuery query, CancellationToken cancellationToken);

    Task<T> GetByIdAsync(string id, CancellationToken cancellationToken);

    Task<bool> ExistsAsync(string id, CancellationToken cancellationToken);
}