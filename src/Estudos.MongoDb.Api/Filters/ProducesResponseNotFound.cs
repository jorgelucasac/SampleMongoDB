using Microsoft.AspNetCore.Mvc;

namespace Estudos.MongoDb.Api.Filters;

public class ProducesResponseNotFound : ProducesResponseTypeAttribute
{
    public ProducesResponseNotFound() : base(typeof(ProblemDetails), StatusCodes.Status404NotFound)
    {
    }
}
