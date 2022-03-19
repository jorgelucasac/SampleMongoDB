using MediatR;

namespace Estudos.MongoDb.Application.UseCases.Shared
{
    public abstract class BaseInput : IRequest<Output>
    {
    }
}