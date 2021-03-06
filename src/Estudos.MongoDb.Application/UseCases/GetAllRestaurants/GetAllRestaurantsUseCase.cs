using AutoMapper;
using Estudos.MongoDb.Application.UseCases.Shared;
using Estudos.MongoDb.Domain.Data;
using Estudos.MongoDb.Domain.Data.Interfaces;
using Estudos.MongoDb.Domain.Entities;

namespace Estudos.MongoDb.Application.UseCases.GetAllRestaurants;

public class GetAllRestaurantsUseCase : BaseUseCase<GetAllRestaurantsInput>
{
    private readonly IRestaurantRepository _repository;
    private readonly IMapper _mapper;

    public GetAllRestaurantsUseCase(IRestaurantRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public override async Task<Output> Handle(GetAllRestaurantsInput request, CancellationToken cancellationToken)
    {
        var restaurants = await _repository.GetAllAsync(request, cancellationToken);

        return Success(GetPageListOutput(restaurants));
    }

    private PageListOutput<GetAllRestaurantsOutput> GetPageListOutput(PagedResult<Restaurant> pagedResult)
    {
        var getAllRestaurantsOutput = _mapper.Map<IEnumerable<GetAllRestaurantsOutput>>(pagedResult.Items);

        return new PageListOutput<GetAllRestaurantsOutput>
        (getAllRestaurantsOutput, (int)pagedResult.TotalItems, (int)pagedResult.Total, pagedResult.CurrentPage,
            pagedResult.ResultsPerPage);
    }
}