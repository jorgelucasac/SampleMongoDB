using AutoMapper;
using Estudos.MongoDb.Application.Shared;
using Estudos.MongoDb.Domain.Entities;

namespace Estudos.MongoDb.Application.UseCases.CreateRestaurant;

public class CreateRestauranteUseCase : ICreateRestauranteUseCase
{
    private readonly IMapper _mapper;

    public CreateRestauranteUseCase(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<Output> Handle(CreateRestauranteInput request, CancellationToken cancellationToken)
    {
        var restaurante = _mapper.Map<Restaurante>(request);

        return Task.FromResult(new Output(new CreateRestauranteOutput()));
    }
}