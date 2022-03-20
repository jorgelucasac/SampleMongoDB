using Microsoft.AspNetCore.Mvc;

namespace Estudos.MongoDb.Api.Filters;

public class ProducesResponseInternalServerError : ProducesResponseTypeAttribute
{
    public ProducesResponseInternalServerError() : base(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)
    {
    }
}