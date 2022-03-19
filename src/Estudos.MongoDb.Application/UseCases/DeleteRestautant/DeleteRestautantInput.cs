using Estudos.MongoDb.Application.UseCases.Shared;

namespace Estudos.MongoDb.Application.UseCases.DeleteRestautant;

public class DeleteRestautantInput : BaseInput
{
    public string Id { get; }

    public DeleteRestautantInput(string id)
    {
        Id = id;
    }
}