using Estudos.MongoDb.Application.UseCases.Shared;
using Estudos.MongoDb.Domain.Data.Interfaces;

namespace Estudos.MongoDb.Application.UseCases.PatchRestaurant;

public class PatchRestaurant : BaseUseCase<PatchRestaurantInput>
{
    private readonly IRestaurantRepository _repository;

    public PatchRestaurant(IRestaurantRepository repository)
    {
        _repository = repository;
    }

    public override async Task<Output> Handle(PatchRestaurantInput request, CancellationToken cancellationToken)
    {
        var notExists = !await _repository.ExistsAsync(request.Id, cancellationToken);
        if (notExists) NotFound();

        await _repository.UpdateCountryAndNameAsync(request.Id, request.GetCountryEnum(), request.Name, cancellationToken);
        return Success();
    }
}