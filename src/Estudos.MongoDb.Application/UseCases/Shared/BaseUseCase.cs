namespace Estudos.MongoDb.Application.UseCases.Shared;

public abstract class BaseUseCase
{
    protected Output Output { get; set; }

    protected BaseUseCase()
    {
        Output = new Output();
    }

    protected Output NotFound()
    {
        Output.SetNotFound();
        return Output;
    }
}