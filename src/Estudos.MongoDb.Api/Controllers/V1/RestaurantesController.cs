using AutoMapper;
using Estudos.MongoDb.Api.Extensions;
using Estudos.MongoDb.Api.Transports.Requests;
using Estudos.MongoDb.Application.UseCases.CreateRestaurant;
using Estudos.MongoDb.Application.UseCases.GetAllRestaurants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.MongoDb.Api.Controllers.V1;

public class RestaurantesController : MainController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public RestaurantesController(IMediator mediator, IMapper mapper)
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

    [HttpPost]
    public async Task<IActionResult> PostAsync(CreateRestauranteRequest request, CancellationToken cancellationToken)
    {
        var input = _mapper.Map<CreateRestauranteInput>(request);
        var output = await _mediator.Send(input, cancellationToken);

        if (output.IsValid)
            return Ok(output.Result);

        return BadRequest(output.MapToApiErrorResponse());
    }
}