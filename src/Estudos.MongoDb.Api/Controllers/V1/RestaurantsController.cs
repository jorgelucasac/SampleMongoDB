using AutoMapper;
using Estudos.MongoDb.Api.Transports.Requests;
using Estudos.MongoDb.Application.UseCases.CreateRestaurant;
using Estudos.MongoDb.Application.UseCases.GetAllRestaurants;
using Estudos.MongoDb.Application.UseCases.GetRestaurantById;
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
    public async Task<IActionResult> GetAsync([FromQuery] GetAllRestaurantsRequest request,
        CancellationToken cancellationToken)
    {
        var input = _mapper.Map<GetAllRestaurantsInput>(request);
        var output = await _mediator.Send(input, cancellationToken);

        return ResponseGet(output);
    }

    [HttpGet("{id}", Name = nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var output = await _mediator.Send(new GetRestaurantByIdInput(id), cancellationToken);
        return ResponseGet(output);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CreateRestaurantRequest request, CancellationToken cancellationToken)
    {
        var input = _mapper.Map<CreateRestaurantInput>(request);
        var output = await _mediator.Send(input, cancellationToken);

        return ResponsePost(output, nameof(GetByIdAsync));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(string id, UpdateRestaurantRequest request, CancellationToken cancellationToken)
    {
        var input = _mapper.Map<UpdateRestaurantInput>(request);
        input.SetId(id);

        var output = await _mediator.Send(input, cancellationToken);
        return ResponsePutPatchDelete(output);
    }
}