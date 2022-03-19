using AutoMapper;
using Estudos.MongoDb.Application.UseCases.Shared;
using Estudos.MongoDb.Domain.Data.Interfaces;
using Estudos.MongoDb.Domain.Entities;

namespace Estudos.MongoDb.Application.UseCases.GetTopRatedRestaurants;

public class GetTopRatedRestaurantsUseCase : BaseUseCase<GetTopRatedRestaurantsInput>
{
    private readonly IRestaurantRepository _repository;
    private readonly IMapper _mapper;

    public GetTopRatedRestaurantsUseCase(IRestaurantRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public override async Task<Output> Handle(GetTopRatedRestaurantsInput request, CancellationToken cancellationToken)
    {
        var restaurants = await _repository.GetTopRatedRestaurantsAsync(request.Limit, cancellationToken);

        return Success(ToOutput(restaurants));
    }

    private IEnumerable<GetTopRatedRestaurantsOutput> ToOutput(Dictionary<Restaurant, double> restaurants)
    {
        return _mapper.Map<IEnumerable<GetTopRatedRestaurantsOutput>>(restaurants);
    }
}