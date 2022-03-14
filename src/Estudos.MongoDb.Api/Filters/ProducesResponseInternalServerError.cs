using Estudos.MongoDb.Api.Transports.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.MongoDb.Api.Filters;

public class ProducesResponseInternalServerError : ProducesResponseTypeAttribute
{
    public ProducesResponseInternalServerError() : base(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)
    {
    }
}