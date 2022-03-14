using AutoMapper;
using Estudos.MongoDb.Application.UseCases.Shared;
using Estudos.MongoDb.Domain.Data.Interfaces;
using Estudos.MongoDb.Domain.Entities;

namespace Estudos.MongoDb.Application.UseCases.CreateRestaurant;

public class CreateRestaurantUseCase : ICreateRestaurantUseCase
{
    private readonly IMapper _mapper;
    private readonly IRestaurantRepository _repository;

    public CreateRestaurantUseCase(IMapper mapper, IRestaurantRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Output> Handle(CreateRestaurantInput request, CancellationToken cancellationToken)
    {
        var restaurant = _mapper.Map<Restaurant>(request);
        var id = await _repository.Create(restaurant, cancellationToken);

        return RestaurantcreatedSuccessfully(restaurant, id);
    }

    public Output RestaurantcreatedSuccessfully(Restaurant restaurant, string id)
    {
        var restaurantOutput = _mapper.Map<CreateRestaurantOutput>(restaurant);
        restaurantOutput.Id = id;
        return new Output(restaurantOutput);
    }
}