using Estudos.MongoDb.Domain.Entities;

namespace Estudos.MongoDb.Domain.Repositories;

public interface IRestauranteRepository
{
    Task<string> Create(Restaurante restaurante, CancellationToken cancellationToken);

    Task<Restaurante> GetAll(CancellationToken cancellationToken);
}