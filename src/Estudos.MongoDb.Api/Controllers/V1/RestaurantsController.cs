using AutoMapper;
using Estudos.MongoDb.Api.Extensions;
using Estudos.MongoDb.Api.Transports.Requests;
using Estudos.MongoDb.Application.UseCases.CreateRestaurant;
using Estudos.MongoDb.Application.UseCases.GetAllRestaurants;
using Estudos.MongoDb.Application.UseCases.GetRestaurantById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.MongoDb.Api.Controllers.V1;

public class RestaurantsController : MainController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public RestaurantsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] GetAllRestaurantsRequest request, CancellationToken cancellationToken)
    {
        var input = _mapper.Map<GetAllRestaurantsInput>(request);
        var output = await _mediator.Send(input, cancellationToken);

        if (output.IsValid)
            return Ok(output.Result);

        return BadRequest(output.MapToApiErrorResponse());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(string id, CancellationToken cancellationToken)
    {
        var output = await _mediator.Send(new GetRestaurantByIdInput(id), cancellationToken);

        if (output.IsInvalid)
            return BadRequest(output.MapToApiErrorResponse());

        return output.Result is null ? NotFound() : Ok(output.Result);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CreateRestaurantRequest request, CancellationToken cancellationToken)
    {
        var input = _mapper.Map<CreateRestaurantInput>(request);
        var output = await _mediator.Send(input, cancellationToken);

        if (output.IsValid)
            return Ok(output.Result);

        return BadRequest(output.MapToApiErrorResponse());
    }
}