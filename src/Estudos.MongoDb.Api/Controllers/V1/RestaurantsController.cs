using AutoMapper;
using Estudos.MongoDb.Api.Filters;
using Estudos.MongoDb.Api.Transports.Requests;
using Estudos.MongoDb.Application.UseCases.CreateRestaurant;
using Estudos.MongoDb.Application.UseCases.DeleteRestautant;
using Estudos.MongoDb.Application.UseCases.GetAllRestaurants;
using Estudos.MongoDb.Application.UseCases.GetRestaurantById;
using Estudos.MongoDb.Application.UseCases.GetTopRatedRestaurants;
using Estudos.MongoDb.Application.UseCases.PatchRestaurant;
using Estudos.MongoDb.Application.UseCases.UpdateRestaurant;
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
    [ProducesResponseType(typeof(GetAllRestaurantsOutput), StatusCodes.Status200OK)]
    [ProducesResponseNotFound]
    [ProducesResponseBadRequest]
    [ProducesResponseInternalServerError]
    public async Task<IActionResult> GetAsync([FromQuery] GetAllRestaurantsRequest request,
        CancellationToken cancellationToken)
    {
        var input = _mapper.Map<GetAllRestaurantsInput>(request);
        var output = await _mediator.Send(input, cancellationToken);

        return ResponseGet(output);
    }

    [HttpGet("{id}", Name = nameof(GetByIdAsync))]
    [ProducesResponseType(typeof(GetRestaurantByIdOutput), StatusCodes.Status200OK)]
    [ProducesResponseNotFound]
    [ProducesResponseBadRequest]
    [ProducesResponseInternalServerError]
    public async Task<IActionResult> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var output = await _mediator.Send(new GetRestaurantByIdInput(id), cancellationToken);
        return ResponseGet(output);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateRestaurantOutput), StatusCodes.Status201Created)]
    [ProducesResponseNotFound]
    [ProducesResponseBadRequest]
    [ProducesResponseInternalServerError]
    public async Task<IActionResult> PostAsync(CreateRestaurantRequest request, CancellationToken cancellationToken)
    {
        var input = _mapper.Map<CreateRestaurantInput>(request);
        var output = await _mediator.Send(input, cancellationToken);

        return ResponsePost(output, nameof(GetByIdAsync));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseNotFound]
    [ProducesResponseBadRequest]
    [ProducesResponseInternalServerError]
    public async Task<IActionResult> PutAsync(string id, UpdateRestaurantRequest request, CancellationToken cancellationToken)
    {
        var input = _mapper.Map<UpdateRestaurantInput>(request);
        input.SetId(id);

        var output = await _mediator.Send(input, cancellationToken);
        return ResponsePutPatchDelete(output);
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseNotFound]
    [ProducesResponseBadRequest]
    [ProducesResponseInternalServerError]
    public async Task<IActionResult> PatchAsync(string id, PatchRestaurantRequest request, CancellationToken cancellationToken)
    {
        var input = _mapper.Map<PatchRestaurantInput>(request);
        input.SetId(id);

        var output = await _mediator.Send(input, cancellationToken);
        return ResponsePutPatchDelete(output);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseNotFound]
    [ProducesResponseBadRequest]
    [ProducesResponseInternalServerError]
    public async Task<IActionResult> DeleteAsync(string id, CancellationToken cancellationToken)
    {
        var input = new DeleteRestautantInput(id);
        var output = await _mediator.Send(input, cancellationToken);
        return ResponsePutPatchDelete(output);
    }

    [HttpGet("top-rated")]
    [ProducesResponseType(typeof(GetAllRestaurantsOutput), StatusCodes.Status200OK)]
    [ProducesResponseNotFound]
    [ProducesResponseBadRequest]
    [ProducesResponseInternalServerError]
    public async Task<IActionResult> GetTopRatedAsync([FromQuery] int? limit, CancellationToken cancellationToken)
    {
        var input = new GetTopRatedRestaurantsInput(limit);
        var output = await _mediator.Send(input, cancellationToken);

        return ResponseGet(output);
    }
}