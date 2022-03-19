using AutoMapper;
using Estudos.MongoDb.Application.UseCases.Shared;
using Estudos.MongoDb.Domain.Data.Interfaces;

namespace Estudos.MongoDb.Application.UseCases.GetRestaurantById;

public class GetRestaurantByIdUseCase : BaseUseCase<GetRestaurantByIdInput>
{
    private readonly IRestaurantRepository _repository;
    private readonly IMapper _mapper;

    public GetRestaurantByIdUseCase(IRestaurantRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public override async Task<Output> Handle(GetRestaurantByIdInput request, CancellationToken cancellationToken)
    {
        var restaurant = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (restaurant is null)
            return NotFound();

        var restaurantOutput = _mapper.Map<GetRestaurantByIdOutput>(restaurant);
        return Success(restaurantOutput);
    }
}