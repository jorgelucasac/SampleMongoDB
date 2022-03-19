using Estudos.MongoDb.Api.Extensions;
using Estudos.MongoDb.Application.UseCases.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.MongoDb.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class MainController : ControllerBase
{
    protected IActionResult ResponseGet(Output output)
    {
        if (output.IsValid) return Ok(output.Result);
        if (output.IsNotFound) return NotFound();

        return BadRequest(output.MapToApiErrorResponse());
    }

    protected IActionResult ResponsePutPatchDelete(Output output)
    {
        if (output.IsValid) return NoContent();
        if (output.IsNotFound) return NotFound();

        return BadRequest(output.MapToApiErrorResponse());
    }

    protected IActionResult ResponsePost(Output output, string action)
    {
        if (output.IsValid)
            return CreatedAtAction(action, new { output.Id }, output.Result);

        return BadRequest(output.MapToApiErrorResponse());
    }

    protected IActionResult ResponsePost(Output output)
    {
        if (output.IsValid) return StatusCode(StatusCodes.Status201Created, output.Result);
        if (output.IsNotFound) return NotFound();

        return BadRequest(output.MapToApiErrorResponse());
    }
}