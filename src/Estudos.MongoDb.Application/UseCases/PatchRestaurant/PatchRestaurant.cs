using AutoMapper;
using Estudos.MongoDb.Application.UseCases.Shared;
using Estudos.MongoDb.Domain.Data.Interfaces;

namespace Estudos.MongoDb.Application.UseCases.PatchRestaurant;

public class PatchRestaurant : BaseUseCase, IPatchRestaurantUseCase
{
    private readonly IRestaurantRepository _repository;
    private readonly IMapper _mapper;

    public PatchRestaurant(IRestaurantRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Output> Handle(PatchRestaurantInput request, CancellationToken cancellationToken)
    {
        var notExists = !await _repository.ExistsAsync(request.Id, cancellationToken);
        if (notExists) NotFound();

        await _repository.UpdateCountryAndName(request.Id, request.GetCountryEnum(), request.Name, cancellationToken);
        return Success();
    }
}