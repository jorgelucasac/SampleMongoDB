using MediatR;

namespace Estudos.MongoDb.Application.UseCases.Shared;

public interface IBaseUseCase<TInput> : IRequestHandler<TInput, Output> where TInput : BaseInput
{
    Output NotFound();

    Output Success(object result = null);
}