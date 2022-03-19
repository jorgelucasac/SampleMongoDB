using Estudos.MongoDb.Application.UseCases.Shared;
using Estudos.MongoDb.Domain.Data.Interfaces;

namespace Estudos.MongoDb.Application.UseCases.DeleteRestautant;

public class DeleteRestautantUseCase : BaseUseCase<DeleteRestautantInput>
{
    private readonly IRestaurantRepository _repository;

    public DeleteRestautantUseCase(IRestaurantRepository repository)
    {
        _repository = repository;
    }

    public override async Task<Output> Handle(DeleteRestautantInput request, CancellationToken cancellationToken)
    {
        var notExists = !await _repository.ExistsAsync(request.Id, cancellationToken);
        if (notExists) NotFound();

        await _repository.DeleteAsync(request.Id, cancellationToken);
        return Success();
    }
}