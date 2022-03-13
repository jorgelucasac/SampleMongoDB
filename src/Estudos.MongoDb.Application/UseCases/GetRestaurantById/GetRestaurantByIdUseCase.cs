using AutoMapper;
using Estudos.MongoDb.Application.UseCases.Shared;
using Estudos.MongoDb.Domain.Data.Interfaces;

namespace Estudos.MongoDb.Application.UseCases.GetRestaurantById;

public class GetRestaurantByIdUseCase : IGetRestaurantByIdUseCase
{
    private readonly IRestaurantRepository _repository;
    private readonly IMapper _mapper;

    public GetRestaurantByIdUseCase(IRestaurantRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Output> Handle(GetRestaurantByIdInput request, CancellationToken cancellationToken)
    {
        var restaurant = await _repository.GetById(request.Id, cancellationToken);
        var restaurantOutput = _mapper.Map<GetRestaurantByIdOutput>(restaurant);

        return GetAllRestaurantsSuccessfully(restaurantOutput);
    }

    public Output GetAllRestaurantsSuccessfully(GetRestaurantByIdOutput restaurantOutput)
    {
        return new Output(restaurantOutput);
    }
}