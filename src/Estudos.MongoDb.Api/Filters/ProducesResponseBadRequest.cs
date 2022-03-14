using Estudos.MongoDb.Api.Transports.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.MongoDb.Api.Filters;

public class ProducesResponseBadRequest : ProducesResponseTypeAttribute
{
    public ProducesResponseBadRequest() : base(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)
    {
    }
}