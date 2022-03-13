using Estudos.MongoDb.Application.Shared;
using MediatR;

namespace Estudos.MongoDb.Application.UseCases.CreateRestaurant;

public interface ICreateRestauranteUseCase : IRequestHandler<CreateRestauranteInput, Output>
{ }