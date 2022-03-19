using AutoMapper;
using Estudos.MongoDb.Api.Filters;
using Estudos.MongoDb.Api.Transports.Requests;
using Estudos.MongoDb.Application.UseCases.PostReviewRestaurant;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.MongoDb.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/restaurants/{id}/[controller]")]
    public class ReviewsController : MainController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ReviewsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PostReviewRestaurantOutput), StatusCodes.Status201Created)]
        [ProducesResponseNotFound]
        [ProducesResponseBadRequest]
        [ProducesResponseInternalServerError]
        public async Task<IActionResult> PostReviewAsync(string id, CreateReviewRequest request, CancellationToken cancellationToken)
        {
            var input = _mapper.Map<PostReviewRestaurantInput>(request);
            input.SetRestaurantId(id);

            var output = await _mediator.Send(input, cancellationToken);
            return ResponsePost(output);
        }
    }
}