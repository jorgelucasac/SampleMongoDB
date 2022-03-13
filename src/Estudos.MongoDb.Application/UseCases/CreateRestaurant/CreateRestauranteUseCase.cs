using AutoMapper;
using Estudos.MongoDb.Application.UseCases.Shared;
using Estudos.MongoDb.Domain.Data.Interfaces;
using Estudos.MongoDb.Domain.Entities;

namespace Estudos.MongoDb.Application.UseCases.CreateRestaurant;

public class CreateRestauranteUseCase : ICreateRestauranteUseCase
{
    private readonly IMapper _mapper;
    private readonly IRestauranteRepository _repository;

    public CreateRestauranteUseCase(IMapper mapper, IRestauranteRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Output> Handle(CreateRestauranteInput request, CancellationToken cancellationToken)
    {
        var restaurante = _mapper.Map<Restaurante>(request);
        var id = await _repository.Create(restaurante, cancellationToken);

        return RestaurantcreatedSuccessfully(restaurante, id);
    }

    public Output RestaurantcreatedSuccessfully(Restaurante restaurante, string id)
    {
        var restauranteOutput = _mapper.Map<CreateRestauranteOutput>(restaurante);
        restauranteOutput.Id = id;
        ; return new Output(restauranteOutput);
    }
}