namespace Estudos.MongoDb.Application.UseCases.Shared;

public abstract class BaseUseCase<T> : IBaseUseCase<T> where T : BaseInput
{
    protected Output Output { get; set; }

    protected BaseUseCase()
    {
        Output = new Output();
    }

    public Output NotFound()
    {
        Output.SetNotFound();
        return Output;
    }

    public Output Success(object result = null)
    {
        Output.AddResult(result);
        return Output;
    }

    public abstract Task<Output> Handle(T request, CancellationToken cancellationToken);
}