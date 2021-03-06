using AutoMapper;
using Estudos.MongoDb.Application.UseCases.Shared;
using Estudos.MongoDb.Domain.Data.Interfaces;
using Estudos.MongoDb.Domain.Entities;

namespace Estudos.MongoDb.Application.UseCases.UpdateRestaurant;

public class UpdateRestaurantUseCase : BaseUseCase<UpdateRestaurantInput>
{
    private readonly IRestaurantRepository _repository;
    private readonly IMapper _mapper;

    public UpdateRestaurantUseCase(IRestaurantRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public override async Task<Output> Handle(UpdateRestaurantInput request, CancellationToken cancellationToken)
    {
        var notExists = !await _repository.ExistsAsync(request.Id, cancellationToken);
        if (notExists) NotFound();

        var restaurant = _mapper.Map<Restaurant>(request);
        await _repository.UpdateAsync(restaurant, cancellationToken);

        return Success();
    }
}