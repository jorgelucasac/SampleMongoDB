using Estudos.MongoDb.Domain.Data;
using Estudos.MongoDb.Domain.Entities;

namespace Estudos.MongoDb.Domain.Data.Interfaces;

public interface IRestauranteRepository
{
    Task<string> Create(Restaurante restaurante, CancellationToken cancellationToken);

    Task<PagedResult<Restaurante>> GetAll(IPagedQuery query, CancellationToken cancellationToken);
}