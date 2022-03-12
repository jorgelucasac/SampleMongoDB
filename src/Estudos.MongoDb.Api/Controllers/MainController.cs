using Microsoft.AspNetCore.Mvc;

namespace Estudos.MongoDb.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class MainController : ControllerBase
{
}