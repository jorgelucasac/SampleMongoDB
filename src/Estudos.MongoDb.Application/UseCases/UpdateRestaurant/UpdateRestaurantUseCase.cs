using AutoMapper;
using Estudos.MongoDb.Application.UseCases.Shared;
using Estudos.MongoDb.Domain.Data.Interfaces;
using Estudos.MongoDb.Domain.Entities;

namespace Estudos.MongoDb.Application.UseCases.UpdateRestaurant;

public class UpdateRestaurantUseCase : BaseUseCase, IUpdateRestaurantUseCase
{
    private readonly IRestaurantRepository _repository;
    private readonly IMapper _mapper;

    public UpdateRestaurantUseCase(IRestaurantRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Output> Handle(UpdateRestaurantInput request, CancellationToken cancellationToken)
    {
        var restaurant = _mapper.Map<Restaurant>(request);

        await _repository.Update(restaurant, cancellationToken);

        return Successfully();
    }
}